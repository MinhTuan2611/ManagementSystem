using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class PaymentMethodsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _context;

        public PaymentMethodsService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _context = context;
        }

        public List<PaymentMethod> GetListPaymentMethod()
        {
            List<PaymentMethod> paymentMethods = _unitOfWork.PaymentMethodRepository.GetAll().ToList();
            return paymentMethods;
        }
        public PaymentMethod CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            try
            {
                _unitOfWork.PaymentMethodRepository.Insert(paymentMethod);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return paymentMethod;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PaymentMethodDto GetPaymentByCode(string code)
        {
            var payment = _context.PaymentMethods.SingleOrDefault(x => x.PaymentMethodCode == code);

            if (payment != null)
            {
                var response = new PaymentMethodDto()
                {
                    PaymentMethodId = payment.PaymentMethodId,
                    PaymentMethodCode = payment.PaymentMethodCode,
                    PaymentMethodName = payment.PaymentMethodName
                };

                return response;
            }

            return null;
        }
    }
}
