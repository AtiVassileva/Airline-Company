using AirlineCompany.Models;
using AirlineCompany.Services.Contracts;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;  

namespace AirlineCompany.Services
{
    public class BoardingPassService : IBoardingPassService
    {
        public byte[] GeneratePdf(Reservation reservation)
        {
            var doc = new PdfDocument();

            void AddPage(string lang)
            {
                var page = doc.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                
                var fontPath = Path.Combine("Fonts", "arial.ttf"); 
                var font = new XFont("Arial", 14, XFontStyle.Regular);
                var titleFont = new XFont("Arial", 20, XFontStyle.Bold);

                var y = 40;
                
                gfx.DrawString("AirFly", new XFont("Arial", 72, XFontStyle.BoldItalic),
                    new XSolidBrush(XColor.FromArgb(20, 0, 0, 0)),
                    new XRect(0, 200, page.Width, page.Height),
                    XStringFormats.Center);
                
                gfx.DrawString(lang == "bg" ? "БОРДНА КАРТА" : "BOARDING PASS",
                    titleFont, XBrushes.DarkBlue, new XRect(0, y, page.Width, 0), XStringFormats.TopCenter);

                y += 50;
                
                var ticket = TranslateTicketType(reservation.TicketType.Name, lang);
                var luggage = TranslateLuggageType(reservation.LuggageType.Name, lang);
                var name = $"{reservation.Passenger.FirstName} {reservation.Passenger.MiddleName} {reservation.Passenger.LastName}";

                gfx.DrawString($"{(lang == "bg" ? "Пасажер" : "Passenger")}: {name}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "Дата на раждане" : "Date of Birth")}: {reservation.Passenger.DateOfBirth:dd.MM.yyyy}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "Националност" : "Nationality")}: {reservation.Passenger.Nationality}", font, XBrushes.Black, 40, y += 25);

                y += 15;
                gfx.DrawString($"{(lang == "bg" ? "Номер на полет" : "Flight No")}: {reservation.Flight.FlightNumber}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "От" : "From")}: {reservation.Flight.DepartureDestination.CityName}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "До" : "To")}: {reservation.Flight.ArrivalDestination.CityName}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "Излитане" : "Departure")}: {reservation.Flight.DepartureTime:dd.MM.yyyy HH:mm}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "Кацане" : "Arrival")}: {reservation.Flight.ArrivalTime:dd.MM.yyyy HH:mm}", font, XBrushes.Black, 40, y += 25);

                y += 15;
                gfx.DrawString($"{(lang == "bg" ? "Билет" : "Ticket")}: {ticket}", font, XBrushes.Black, 40, y += 25);
                gfx.DrawString($"{(lang == "bg" ? "Багаж" : "Luggage")}: {luggage}", font, XBrushes.Black, 40, y += 25);
            }
            
            AddPage("bg");
            AddPage("en");

            using var stream = new MemoryStream();
            doc.Save(stream, false);

            return stream.ToArray();
        }

        private string TranslateTicketType(string type, string lang) => lang switch
        {
            "bg" => type,
            "en" => type switch
            {
                "Редовен" => "Regular",
                "Бизнес класа" => "Business Class",
                "Първа класа" => "First Class",
                _ => type
            },
            _ => type
        };

        private string TranslateLuggageType(string type, string lang) => lang switch
        {
            "bg" => type,
            "en" => type switch
            {
                "Ръчен" => "Hand luggage",
                "Чекиран" => "Checked luggage",
                "Кабинен" => "Cabin luggage",
                _ => type
            },
            _ => type
        };
    }
}