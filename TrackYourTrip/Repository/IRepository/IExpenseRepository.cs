using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync(Expression<Func<Expense, bool>>? filter = null, string? includeProperties = null);
        Task<Expense> GetAsync(int vehicleId);
        Task<Expense> CreateAsync(Expense vehicle);
        Task<Expense> UpdateAsync(Expense vehicle);
        Task<bool> DeleteAsync(int vehicleId);
    }
}
