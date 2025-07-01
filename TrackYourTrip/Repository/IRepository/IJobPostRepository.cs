using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IJobPostRepository
    {
        public Task<IEnumerable<JobPost>> GetAllAsync(Expression<Func<JobPost, bool>>? filter = null, string? includeProperties = null);
        public Task<JobPost> GetAsync(int jobPostId, bool noTracking = false);
        public Task<JobPost> CreateAsync(JobPost jobPost);
        public Task<JobPost> UpdateAsync(JobPost jobPost);
        public Task<bool> DeleteAsync(int jobPostId);
    }
}
