using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
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

        public async Task<Trip> GetAsync(int tripId, bool noTracking = false)
        {
            IQueryable<Trip> query = _db.Trips.Include(v => v.Vehicle);

            //if (noTracking)
            //{
            //    query = query.AsNoTracking();
            //}


            var trip = await query.FirstOrDefaultAsync(t => t.Id == tripId);

            return trip ?? new Trip();
        }               

        public async Task<Trip> UpdateAsync(Trip trip)
        {
            _db.Trips.Update(trip);
            await _db.SaveChangesAsync();

            return trip;
        }
                

        public async Task<IEnumerable<Trip>> GetAllAsync(Expression<Func<Trip, bool>>? filter = null,
            string? includeProperties = null)
        {
            return await GetQuery(filter, includeProperties);
        }


        private async Task<IEnumerable<Trip>> GetQuery(Expression<Func<Trip, bool>>? filter, string? includeProperties)
        {
            IQueryable<Trip> query = _db.Set<Trip>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }

            return await query.ToListAsync();
        }
    }
}
