using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class BillsService
    {
        private readonly UnitOfWork _unitOfWork;
        public BillsService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<ListBillResponse> GetListBills()
        {
            string[] includes = { "Customer" };
            List<ListBillResponse> bills = _unitOfWork.BillRepository.GetWithInclude(x => true, includes).Select(bill => new ListBillResponse 
            { 
                BillId = bill.BillId,
                TotalAmount = bill.totalAmount,
                CustomerId = bill.CustomerId,
                CustomerName = bill.Customer != null ? bill.Customer!.CustomerName : string.Empty ,
                CreateDate = bill.CreateDate,
            }).ToList();
            return bills;
        }

        public bool CreateBill(BillInfo bill)
        {
            try
            {
                var newBill = new Bill
                {
                    totalAmount = bill.totalAmount,
                    totalPaid = bill.totalPaid,
                    totalChange = bill.totalChange,
                    CustomerId = bill.CustomerId
                };
                _unitOfWork.BillRepository.Insert(newBill);
                _unitOfWork.Save();
                
                foreach (PaymentDetail detail in bill.Payments)
                {
                    var paymentMethod = _unitOfWork.PaymentMethodRepository.GetFirst(x => x.PaymentMethodCode == detail.PaymentMethodCode);
                    var newPaymentDetail = new BillPayment
                    {
                        BillId = newBill.BillId,
                        PaymentMethodId = paymentMethod.PaymentMethodId,
                        Amount = detail.Amount,
                        PaymentMethod = paymentMethod,
                        Bill = newBill,
                    };
                    _unitOfWork.BillPaymentRepository.Insert(newPaymentDetail);
                    _unitOfWork.Save();
                }
                foreach (BillDetailInfo detail in bill.Details)
                {
                    var product = _unitOfWork.ProductRepository.GetByID(detail.ProductId);
                    var unit = _unitOfWork.UnitRepository.GetByID(detail.UnitId);
                    var newDetail = new BillDetail
                    {
                        BillId = newBill.BillId,
                        ProductId = detail.ProductId,
                        UnitId = detail.UnitId,
                        DiscountAmount = detail.DiscountAmount,
                        DiscountPercentage = detail.DiscountPercentage,
                        DiscountByPercentage = detail.DiscountByPercentage,
                        Quantity = detail.Quantity,
                        Amount = detail.Amount,
                        Bill = newBill,
                        Product = product,
                        Unit = unit
                    };
                    _unitOfWork.BillDetailRepository.Insert(newDetail);
                    _unitOfWork.Save();
                }
                _unitOfWork.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
