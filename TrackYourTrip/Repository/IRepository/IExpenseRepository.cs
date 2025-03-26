using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Expense>> GetAllAsync(Expression<Func<Expense, bool>>? filter = null, string? includeProperties = null);
        public Task<Expense> GetAsync(int vehicleId);
        public Task<Expense> CreateAsync(Expense vehicle);
        public Task<Expense> UpdateAsync(Expense vehicle);
        public Task<bool> DeleteAsync(int vehicleId);
    }
}
