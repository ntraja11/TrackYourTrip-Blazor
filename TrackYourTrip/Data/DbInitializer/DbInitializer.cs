using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrackYourTrip.Utility;

namespace TrackYourTrip.Data.DbInitializer
{
    public class DbInitializer(TrackYourTripDbContext db,
        RoleManager<IdentityRole> roleManager) : IDbInitializer
    {
        private readonly TrackYourTripDbContext _db = db;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public async Task InitializeAsync()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();

                    if (!await _roleManager.RoleExistsAsync(StaticDetails.RoleUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(StaticDetails.RoleUser));
                        await _roleManager.CreateAsync(new IdentityRole(StaticDetails.RoleAdmin));
                    }
                }                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during database migration: {ex.Message}");
            }
        }
    }
    
}
