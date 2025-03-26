using Microsoft.EntityFrameworkCore;
using TrackYourTrip.Data;
using TrackYourTrip.Data.Entities;
using TrackYourTrip.Repository.IRepository;

namespace TrackYourTrip.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly TrackYourTripDbContext _db;
        public TripRepository(TrackYourTripDbContext db)
        {
            _db = db;
        }

        public async Task<Trip> CreateAsync(Trip trip)
        {
            await _db.Trips.AddAsync(trip);
            await _db.SaveChangesAsync();
            return trip;
        }

        public async Task<bool> DeleteAsync(int tripId)
        {
            var trip = await _db.Trips.FirstOrDefaultAsync(t => t.Id == tripId);
            if (trip is not null)
            {
                _db.Trips.Remove(trip);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Trip> GetAsync(int tripId)
        {
            var trip = await _db.Trips.Include(v => v.Vehicle).FirstOrDefaultAsync(t => t.Id == tripId);

            if (trip is not null)
            {
                return trip;
            }
            else return new Trip();
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
        {
            return await _db.Trips.ToListAsync();
        }

        public async Task<Trip> UpdateAsync(Trip trip)
        {
            _db.Trips.Update(trip);
            await _db.SaveChangesAsync();

            return trip;
        }
    }
}
