using System;
using System.Collections.Generic;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;

namespace ManagementSystem.StoragesApi.Services
{
    public class RequestSampleService : IRequestSampleService
    {
        private readonly StoragesDbContext _context;

        public RequestSampleService(StoragesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RequestSample> GetListRequestSamples()
        {
            return _context.RequestSamples;
        }

        public RequestSample GetRequestSampleById(int requestId)
        {
            return _context.RequestSamples.Find(requestId);
        }

        public RequestSample CreateRequestSample(RequestSample request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _context.RequestSamples.Add(request);
            _context.SaveChanges();

            return request;
        }

        public bool UpdateRequestSample(int requestId, RequestSampleModel request)
        {
            RequestSample existingRequest = _context.RequestSamples.Find(requestId);
            if (existingRequest == null)
            {
                return false;
            }

            // Update the properties of the existing request with the new values
            existingRequest.RequestSampleName = request.Name;
            existingRequest.BranchId = request.Branch.BranchId;
            existingRequest.StorageId = request.Storage.StorageId;
            existingRequest.Note = request.Note;

            // Update the RequestSampleItem properties
            List<RequestSampleItem> sampleItems = new List<RequestSampleItem>(); ;
            foreach(RequestSampleItemModel sampleModel in request.Items)
            {
                sampleItems.Add(new RequestSampleItem
                {
                    RequestSampleItemId = sampleModel.Id,
                    ProductId = sampleModel.ProductId,
                    Quantity = sampleModel.Quantity,
                    UnitId = sampleModel.UnitId,
                    Note = sampleModel.Note,
                });
            }
            existingRequest.RequestSampleItemId = sampleItems;

            _context.SaveChanges();

            return true;
        }

        public bool DeleteRequestSample(int requestId)
        {
            var request = _context.RequestSamples.Find(requestId);
            if (request == null)
            {
                return false;
            }

            _context.RequestSamples.Remove(request);
            _context.SaveChanges();

            return true;
        }
    }
}