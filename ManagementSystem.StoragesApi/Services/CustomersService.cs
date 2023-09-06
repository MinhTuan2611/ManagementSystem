using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class CustomersService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomersService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<Customer> GetListCustomers()
        {
            List<Customer> customers = _unitOfWork.CustomerRepository.GetAll().ToList();
            return customers;
        }
        public Customer GetCustomerByCode(string customerCode)
        {
            Customer customer = _unitOfWork.CustomerRepository.Get(x => x.CustomerCode == customerCode);
            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            try
            {
                _unitOfWork.CustomerRepository.Insert(customer);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return customer;
            } catch (Exception ex)
            {
                return null;
            }
            
        }
        public bool UpdateCustomer(Customer customer, int userId)
        {
            customer.ModifyDate = DateTime.Now;
            customer.ModifyBy = userId;
            try
            {
                _unitOfWork.CustomerRepository.Update(customer);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            try
            {
                _unitOfWork.CustomerRepository.Delete(customerId);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
