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
            IQueryable<Request> requests = _unitOfWork.RequestRepository.GetWithInclude(r => true, includes);
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

        public bool UpdateRequest(int requestId, Request updatedRequest)
        {
            var existingRequest = _unitOfWork.RequestRepository.GetByID(requestId);
            if (existingRequest == null)
            {
                return false;
            }

            // Update the properties of the existing request with the new values
            //existingRequest.RequestName = updatedRequest.RequestName;
            existingRequest.BranchId = updatedRequest.BranchId;
            existingRequest.StorageId = updatedRequest.StorageId;
            existingRequest.Note = updatedRequest.Note;

            _unitOfWork.Save();

            return true;
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