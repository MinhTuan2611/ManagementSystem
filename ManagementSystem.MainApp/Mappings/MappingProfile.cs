using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.MainApp.Dtos;

namespace ManagementSystem.MainApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, NewCustomerRequestDto>().ReverseMap();
        }
    }
}
