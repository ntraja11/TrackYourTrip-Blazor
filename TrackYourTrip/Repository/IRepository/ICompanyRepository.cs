using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync(Expression<Func<Company, bool>>? filter = null, string? includeProperties = null);
        Task<Company> GetAsync(int companyId, bool noTracking = false);
        Task<Company> GetByNameAsync(string name, bool noTracking = false);
        
        Task<Company> CreateAsync(Company company);
        Task<Company> UpdateAsync(Company company);
        Task<bool> DeleteAsync(int companyId);
    }
}
