using System;
using System.Collections.Generic;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos.RequestSamples;
using ManagementSystem.StoragesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class RequestSampleService : IRequestSampleService
    {
        private readonly StoragesDbContext _context;

        public RequestSampleService(StoragesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ResponseSampleDto> GetListRequestSamples()
        {
            var samples = _context.RequestSamples
                                .AsNoTracking()
                                .Include(x => x.Supplier)
                                .Include(x => x.RequestSampleItems)
                                    .ThenInclude(item => item.Unit)
                                .Include(x => x.RequestSampleItems)
                                   .ThenInclude(item => item.Product)
                                .ToList();

            var result = new List<ResponseSampleDto>();

            foreach (var sample in samples)
            {
                ResponseSampleDto sampleDto = new ResponseSampleDto()
                {
                    RequestSampleId = sample.RequestSampleId,
                    RequestSampleName = sample.RequestSampleName,
                    SupplierId = sample.SupplierId,
                    SupplierName = sample.Supplier.SupplierName,
                    DisplayName = sample.Supplier.DisplayName,
                    Phone = sample.Supplier.Phone,
                    Address = sample.Supplier.Address
                };

                List<ResponseSampleItemDto> sampleItems = new List<ResponseSampleItemDto> ();
                foreach(var item in sample.RequestSampleItems)
                {
                    var sampleItem = new ResponseSampleItemDto()
                    {
                         ProductId = item.ProductId,
                         ProductName = item.Product?.ProductName,
                         UnitId = item.UnitId,
                         UnitName = item.Unit?.UnitName
                    };
                    sampleItems.Add(sampleItem);
                }

                sampleDto.ResponseSampleItemDto = sampleItems;
                result.Add(sampleDto);

            }
            return result;
        }

        public async Task<ResponseSampleDto> GetRequestSampleById(int requestId)
        {
            var sample = _context.RequestSamples
                                .AsNoTracking()
                                .Include(x => x.Supplier)
                                .Include(x => x.RequestSampleItems)
                                    .ThenInclude(item => item.Unit)
                                .Include(x => x.RequestSampleItems)
                                   .ThenInclude(item => item.Product)
                                .FirstOrDefault(x => x.RequestSampleId == requestId);

            ResponseSampleDto sampleDto = new ResponseSampleDto()
            {
                RequestSampleId = sample.RequestSampleId,
                RequestSampleName = sample.RequestSampleName,
                SupplierId = sample.SupplierId,
                SupplierName = sample.Supplier.SupplierName,
                DisplayName = sample.Supplier.DisplayName,
                Phone = sample.Supplier.Phone,
                Address = sample.Supplier.Address
            };

            List<ResponseSampleItemDto> sampleItems = new List<ResponseSampleItemDto>();
            foreach (var item in sample.RequestSampleItems)
            {
                var sampleItem = new ResponseSampleItemDto()
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product.ProductName,
                    UnitId = item.UnitId,
                    UnitName = item.Unit.UnitName
                };
                sampleItems.Add(sampleItem);
            }

            sampleDto.ResponseSampleItemDto = sampleItems;

            return sampleDto;
        }

        public async Task<RequestSample> CreateRequestSample(RequestSample request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                var sample = new RequestSample()
                {
                    RequestSampleName = request.RequestSampleName,
                    SupplierId = request.SupplierId,
                    RequestSampleNote = request.RequestSampleNote,
                    Status = ActiveStatus.Active,
                    UserId = request.UserId,
                    CreateBy = request.CreateBy,
                    ModifyBy = request.ModifyBy,
                };

                await _context.RequestSamples.AddAsync(sample);
                await _context.SaveChangesAsync();

                // Save sample request items
                foreach (var item in request.RequestSampleItems)
                {
                    var sampleItem = new RequestSampleItem()
                    {
                        RequestSampleId = sample.RequestSampleId,
                        UnitId = item.UnitId,
                        ProductId = item.ProductId,
                        ItemNote = item.ItemNote,
                        CreateBy = request.CreateBy,
                        ModifyBy = request.ModifyBy,
                    };
                    await _context.RequestSampleItems.AddAsync(sampleItem);
                }
                await _context.SaveChangesAsync();

                // Add activity logs
                _context.ActivityLog.Add(new ActivityLog()
                {
                    UserId = request.UserId,
                    Action = "Create Sample: " + sample.RequestSampleId.ToString(),
                    Source = "RequestSample",
                    DateModified = DateTime.Now,
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return request;
        }

        public async Task<bool> UpdateRequestSample(RequestSample requestSample)
        {
            RequestSample existingRequest = await _context.RequestSamples
                                                         .Include(x => x.RequestSampleItems)
                                                        .FirstOrDefaultAsync(x => x.RequestSampleId == requestSample.RequestSampleId);
            if (existingRequest == null)
            {
                return false;
            }

            // Update Samples
            existingRequest.SupplierId = requestSample.SupplierId;
            existingRequest.RequestSampleName = requestSample.RequestSampleName;
            existingRequest.RequestSampleNote = requestSample.RequestSampleNote;
            existingRequest.ModifyBy = requestSample.ModifyBy;
            existingRequest.ModifyDate = DateTime.Now;

            _context.SaveChanges();

            // Clean all items
            _context.RequestSampleItems.RemoveRange(existingRequest.RequestSampleItems);

            // Save sample request items
            foreach (var item in requestSample.RequestSampleItems)
            {
                var sampleItem = new RequestSampleItem()
                {
                    RequestSampleId = requestSample.RequestSampleId,
                    UnitId = item.UnitId,
                    ProductId = item.ProductId,
                    ItemNote = item.ItemNote,
                    CreateBy = requestSample.CreateBy,
                    ModifyBy = requestSample.ModifyBy,
                };
                await _context.RequestSampleItems.AddAsync(sampleItem);
            }

            // Add activity logs
            _context.ActivityLog.Add(new ActivityLog()
            {
                UserId = requestSample.UserId,
                Action = "Update Sample: " + requestSample.RequestSampleId.ToString(),
                Source = "RequestSample",
                DateModified = DateTime.Now,
            });
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRequestSample(int requestId, int userId)
        {
            RequestSample existingRequest = await _context.RequestSamples
                                                         .Include(x => x.RequestSampleItems)
                                                        .FirstOrDefaultAsync(x => x.RequestSampleId == requestId);
            if (existingRequest == null)
            {
                return false;
            }

            existingRequest.Status = ActiveStatus.Inactive;

            // Clean all items
            _context.RequestSampleItems.RemoveRange(existingRequest.RequestSampleItems);

            // Add activity logs
            _context.ActivityLog.Add(new ActivityLog()
            {
                UserId = userId,
                Action = "Delete Sample: " + requestId.ToString(),
                Source = "RequestSample",
                DateModified = DateTime.Now,
            });
            await _context.SaveChangesAsync();

            return true;
        }
    }
}