using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Models.Common
{
    public class ModelConstants
    {
        public enum FlightStatus
        {
            [Display(Name = "Предстоящ")]
            Upcoming = 1,
            [Display(Name = "Отменен")]
            Cancelled = 2,
            [Display(Name = "В прогрес")]
            InProgress = 3,
            [Display(Name = "Приключил")]
            Finished = 4
        }
    }
}