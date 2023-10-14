using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Repositories.GenericRepository;
using ManagementSystem.Common;
using ManagementSystem.Common.Constants;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ManagementSystem.AccountingApi.Services
{
    public class LegerService : ILegerService
    {
        private readonly AccountingDbContext _context;
        public LegerService(AccountingDbContext context)
        {
            _context = context;
        }


        public async Task<List<LegerResponseDto>> GetAllLegerInformation(SearchCriteria searchModel)
        {

            try
            {
                string xmlString = XMLCommonFunction.SerializeToXml(searchModel);
                var result = _context.LegerResponseDtos.FromSqlRaw(string.Format("EXEC sp_SearchLegers '{0}', {1}, {2}", xmlString, searchModel.PageNumber, searchModel.PageSize)).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Leger> CreateLegers(Leger leger)
        {
            try
            {
                _context.Legers.Add(leger);
                await _context.SaveChangesAsync();

                return leger;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
