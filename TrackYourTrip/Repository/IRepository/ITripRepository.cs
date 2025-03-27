using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface ITripRepository
    {
        public Task<IEnumerable<Trip>> GetAllAsync(Expression<Func<Trip, bool>>? filter = null, string? includeProperties = null);
        public Task<Trip> GetAsync(int tripId, bool noTracking = false);
        public Task<Trip> CreateAsync(Trip trip);
        public Task<Trip> UpdateAsync(Trip trip);
        public Task<bool> DeleteAsync(int tripId);
    }
}
