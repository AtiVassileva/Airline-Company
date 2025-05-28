using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlineCompany.Web.Models
{
    public class ReservationFormModel
    {
        public Guid FlightId { get; set; }

        [Required(ErrorMessage = "Моля, въведете собствено име!")]
        [Display(Name = "Собствено име*")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Бащино име")]
        public string? MiddleName { get; set; }

        [Display(Name = "Фамилия*")]
        [Required(ErrorMessage = "Моля, въведете фамилия!")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Дата на раждане*")]
        public DateTime DateOfBirth { get; set; } = DateTime.Today;

        [Display(Name = "Номер на лична карта*")]
        [Required(ErrorMessage = "Моля, номер на лична карта!")]
        public string PersonalIdNumber { get; set; } = null!;

        [Display(Name = "Националност*")]
        [Required(ErrorMessage = "Моля, въведете националност!")]
        public string Nationality { get; set; } = null!;

        [Display(Name = "Вид билет*")]
        public Guid TicketId { get; set; }

        [Display(Name = "Вид багаж*")]
        public Guid LuggageId { get; set; }

        public List<SelectListItem> TicketTypes { get; set; } = new();
        public List<SelectListItem> LuggageTypes { get; set; } = new();
    }
}