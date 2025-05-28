using AirlineCompany.Models;

namespace AirlineCompany.Services.Contracts
{
    public interface IReportService
    {
        byte[] ExportToCsvAsync(List<Flight> flights);
        byte[] ExportToExcelAsync(List<Flight> flights);
    }
}