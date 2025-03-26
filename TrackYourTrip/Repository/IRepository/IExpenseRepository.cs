using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Expense>> GetAllAsync();
        public Task<Expense> GetAsync(int vehicleId);
        public Task<Expense> CreateAsync(Expense vehicle);
        public Task<Expense> UpdateAsync(Expense vehicle);
        public Task<bool> DeleteAsync(int vehicleId);
    }
}
