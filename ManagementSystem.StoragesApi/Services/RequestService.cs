using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class RequestService : IRequestService
    {
        private readonly UnitOfWork _unitOfWork;

        public RequestService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Request> GetListRequests()
        {
            return _unitOfWork.RequestRepository.GetAll();
        }

        public Request GetRequestById(int requestId)
        {
            return _unitOfWork.RequestRepository.GetById(requestId);
        }

        public Request CreateRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _unitOfWork.RequestRepository.Insert(request);
            _unitOfWork.Save();

            return request;
        }

        public bool UpdateRequest(int requestId, Request updatedRequest)
        {
            var existingRequest = _unitOfWork.RequestRepository.GetById(requestId);
            if (existingRequest == null)
            {
                return false;
            }

            // Update the properties of the existing request with the new values
            existingRequest.RequestName = updatedRequest.RequestName;
            existingRequest.BranchId = updatedRequest.BranchId;
            existingRequest.StorageId = updatedRequest.StorageId;
            existingRequest.Note = updatedRequest.Note;

            _unitOfWork.Save();

            return true;
        }

        public bool DeleteRequest(int requestId)
        {
            var request = _unitOfWork.RequestRepository.GetById(requestId);
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