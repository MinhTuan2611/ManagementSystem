using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.MainApp.Dtos;

namespace ManagementSystem.MainApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map customer information
            CreateMap<Customer, NewCustomerRequestDto>().ReverseMap();
            CreateMap<Customer, CustomerResponseDto>().ReverseMap();
        }
    }
}
