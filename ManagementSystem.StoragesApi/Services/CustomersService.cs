using Dapper;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using ManagementSystem.StoragesApi.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace ManagementSystem.StoragesApi.Services
{
    public class CustomersService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _storageContext;
        private IConfiguration _configuration;

        public CustomersService(StoragesDbContext context, IConfiguration configuration)
        {
            _unitOfWork = new UnitOfWork(context);
            _storageContext = context;
            _configuration = configuration;
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

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = _unitOfWork.CustomerRepository.GetByID(customerId);
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
        public async Task<bool> UpdateCustomer(Customer customer, int actionUserId)
        {
            try
            {
                string actionUserRole = GetUserRole(actionUserId);

                if (String.IsNullOrEmpty(actionUserRole))
                    return false;

                if (actionUserRole == "NV" || actionUserRole == "NVTN")
                {
                    string updateQuery = string.Format(@"
                        update dbo.Customers
		                set CustomerName = N'{0}'
			                ,CustomerCode = N'{1}'
			                ,PhoneNumber = N'{2}'
			                ,[Address] = N'{3}'
                            ,Gender = N'{4}'
                            ,BirthDay = '{5}'
			                ,ModifyDate = getdate()
			                ,ModifyBy = {6}
		                where CustomerId = {7}
                            and IsActive = 1
                    ", customer.CustomerName, customer.CustomerCode, customer.PhoneNumber, customer.Address, customer.Gender, customer.BirthDay, actionUserId, customer.CustomerId);

                    var rowAffected = _storageContext.Database.ExecuteSqlRaw(updateQuery);
                    return rowAffected > 0;
                }

                if (actionUserRole == "QTV" || actionUserRole == "QL" || actionUserRole == "KT")
                {
                    string updateQuery = string.Format(@"
                        update dbo.Customers
		                set CustomerName = N'{0}'
			                ,CustomerCode = N'{1}'
			                ,PhoneNumber = N'{2}'
			                ,[Address] = N'{3}'
                            ,CustomerPoint = {4}
                            ,Gender = N'{5}'
                            ,BirthDay = '{6}'
			                ,ModifyDate = getdate()
			                ,ModifyBy = {7}
		                where CustomerId = {8}
                            and IsActive = 1
                    ", customer.CustomerName, customer.CustomerCode, customer.PhoneNumber, customer.Address, customer.CustomerPoint, customer.Gender, customer.BirthDay, actionUserId, customer.CustomerId);

                    var rowAffected = _storageContext.Database.ExecuteSqlRaw(updateQuery);
                    return rowAffected > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCustomer(int customerId, int actionUserId)
        {
            try
            {
                string actionUserRole = GetUserRole(actionUserId);

                if (String.IsNullOrEmpty(actionUserRole))
                    return false;

                if (actionUserRole != "QTV" && actionUserRole != "QL" || actionUserRole != "KT")
                    return false;

                if (actionUserRole == "QTV" || actionUserRole == "QL" || actionUserRole == "KT")
                {
                    string softDeleteQuery = string.Format(@"
                        update dbo.Customers
		                set IsActive = 0
		                where CustomerId = {0}
                    ", customerId);

                    var rowAffected = _storageContext.Database.ExecuteSqlRaw(softDeleteQuery);
                    return rowAffected > 0;
                }

                return false;
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

        private  string GetUserRole(int userId)
        {
            try
            {
                string accountingConnection = string.Format(_configuration.GetConnectionString("AccountsDbConnStr"), SD.AccountDbName);
                string getActionUserRole = @"
                    select top 1 r.RoleCode
                    from dbo.Roles as r
                    join dbo.UserRoles as ur on ur.RoleId = r.RoleId
                    where ur.UserId = @userId
                    order by ur.RoleId asc";

                string actionUserRole;
                using (var connection = new SqlConnection(accountingConnection))
                {
                    actionUserRole = connection.ExecuteScalar(getActionUserRole, new { userId }).ToString();
                }

                return actionUserRole;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
