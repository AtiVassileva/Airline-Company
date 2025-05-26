using AirlineCompany.Models;
using AirlineCompany.Web.Models;
using AutoMapper;

namespace AirlineCompany.Web.MappingConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Destination, DestinationFormModel>()
                .ReverseMap();
        }
    }
}