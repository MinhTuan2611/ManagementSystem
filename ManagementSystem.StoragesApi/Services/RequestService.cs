using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class RequestService
    {
        private readonly UnitOfWork _unitOfWork;

        public RequestService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<Request> GetListRequests()
        {
            return _unitOfWork.RequestRepository.GetAll();
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
            Request newRequest = new Request
            {
                VoucherNumber = request.VoucherNumber,
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
                CreditAccount = request.CreditAccount,
                CreditAmount = request.CreditAmount,
                DebitAccount = request.DebitAccount,
                DebitAmount = request.DebitAmount,
                CreateDate = DateTime.Now
            };
            _unitOfWork.RequestRepository.Insert(newRequest);
            _unitOfWork.Save();

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
            existingRequest.CreditAccount = updatedRequest.CreditAccount;
            existingRequest.CreditAmount = updatedRequest.CreditAmount;
            existingRequest.DebitAccount = updatedRequest.DebitAccount;
            existingRequest.DebitAmount = updatedRequest.DebitAmount;
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