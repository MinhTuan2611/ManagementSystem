using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

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

        public (List<Customer>, int) GetListCustomers(string? customerName, string? phoneNumber, int pageSize, int pageNumber)
        {
            try
            {
                IEnumerable<Customer> customers;

                bool isDiacriticsCusomterName = false;
                string cusomterNameNonDiacritics = string.Empty;
                if (!String.IsNullOrEmpty(customerName))
                {
                    cusomterNameNonDiacritics = RemoveDiacritics(customerName);
                    isDiacriticsCusomterName  = customerName != cusomterNameNonDiacritics ? true : false;
                }

                if (!String.IsNullOrEmpty(customerName) && !String.IsNullOrEmpty(phoneNumber))
                {
                    if (isDiacriticsCusomterName == true)
                        customers = _unitOfWork.CustomerRepository.GetAll().Where(c => c.CustomerName.Contains(customerName, StringComparison.CurrentCultureIgnoreCase) && c.CustomerCode.Contains(phoneNumber) && c.IsActive.Equals(true));
                    else
                        customers = _unitOfWork.CustomerRepository.GetAll().Where(c => c.CustomerUnsign.Contains(cusomterNameNonDiacritics, StringComparison.CurrentCultureIgnoreCase) && c.CustomerCode.Contains(phoneNumber) && c.IsActive.Equals(true));
                }
                else if (!String.IsNullOrEmpty(customerName))
                {
                    if (isDiacriticsCusomterName == true)
                        customers = _unitOfWork.CustomerRepository.GetAll().Where(c => c.CustomerName.Contains(customerName, StringComparison.CurrentCultureIgnoreCase) && c.IsActive.Equals(true));
                    else
                        customers = _unitOfWork.CustomerRepository.GetAll().Where(c => c.CustomerUnsign.Contains(cusomterNameNonDiacritics, StringComparison.CurrentCultureIgnoreCase) && c.IsActive.Equals(true));
                }
                else if (!String.IsNullOrEmpty(phoneNumber))
                {
                    customers = _unitOfWork.CustomerRepository.GetAll().Where(c => c.CustomerCode.Contains(phoneNumber) && c.IsActive.Equals(true));
                }
                else
                    customers = _unitOfWork.CustomerRepository.GetAll().Where(c => c.IsActive.Equals(true));

                return (customers.OrderBy(c => c.CustomerName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(), customers.Count());
            }
            catch (Exception ex)
            {
                return (null, 0);
            }
        }

        public string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
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
        public bool UpdateCustomer(Customer customer, int actionUserId)
        {
            try
            {
                string query = string.Format(@"
                dbo.usp_update_customer
                    @ModifierId = {0},
                    @CustomerId = {1},
                    @CustomerCode = '{2}',
                    @CustomerName = '{3}',
                    @CustomerPoint = {4},
                    @Address = '{5}',
                    @PhoneNumber = '{6}'
            ", actionUserId, customer.CustomerId, customer.CustomerCode, customer.CustomerName, customer.CustomerPoint, customer.Address, customer.PhoneNumber);

                var result = _storageContext.Database.ExecuteSqlRaw(query);

                return result == 1;
            }
            catch (Exception ex)
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
                EXEC sp_search_customer_by_term N'{0}'
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
