using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class PaymentMethodsService
    {
        private readonly UnitOfWork _unitOfWork;
        public PaymentMethodsService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
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
            } catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
