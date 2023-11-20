using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class CustomersService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _storageContext;

        public CustomersService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _storageContext = context;
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
            }
            catch (Exception ex)
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

        public List<CustomerResponseDto> GetCustomerBySearchTerm(string searchTerm)
        {
            string query = string.Format(@"
                EXEC sp_search_customer_by_term '{0}'
            ", searchTerm);

            try
            {
                var customers = _storageContext.customerResponseDtos.FromSqlRaw(query).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateCustomerPoint(int amount, int customerId, int usedPoint)
        {
            try
            {
                int customerPoint = (amount / StorageContant.ConventPoint) - usedPoint;

                string query = string.Format(@"
                        UPDATE dbo.Customers
                        SET CustomerPoint = CustomerPoint + ({0})
                        WHERE CustomerId = {1}
                    ", customerPoint, customerId);

                var result = _storageContext.Database.ExecuteSqlRaw(query);

                return result == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkExistCustomer(Customer customer)
        {
            var isExist = _unitOfWork.CustomerRepository.Get(x => x.CustomerCode == customer.CustomerCode);
            return isExist != null ;
        }

    }
}
