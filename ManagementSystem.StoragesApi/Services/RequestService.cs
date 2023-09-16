using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Helpers;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class RequestService : IRequestService
    {
        private readonly UnitOfWork _unitOfWork;

        public RequestService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<RequestInfo> GetListRequests()
        {
            string[] includes = { "Branch", "Storage", "Supplier"  };
            IQueryable<Request> requests = _unitOfWork.RequestRepository.GetWithInclude(r => true, includes).OrderBy(r => r.Status)
                    .ThenByDescending(r => r.ModifyDate);
            List<RequestInfo> list = new List<RequestInfo>();
            foreach (Request request in requests)
            {
                list.Add(new RequestInfo
                {
                    RequestId = request.RequestId,
                    BillNumber = request.BillNumber,
                    VoucherNumber = request.RequestId,
                    BranchName = request.Branch.BranchName,
                    StorageName = request.Storage.StorageName,
                    DeliverName = request.DeliverName,
                    DeliverPhone = request.DeliverPhone,
                    ReceiverName = request.ReceiverName,
                    ReceiverPhone = request.ReceiverPhone,
                    ReceivingDay = request.ReceivingDay,
                    SupplierName = request.Supplier.DisplayName,
                    Signature = request.Signature,
                    TotalAmount = request.TotalAmount,
                    Status = EnumHelpers.GetEnumDescription(request.Status),
                    Note = request.Note,
                    UserId = request.UserId,
                    PaymentMethod = request.PaymentMethod,
                });
            }
            return list;
        }

        public RequestModel GetRequestById(int requestId)
        {
            string[] includes = { "Branch", "Storage", "Supplier" };
            Request request =  _unitOfWork.RequestRepository.GetWithInclude(r => r.RequestId == requestId, includes).FirstOrDefault();
            if (request != null)
            {
                RequestModel receipt = new RequestModel
                {
                    RequestId = request.RequestId,
                    BillNumber = request.BillNumber,
                    VoucherNumber = request.RequestId,
                    DeliverName = request.DeliverName,
                    DeliverPhone = request.DeliverPhone,
                    ReceiverName = request.ReceiverName,
                    ReceiverPhone = request.ReceiverPhone,
                    ReceivingDay = request.ReceivingDay,
                    Signature = request.Signature,
                    TotalAmount = request.TotalAmount,
                    Status = EnumHelpers.GetEnumDescription(request.Status),
                    StatusCode = request.Status,
                    Note = request.Note,
                    UserId = request.UserId,
                    PaymentMethod = request.PaymentMethod,
                    Branch = request.Branch,
                    Storage = request.Storage,
                    Supplier = request.Supplier,
                };

                string[] includesItem = { "Product"};
                string[] includeProduct = { "Product", "Unit" };
                List<RequestItem> requestItems = _unitOfWork.RequestItemRepository.GetWithInclude(i => i.RequestId == requestId, includesItem).ToList();
                List<ReceiptDetailModel> details = new List<ReceiptDetailModel>();
                foreach (RequestItem item in requestItems) {
                    ProductUnit productDetail = _unitOfWork.ProductUnitRepository.GetWithInclude(x => x.ProductId == item.ProductId && x.UnitId == item.UnitId && x.Status == ActiveStatus.Active, includeProduct).OrderBy(x => x.Id).FirstOrDefault();
                    ReceiptDetailModel receiptDetail = new ReceiptDetailModel
                    {
                        RequestItemId = item.RequestItemId,
                        ProductId = item.ProductId,
                        Amount = item.Amount,
                        Note = item.Note,
                        ProductCode = productDetail.Product.ProductCode,
                        ProductName = productDetail.Product.ProductName,
                        Product = item.Product,
                        ProductAmount = item.ProductAmount,
                        Quantity = item.Quantity,
                        Tax = item.Tax,
                        TaxAmount = item.TaxAmount,
                        UnitPrice = item.UnitPrice,
                        Unit = productDetail.Unit.UnitName,
                        UnitId = item.UnitId
                    };
                    details.Add(receiptDetail);
                }
                receipt.ReceiptDetails = details;
                return receipt;
            }
            return null;
        }

        public Request CreateRequest(RequestModel request, int userId)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<RequestItem> items = new List<RequestItem>();

            foreach(ReceiptDetailModel detail in request.ReceiptDetails)
            {
                items.Add(new RequestItem
                {
                    ProductId = detail.Product.ProductId,
                    Amount = detail.Amount,
                    Quantity = detail.Quantity,
                    ProductAmount = detail.ProductAmount,
                    Tax = detail.Tax,
                    TaxAmount = detail.TaxAmount,
                    UnitId = detail.UnitId,
                    UnitPrice = detail.UnitPrice,
                    Note = detail.Note,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                });
            }

            Request newRequest = new Request
            {
                VoucherNumber = request.VoucherNumber?? 0,
                BranchId = request.BranchId,
                StorageId = request.StorageId,
                SupplierId = request.SupplierId,
                BillNumber = request.BillNumber,
                DeliverName = request.DeliverName,
                DeliverPhone = request.DeliverPhone,
                ReceiverName = request.ReceiverName,
                ReceiverPhone = request.ReceiverPhone,
                ReceivingDay = request.ReceivingDay,
                PaymentMethod = request.PaymentMethod,
                TotalAmount = request.TotalAmount,
                Signature = request.Signature,
                Note = request.Note,
                RequestItemId = items,
                CreateDate = DateTime.Now,
                UserId = userId,
                CreateBy = userId,
                ModifyDate = DateTime.Now,
            };
            try
            {
                _unitOfWork.RequestRepository.Insert(newRequest);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
            } catch (Exception ex)
            {
                return null;
            }
            

            return newRequest;
        }

        public bool UpdateRequest(int requestId, RequestModel updatedRequest, int userId)
        {
            try
            {
                Request existingRequest = _unitOfWork.RequestRepository.GetByID(requestId);
                if (existingRequest == null)
                {
                    return false;
                }
                var updatedRequestItems = _unitOfWork.RequestItemRepository
                    .GetMany(rD => rD.RequestId == requestId).ToList();
                existingRequest.Note = updatedRequest.Note;
                existingRequest.PaymentMethod = updatedRequest.PaymentMethod;
                existingRequest.BranchId = updatedRequest.Branch.BranchId;
                existingRequest.StorageId = updatedRequest.Storage.StorageId;
                existingRequest.SupplierId = updatedRequest.Supplier.SupplierId;
                existingRequest.Note = updatedRequest.Note;
                foreach (var item in updatedRequest.ReceiptDetails)
                {
                    int index = updatedRequestItems.FindIndex(rD => rD.RequestItemId == item.RequestItemId);
                    if(index >= 0)
                    {
                        updatedRequestItems[index].ProductId = item.ProductId;
                        updatedRequestItems[index].ProductAmount = item.ProductAmount;
                        updatedRequestItems[index].UnitPrice = item.UnitPrice;
                        updatedRequestItems[index].Quantity = item.Quantity;
                        updatedRequestItems[index].UnitId = item.UnitId;
                        updatedRequestItems[index].Tax = item.Tax;
                        updatedRequestItems[index].TaxAmount = item.TaxAmount;
                        updatedRequestItems[index].Amount = item.Amount;
                        updatedRequestItems[index].ModifyDate = DateTime.Now;
                        updatedRequestItems[index].ModifyBy = userId;
                    } else
                    {
                        updatedRequestItems.Add(new RequestItem
                        {
                            ProductId = item.Product.ProductId,
                            Amount = item.Amount,
                            Quantity = item.Quantity,
                            ProductAmount = item.ProductAmount,
                            Tax = item.Tax,
                            TaxAmount = item.TaxAmount,
                            UnitId = item.UnitId,
                            UnitPrice = item.UnitPrice,
                            Note = item.Note,
                            CreateDate = DateTime.Now,
                            CreateBy = userId,
                            ModifyDate = DateTime.Now,
                            ModifyBy = userId,
                        });
                    }
                    
                }
                existingRequest.RequestItemId = updatedRequestItems;

                switch (updatedRequest.UpdateType)
                {
                    case -1:
                        existingRequest.Status = ReceiptStatus.TuChoi; 
                        break;
                    case 0:
                        existingRequest.Status = ReceiptStatus.ChoXuLy;
                        break;
                    case 1:
                        existingRequest.Status = ReceiptStatus.DaDuyet;
                        break;
                }

                _unitOfWork.RequestRepository.Update(existingRequest);
                _unitOfWork.Save();
                _unitOfWork.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool DeleteRequest(int requestId)
        {
            var request = _unitOfWork.RequestRepository.GetByID(requestId);
            if (request == null)
            {
                return false;
            }

            _unitOfWork.RequestRepository.Delete(request);
            _unitOfWork.Save();

            return true;
        }
    }
}