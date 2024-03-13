using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class RequestService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _context;
        private readonly IMapper _mapper;

        public RequestService(StoragesDbContext context, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(context);
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Request> GetListRequests()
        {
            try
            {
                var requests = _context.Requests
                .Include(r => r.Branch)
                .Include(r => r.Supplier)
                .Include(r => r.Storage)
                .Include(r => r.PaymentMethod)
                .ToList();

                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Request GetRequestById(int requestId)
        {
            try
            {
                var request = _context.Requests
                .Include(r => r.Branch)
                .Include(r => r.Supplier)
                .Include(r => r.Storage)
                .Include(r => r.PaymentMethod)
                .FirstOrDefault(r => r.RequestId == requestId);
                var requestItems = _context.RequestItem.Include(i => i.Product).Include(i => i.Unit).Where(i => i.RequestId == requestId).ToList();
                request.RequestItemId = requestItems;

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Request CreateRequest(RequestModel request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            try
            {
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
                    PaymentMethodId = request.PaymentMethodId,
                    CreditAccount = request.CreditAccount,
                    CreditAmount = request.CreditAmount,
                    DebitAccount = request.DebitAccount,
                    DebitAmount = request.DebitAmount,
                    RequestStatus = Status.Pending,
                    CreateDate = DateTime.Now
                };


                _context.Requests.Add(newRequest);

                _context.SaveChanges();

                foreach (var i in request.RequestItemId)
                {

                    RequestItem newRequestItem = new RequestItem
                    {
                        RequestId = newRequest.RequestId,
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        UnitId = i.UnitId,
                        UnitPrice = i.UnitPrice,
                        Tax = i.Tax,
                        ProductAmount = i.ProductAmount,
                        TaxAmount = i.TaxAmount,
                        Note = i.Note,
                        Amount = i.Amount,
                        CreateDate = DateTime.Now
                    };
                    _context.RequestItem.Add(newRequestItem);

                    _context.SaveChanges();
                }


                // _unitOfWork.RequestRepository.Insert(newRequest);
                // _unitOfWork.Save();

                return newRequest;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateRequest(int requestId, RequestModel updatedRequest)
        {
            var existingRequest = _unitOfWork.RequestRepository.GetByID(requestId);
            if (existingRequest == null)
            {
                return false;
            }

            try
            {
                // Update the properties of the existing request with the new values
                //existingRequest.RequestName = updatedRequest.RequestName;
                existingRequest.SupplierId = updatedRequest.SupplierId;
                existingRequest.BranchId = updatedRequest.BranchId;
                existingRequest.StorageId = updatedRequest.StorageId;
                existingRequest.Note = updatedRequest.Note;
                existingRequest.DeliverName = updatedRequest.DeliverName;
                existingRequest.DeliverPhone = updatedRequest.DeliverPhone;
                existingRequest.ReceiverName = updatedRequest.ReceiverName;
                existingRequest.ReceiverPhone = updatedRequest.ReceiverPhone;
                existingRequest.CreditAccount = updatedRequest.CreditAccount;
                existingRequest.CreditAmount = updatedRequest.CreditAmount;
                existingRequest.DebitAccount = updatedRequest.DebitAccount;
                existingRequest.DebitAmount = updatedRequest.DebitAmount;
                existingRequest.ModifyDate = DateTime.Now;

                _context.SaveChanges();

                var requestItems = _context.RequestItem.Include(i => i.Product).Include(i => i.Unit).Where(i => i.RequestId == requestId).ToList();

                foreach(var i in requestItems) {           
                   var itemExisting = _context.RequestItem.FirstOrDefault(ri => ri.RequestItemId == i.RequestItemId);
                   foreach(var j in updatedRequest.RequestItemId) {
                        if (itemExisting.RequestItemId == j.RequestItemId)
                        {
                            itemExisting.Quantity = j.Quantity;
                            itemExisting.UnitPrice = j.UnitPrice;
                            itemExisting.Tax = j.Tax;
                            itemExisting.TaxAmount = j.TaxAmount;
                            itemExisting.Amount = j.Amount;
                            itemExisting.Note = j.Note;
                            itemExisting.ProductAmount = j.ProductAmount;
                            itemExisting.ModifyDate = DateTime.Now;

                            _context.SaveChanges();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateStatusRequest(int id, Status status)
        {
            var existingRequest = _unitOfWork.RequestRepository.GetByID(id);
            if (existingRequest == null)
            {
                return false;
            }

            try
            {
                existingRequest.RequestStatus = status;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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