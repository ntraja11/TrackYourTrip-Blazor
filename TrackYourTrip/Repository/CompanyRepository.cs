using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using TrackYourTrip.Data;
using TrackYourTrip.Data.Entities;
using TrackYourTrip.Repository.IRepository;

namespace TrackYourTrip.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly TrackYourTripDbContext _db;
        public CompanyRepository(TrackYourTripDbContext db)
        {
            _db = db;
        }

        public async Task<Company> CreateAsync(Company company)
        {
            await _db.Companies.AddAsync(company);
            await _db.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteAsync(int companyId)
        {
            var company = await _db.Companies.FirstOrDefaultAsync(t => t.Id == companyId);
            if (company is not null)
            {
                _db.Companies.Remove(company);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Company> GetByNameAsync(string name)
        {
            IQueryable<Company> query = _db.Companies;

            var company = await query.FirstOrDefaultAsync(t => t.Name == name);

            return company ?? new Company();
        }

        public async Task<Company> GetAsync(int companyId, bool noTracking = false)
        {
            IQueryable<Company> query = _db.Companies;

            //if (noTracking)
            //{
            //    query = query.AsNoTracking();
            //}


            var company = await query.FirstOrDefaultAsync(t => t.Id == companyId);

            return company ?? new Company();
        }               

        public async Task<Company> UpdateAsync(Company company)
        {
            _db.Companies.Update(company);
            await _db.SaveChangesAsync();

            return company;
        }
                

        public async Task<IEnumerable<Company>> GetAllAsync(Expression<Func<Company, bool>>? filter = null,
            string? includeProperties = null)
        {
            return await GetQuery(filter, includeProperties);
        }


        private async Task<IEnumerable<Company>> GetQuery(Expression<Func<Company, bool>>? filter, string? includeProperties)
        {
            IQueryable<Company> query = _db.Set<Company>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }

            return await query.ToListAsync();
        }

        
    }
}
