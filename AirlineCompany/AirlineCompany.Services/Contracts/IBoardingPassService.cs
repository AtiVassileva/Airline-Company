using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IBoardingPassService
    {
        byte[] GeneratePdf(Reservation reservation);
    }
}