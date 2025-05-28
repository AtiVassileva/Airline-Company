using System.ComponentModel.DataAnnotations;
using AirlineCompany.Web.Attributes;

namespace AirlineCompany.Web.Models
{
    public class ReportFilterModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime From { get; set; } = DateTime.Today.AddDays(-30);

        [Required]
        [DataType(DataType.Date)]
        [ArrivalAfterDeparture("From")]
        public DateTime To { get; set; } = DateTime.Today;

        public List<FlightReportViewModel> Results { get; set; } = new();
    }
}