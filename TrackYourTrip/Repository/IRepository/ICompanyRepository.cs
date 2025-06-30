using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetAllAsync(Expression<Func<Company, bool>>? filter = null, string? includeProperties = null);
        public Task<Company> GetAsync(int CompanyId, bool noTracking = false);
        public Task<Company> GetByNameAsync(string name);
        public Task<Company> CreateAsync(Company Company);
        public Task<Company> UpdateAsync(Company Company);
        public Task<bool> DeleteAsync(int CompanyId);
    }
}
