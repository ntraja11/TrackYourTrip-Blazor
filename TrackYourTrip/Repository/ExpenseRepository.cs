using Microsoft.EntityFrameworkCore;
using TrackYourTrip.Data;
using TrackYourTrip.Data.Entities;
using TrackYourTrip.Repository.IRepository;

namespace TrackYourTrip.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly TrackYourTripDbContext _db;
        public ExpenseRepository(TrackYourTripDbContext db)
        {
            _db = db;
        }

        public async Task<Expense> CreateAsync(Expense expense)
        {
            await _db.Expenses.AddAsync(expense);
            await _db.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> DeleteAsync(int expenseId)
        {
            var expense = await _db.Expenses.FirstOrDefaultAsync(t => t.Id == expenseId);
            if (expense is not null)
            {
                _db.Expenses.Remove(expense);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Expense> GetAsync(int expenseId)
        {
            var expense = await _db.Expenses.FirstOrDefaultAsync(t => t.Id == expenseId);

            if (expense is not null)
            {
                return expense;
            }
            else return new Expense();
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _db.Expenses.ToListAsync();
        }

        public async Task<Expense> UpdateAsync(Expense expense)
        {
            _db.Expenses.Update(expense);
            await _db.SaveChangesAsync();

            return expense;
        }
    }
}
