using AutoMapper;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using ManagementSystem.Common.Models.Dtos.RequestSamples;

namespace ManagementSystem.StoragesApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer
            // Map customer information
            CreateMap<Customer, NewCustomerRequestDto>().ReverseMap();
            CreateMap<Customer, CustomerResponseDto>().ReverseMap();

            // Request Sample
            CreateMap<RequestSample, NewRequestSampleDto>().ReverseMap();
            CreateMap<RequestSample, UpdateRequestSampleDto>().ReverseMap();
            CreateMap<RequestSampleItem, RequestSampleItemDto>().ReverseMap();
            CreateMap<Request, RequestDTO>().ReverseMap();
            CreateMap<Transfer, TransferDTO>().ReverseMap();
        }
    }
}
