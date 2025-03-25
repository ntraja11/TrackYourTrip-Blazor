using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface ITripRepository
    {
        public Task<IEnumerable<Trip>> GetAllAsync();
        public Task<Trip> GetAsync(int tripId);
        public Task<Trip> CreateAsync(Trip trip);
        public Task<Trip> UpdateAsync(Trip trip);
        public Task<bool> DeleteAsync(int tripId);
    }
}
