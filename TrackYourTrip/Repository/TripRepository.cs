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

        public Trip Create(Trip trip)
        {
            _db.Trips.Add(trip);
            _db.SaveChanges();
            return trip;
        }

        public bool Delete(int tripId)
        {
            var trip = _db.Trips.FirstOrDefault(t => t.Id == tripId);
            if(trip is not null)
            {
                _db.Trips.Remove(trip);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public Trip Get(int tripId)
        {
            Trip trip = _db.Trips.FirstOrDefault(t => t.Id == tripId);

            if(trip is not null)
            {
                return trip;
            }
            else return new Trip();
        }

        public IEnumerable<Trip> GetAll()
        {
            return _db.Trips.ToList();
        }

        public Trip Update(Trip trip)
        {
            _db.Trips.Update(trip);
            _db.SaveChanges();

            return trip;
        }
    }
}
