using AirlineCompany.Data;
using AirlineCompany.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AirlineCompany.Services
{
    public class ReservationStatusUpdaterService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

        public ReservationStatusUpdaterService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await UpdateStatusesAsync();
                await Task.Delay(_interval, stoppingToken);
            }
        }

        private async Task UpdateStatusesAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AirFlyDbContext>();
            var reservationService = scope.ServiceProvider.GetRequiredService<IReservationService>();
            var statusService = scope.ServiceProvider.GetRequiredService<IStatusService>();

            var finishedReservations = await reservationService.GetFinishedReservationsAsync();

            if (finishedReservations.Any())
            {
                var completedStatusId = await statusService.GetCompletedStatusId();

                foreach (var reservation in finishedReservations)
                {
                    reservation.StatusId = completedStatusId;
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}