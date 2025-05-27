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

            CreateMap<Flight, FlightFormViewModel>().ReverseMap();
            CreateMap<Flight, FlightViewModel>()
                .ForMember(dest => dest.PlaneModel, cfg => cfg.MapFrom(src => src.Plane.Model))
                .ForMember(dest => dest.DepartureCity, cfg => cfg.MapFrom(src => src.DepartureDestination.CityName))
                .ForMember(dest => dest.ArrivalCity, cfg => cfg.MapFrom(src => src.ArrivalDestination.CityName));
        }
    }
}