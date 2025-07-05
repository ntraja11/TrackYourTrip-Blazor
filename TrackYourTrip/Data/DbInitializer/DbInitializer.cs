using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrackYourTrip.Utility;

namespace TrackYourTrip.Data.DbInitializer
{
    public class DbInitializer(IServiceProvider serviceProvider) : IDbInitializer
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;


        public async Task InitializeAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<TrackYourTripDbContext>();

                dbContext.Database.Migrate(); // Apply migrations and create DB if needed

                if (!await roleManager.RoleExistsAsync(StaticDetails.RoleAdmin))
                {
                    await roleManager.CreateAsync(new IdentityRole(StaticDetails.RoleUser));
                    await roleManager.CreateAsync(new IdentityRole(StaticDetails.RoleAdmin));
                }
                else
                {
                    Console.WriteLine("Roles already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error during role initialization: {ex.Message}");
            }
        }
    }
    
}
