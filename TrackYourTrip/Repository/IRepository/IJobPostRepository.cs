using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IJobPostRepository
    {
        Task<IEnumerable<JobPost>> GetAllAsync(Expression<Func<JobPost, bool>>? filter = null, string? includeProperties = null);

        Task<IEnumerable<JobPost>> GetAllByCompanyNameAsync(string companyName);
        Task<JobPost> GetAsync(int jobPostId, bool noTracking = false);
        Task<JobPost> CreateAsync(JobPost jobPost);
        Task<JobPost> UpdateAsync(JobPost jobPost);
        Task<bool> DeleteAsync(int jobPostId);
    }
}
