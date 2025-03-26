using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IVehicleRepository
    {
        public Task<IEnumerable<Vehicle>> GetAllAsync();
        public Task<Vehicle> GetAsync(int vehicleId);
    }
}
