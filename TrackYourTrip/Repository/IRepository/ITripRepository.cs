using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllAsync(Expression<Func<Trip, bool>>? filter = null, string? includeProperties = null);
        Task<Trip> GetAsync(int tripId, bool noTracking = false);
        Task<Trip> CreateAsync(Trip trip);
        Task<Trip> UpdateAsync(Trip trip);
        Task<bool> DeleteAsync(int tripId);
    }
}
