using AirlineCompany.Data;
using AirlineCompany.Models;
using AirlineCompany.Services;
using AirlineCompany.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static AirlineCompany.Web.Common.CommonConstants;

namespace AirlineCompany.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void RegisterServicesCollection(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddTransient<IActivityLogService, ActivityLogService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IDestinationService, DestinationService>()
                .AddTransient<IPlaneService, PlaneService>()
                .AddTransient<IFlightService, FlightService>()
                .AddTransient<ITicketTypeService, TicketTypeService>()
                .AddTransient<ILuggageTypeService, LuggageTypeService>()
                .AddTransient<IStatusService, StatusService>()
                .AddTransient<IReservationService, ReservationService>()
                .AddTransient<IReportService, ReportService>();
        }

        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            var dbContext = serviceProvider.GetRequiredService<AirFlyDbContext>();

            MigrateDatabase(dbContext);

            SeedTicketTypes(dbContext);
            SeedStatuses(dbContext);
            SeedLuggageTypes(dbContext);

            await SeedRolesAsync(serviceProvider);

            return app;
        }

        private static void MigrateDatabase(AirFlyDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }

        private static void SeedTicketTypes(AirFlyDbContext dbContext)
        {
            if (dbContext.TicketTypes.Any())
            {
                return;
            }

            var tickets = new List<TicketType>
            {
                new() {Name = "Първа класа"},
                new() {Name = "Бизнес класа"},
                new() {Name = "Редовен"},
            };

            dbContext.TicketTypes.AddRange(tickets);
            dbContext.SaveChanges();
        }

        private static void SeedStatuses(AirFlyDbContext dbContext)
        {
            if (dbContext.Statuses.Any())
            {
                return;
            }

            var statuses = new List<Status>
            {
                new() {Name = "Предстояща"},
                new() {Name = "Канселирана"},
                new() {Name = "Приключена"}
            };

            dbContext.Statuses.AddRange(statuses);
            dbContext.SaveChanges();
        }

        private static void SeedLuggageTypes(AirFlyDbContext dbContext)
        {
            if (dbContext.LuggageTypes.Any())
            {
                return;
            }

            var luggageTypes = new List<LuggageType>
            {
                new() { Name = "Ръчен", MaxWeight = 10, MaxHeight = 40, MaxDepth = 30},
                new() {Name = "Кабинен", MaxWeight = 20, MaxHeight = 80, MaxDepth = 60},
                new() {Name = "Чекиран", MaxWeight = 40, MaxHeight = 120, MaxDepth = 80},
            };

            dbContext.LuggageTypes.AddRange(luggageTypes);
            dbContext.SaveChanges();
        }

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = {UserRoleName, AdministratorRoleName};
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole {Name = roleName});
                }
            }

            const string adminEmail = "admin@abv.bg";
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin == null)
            {
                const string adminPassword = "admin123";

                var admin = new IdentityUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };

                var result = await userManager.CreateAsync(admin, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, AdministratorRoleName);
                }
            }
        }
    }
}