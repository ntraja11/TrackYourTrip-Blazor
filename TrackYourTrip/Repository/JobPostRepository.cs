using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using TrackYourTrip.Data;
using TrackYourTrip.Data.Entities;
using TrackYourTrip.Repository.IRepository;

namespace TrackYourTrip.Repository
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly TrackYourTripDbContext _db;
        public JobPostRepository(TrackYourTripDbContext db)
        {
            _db = db;
        }

        public async Task<JobPost> CreateAsync(JobPost jobPost)
        {
            await _db.JobPosts.AddAsync(jobPost);
            await _db.SaveChangesAsync();
            return jobPost;
        }

        public async Task<bool> DeleteAsync(int jobPostId)
        {
            var jobPost = await _db.JobPosts.FirstOrDefaultAsync(t => t.Id == jobPostId);
            if (jobPost is not null)
            {
                _db.JobPosts.Remove(jobPost);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<JobPost>> GetAllAsync(Expression<Func<JobPost, bool>>? filter = null,
            string? includeProperties = null)
        {
            return await GetQuery(filter, includeProperties);
        }

        public async Task<JobPost> GetAsync(int jobPostId, bool noTracking = false)
        {
            IQueryable<JobPost> query = _db.JobPosts;
            
            var jobPost = await query.FirstOrDefaultAsync(t => t.Id == jobPostId);

            return jobPost ?? new JobPost();
        }               

        public async Task<JobPost> UpdateAsync(JobPost jobPost)
        {
            _db.JobPosts.Update(jobPost);
            await _db.SaveChangesAsync();

            return jobPost;
        }
                

        


        private async Task<IEnumerable<JobPost>> GetQuery(Expression<Func<JobPost, bool>>? filter, string? includeProperties)
        {
            IQueryable<JobPost> query = _db.Set<JobPost>();

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
