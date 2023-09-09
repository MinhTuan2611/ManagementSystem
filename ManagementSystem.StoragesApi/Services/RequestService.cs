using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Common.Entities;
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
                    Note = request.Note,
                    UserId = request.UserId,
                    PaymentMethod = request.PaymentMethod,
                });
            }
            return list;
        }

        public Request GetRequestById(int requestId)
        {
            return _unitOfWork.RequestRepository.GetByID(requestId);
        }

        public Request CreateRequest(RequestModel request)
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
                BillNumber = Convert.ToInt32(request.BillNumber),
                DeliverName = request.DeliverName,
                DeliverPhone = request.DeliverPhone,
                ReceiverName = request.ReceiverName,
                ReceiverPhone = request.ReceiverPhone,
                ReceivingDay = request.ReceivingDay,
                PaymentMethod = request.PaymentMethod,
                Note = request.Note,
                RequestItemId = items,
                CreateDate = DateTime.Now,
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