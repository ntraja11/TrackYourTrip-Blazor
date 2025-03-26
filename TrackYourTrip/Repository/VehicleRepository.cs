using Microsoft.EntityFrameworkCore;
using TrackYourTrip.Data;
using TrackYourTrip.Data.Entities;
using TrackYourTrip.Repository.IRepository;

namespace TrackYourTrip.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TrackYourTripDbContext _db;
        public VehicleRepository(TrackYourTripDbContext db)
        {
            _db = db;
        }    
      
        public async Task<Vehicle> GetAsync(int vehicleId)
        {
            var vehicle = await _db.Vehicles.FirstOrDefaultAsync(t => t.Id == vehicleId);

            if (vehicle is not null)
            {
                return vehicle;
            }
            else return new Vehicle();
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _db.Vehicles.ToListAsync();
        }     
    }
}
