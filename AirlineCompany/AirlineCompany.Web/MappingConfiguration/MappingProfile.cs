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

            CreateMap<Plane, PlaneFormModel>()
                .ForMember(dest => dest.PlaneModel, cfg => cfg.MapFrom(src => src.Model))
                .ReverseMap();

            CreateMap<Flight, FlightFormModel>().ReverseMap();
            CreateMap<Flight, FlightViewModel>()
                .ForMember(dest => dest.PlaneModel, cfg => cfg.MapFrom(src => src.Plane.Model))
                .ForMember(dest => dest.DepartureCity, cfg => cfg.MapFrom(src => src.DepartureDestination.CityName))
                .ForMember(dest => dest.ArrivalCity, cfg => cfg.MapFrom(src => src.ArrivalDestination.CityName));

            CreateMap<ReservationFormModel, Reservation>()
                .ForMember(dest => dest.Passenger, opt => opt.MapFrom(src => new Passenger
                {
                    FirstName = src.FirstName,
                    MiddleName = src.MiddleName,
                    LastName = src.LastName,
                    DateOfBirth = src.DateOfBirth,
                    PersonalIdNumber = src.PersonalIdNumber,
                    Nationality = src.Nationality
                }));

            CreateMap<Reservation, ReservationListViewModel>()
                .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.FlightNumber))
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.Flight.DepartureDestination.CityName))
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.Flight.ArrivalDestination.CityName))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.Flight.DepartureTime))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.Flight.ArrivalTime))
                .ForMember(dest => dest.PassengerFullName, opt => opt.MapFrom(src =>
                    $"{src.Passenger.FirstName} {src.Passenger.MiddleName} {src.Passenger.LastName}"))
                .ForMember(dest => dest.TicketType, opt => opt.MapFrom(src => src.TicketType.Name))
                .ForMember(dest => dest.LuggageType, opt => opt.MapFrom(src => src.LuggageType.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name));
        }
    }
}