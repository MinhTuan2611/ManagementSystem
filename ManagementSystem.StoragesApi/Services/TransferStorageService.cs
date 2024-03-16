using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class TransferStorageService
    {
        private readonly StoragesDbContext _context;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public TransferStorageService(StoragesDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<Transfer> GetListTransfer()
        {
            try
            {
                var transfer = _context.Transfer
                .Include(r => r.Branch)
                .Include(r => r.Supplier)
                .Include(r => r.StoreIn)
                .Include(r => r.StoreOut)
                .ToList();

                return transfer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Transfer GetTramsferById(int transferId)
        {
            try
            {
                var transfer = _context.Transfer
               .Include(r => r.Branch)
                .Include(r => r.Supplier)
                .Include(r => r.StoreIn)
                .Include(r => r.StoreOut)
                .FirstOrDefault(r => r.TransferId == transferId);

                var transferItems = _context.TransferItem.Include(i => i.Product).Include(i => i.Unit).Where(i => i.TransferId == transferId).ToList();

                transfer.TransferItems = transferItems;

                return transfer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Transfer CreateTransfer(TransferModel transfer)
        {
            if (transfer == null)
            {
                throw new ArgumentNullException(nameof(transfer));
            }
            try
            {
                Transfer newTransfer = new Transfer
                {
                    VoucherNumber = (int)transfer.VoucherNumber,
                    BranchId = transfer.BranchId,
                    StoreInId = transfer.StoreInId,
                    StoreOutId = transfer.StoreOutId,
                    SupplierId = 1,
                    BillNumber = transfer.BillNumber,
                    DeliverName = transfer.DeliverName,
                    DeliverPhone = transfer.DeliverPhone,
                    ReceiverName = transfer.ReceiverName,
                    ReceiverPhone = transfer.ReceiverPhone,
                    Status = TransferStatus.Created,
                };
                var transferItems = new List<TransferItem>();

                foreach (var i in transfer.TransferItems)
                {

                    TransferItem newTransferItem = new TransferItem
                    {
                        TransferId = newTransfer.TransferId,
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        UnitId = i.UnitId,
                        Note = i.Note,
                    };

                    transferItems.Add(newTransferItem);
                }

                newTransfer.TransferItems = transferItems;
                _context.Transfer.Add(newTransfer);
                _context.SaveChanges();

                return newTransfer;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool UpdateTransfer(int transferId, TransferModel updatedTransfer)
        {
            var existingTransfer = _unitOfWork.TransferRepository.GetByID(transferId);
            if (existingTransfer == null)
            {
                return false;
            }

            if (updatedTransfer.Status == TransferStatus.Created)
            {
                try
                {
                    existingTransfer.DeliverName = updatedTransfer.DeliverName;
                    existingTransfer.DeliverPhone = updatedTransfer.DeliverPhone;
                    existingTransfer.ReceiverName = updatedTransfer.ReceiverName;
                    existingTransfer.ReceiverPhone = updatedTransfer.ReceiverPhone;
                    existingTransfer.Status = TransferStatus.Transporting;
                    existingTransfer.ModifyDate = DateTime.Now;
                    existingTransfer.ExportingDay = DateTime.Now;

                    var transferItems = _context.TransferItem.Include(i => i.Product).Include(i => i.Unit).Where(i => i.TransferId == transferId).ToList();

                    foreach (var i in transferItems)
                    {
                        var itemExisting = _context.TransferItem.FirstOrDefault(ti => ti.TransferItemId == i.TransferItemId);
                        foreach (var j in updatedTransfer.TransferItems)
                        {
                            if (itemExisting.TransferItemId == j.TransferItemId)
                            {
                                itemExisting.Quantity = j.Quantity;
                                itemExisting.Note = j.Note;
                                itemExisting.ModifyDate = DateTime.Now;

                                var productStorageIn = _context.ProductStorages.FirstOrDefault(p => p.ProductId == j.ProductId && p.StorageId == existingTransfer.StoreInId);
                                if (productStorageIn != null)
                                {
                                    productStorageIn.Quantity = productStorageIn.Quantity + j.Quantity;
                                }

                                var productStorageOut = _context.ProductStorages.FirstOrDefault(p => p.ProductId == j.ProductId && p.StorageId == existingTransfer.StoreInId);
                                if (productStorageOut != null)
                                {
                                    productStorageOut.Quantity = productStorageIn.Quantity - j.Quantity;
                                }

                            }
                        }
                    }
                    _context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (updatedTransfer.Status == TransferStatus.Transporting)
            {
                try
                {
                    existingTransfer.ReceiverName = updatedTransfer.ReceiverName;
                    existingTransfer.ReceiverPhone = updatedTransfer.ReceiverPhone;
                    existingTransfer.Status = TransferStatus.Receive;
                    existingTransfer.ModifyDate = DateTime.Now;
                    existingTransfer.ReceivingDay = DateTime.Now;

                    var transferItems = _context.TransferItem.Include(i => i.Product).Include(i => i.Unit).Where(i => i.TransferId == transferId).ToList();

                    foreach (var i in transferItems)
                    {
                        var itemExisting = _context.TransferItem.FirstOrDefault(ti => ti.TransferItemId == i.TransferItemId);
                        foreach (var j in updatedTransfer.TransferItems)
                        {
                            if (itemExisting.TransferItemId == j.TransferItemId)
                            {
                                itemExisting.Quantity = j.Quantity;
                                itemExisting.ActualQuantity = j.ActualQuantity;
                                itemExisting.Note = j.Note;
                                itemExisting.ModifyDate = DateTime.Now;

                                var productStorageIn = _context.ProductStorages.FirstOrDefault(p => p.ProductId == j.ProductId && p.StorageId == existingTransfer.StoreInId);
                                if (productStorageIn != null)
                                {
                                    productStorageIn.Quantity = productStorageIn.Quantity + j.ActualQuantity;
                                }

                                var productStorageOut = _context.ProductStorages.FirstOrDefault(p => p.ProductId == j.ProductId && p.StorageId == existingTransfer.StoreOutId);
                                if (productStorageOut != null)
                                {
                                    productStorageOut.Quantity = productStorageOut.Quantity - j.ActualQuantity;
                                }
                            }
                        }
                    }

                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return false;
        }

        public bool UpdateStatusTransfer(int id, TransferStatus transferStatus)
        {
            var existingTransfer = _unitOfWork.TransferRepository.GetByID(id);
            if (existingTransfer == null)
            {
                return false;
            }

            try
            {
                existingTransfer.Status = transferStatus;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteTransfer(int transferId)
        {
            var transfer = _unitOfWork.TransferRepository.GetByID(transferId);
            if (transfer == null)
            {
                return false;
            }

            _unitOfWork.TransferRepository.Delete(transfer);
            _unitOfWork.Save();

            return true;
        }
    }
}