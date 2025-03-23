using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface ITripRepository
    {
        IEnumerable<Trip> GetAll();
        Trip Get(int tripId);
        Trip Create(Trip trip);
        Trip Update(Trip trip);
        bool Delete(int tripId);
    }
}
