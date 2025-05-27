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

            CreateMap<Plane, PlaneFormViewModel>()
                .ForMember(dest => dest.PlaneModel, cfg => cfg.MapFrom(src => src.Model))
                .ReverseMap();
        }
    }
}