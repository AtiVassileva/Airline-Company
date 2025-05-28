using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using System.Text;
using ClosedXML.Excel;

namespace AirlineCompany.Services
{
    public class ReportService : IReportService
    {
        public byte[] ExportToCsvAsync(List<Flight> flights)
        {
            var csv = new StringBuilder();
            csv.AppendLine("\uFEFFНомер на полет,От,До,Излитане,Кацане,Активни резервации,Отменени резервации,Общо резервации");

            foreach (var flight in flights)
            {
                csv.AppendLine($"{flight.FlightNumber}," +
                               $"{flight.DepartureDestination.CityName}," +
                               $"{flight.ArrivalDestination.CityName}," +
                               $"{flight.DepartureTime.ToString("dd.MM.yyyy HH:mm")}," +
                               $"{flight.ArrivalTime.ToString("dd.MM.yyyy HH:mm")}," +
                               $"{flight.Reservations.Count(r => !r.IsCancelled)}," +
                               $"{flight.Reservations.Count(r => r.IsCancelled)}," +
                               $"{flight.Reservations.Count},");
            }

            var file = Encoding.UTF8.GetBytes(csv.ToString());

            return file;
        }

        public byte[] ExportToExcelAsync(List<Flight> flights)
        {
            using var workbook = new XLWorkbook();

            var sheet = workbook.Worksheets.Add("Справка за полети");

            sheet.Cell(1, 1).Value = "Номер на полет";
            sheet.Cell(1, 2).Value = "От";
            sheet.Cell(1, 3).Value = "До";
            sheet.Cell(1, 4).Value = "Излитане";
            sheet.Cell(1, 5).Value = "Кацане";
            sheet.Cell(1, 6).Value = "Активни резервации";
            sheet.Cell(1, 7).Value = "Отменени резервации";
            sheet.Cell(1, 8).Value = "Общо резервации";

            var row = 2;

            foreach (var f in flights)
            {
                sheet.Cell(row, 1).Value = f.FlightNumber;
                sheet.Cell(row, 2).Value = f.DepartureDestination.CityName;
                sheet.Cell(row, 3).Value = f.ArrivalDestination.CityName;
                sheet.Cell(row, 4).Value = f.DepartureTime.ToString("dd.MM.yyyy HH:mm");
                sheet.Cell(row, 5).Value = f.ArrivalTime.ToString("dd.MM.yyyy HH:mm");
                sheet.Cell(row, 6).Value = f.Reservations.Count(r => !r.IsCancelled);
                sheet.Cell(row, 7).Value = f.Reservations.Count(r => r.IsCancelled);
                sheet.Cell(row, 8).Value = f.Reservations.Count;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}