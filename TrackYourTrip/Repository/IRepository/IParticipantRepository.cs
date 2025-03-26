using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IParticipantRepository
    {
        public Task<IEnumerable<Participant>> GetAllAsync(Expression<Func<Participant, bool>>? filter = null, string? includeProperties = null);
        public Task<Participant> GetAsync(int participantId);
        public Task<Participant> CreateAsync(Participant participant);
        public Task<Participant> UpdateAsync(Participant participant);
        public Task<bool> DeleteAsync(int participantId);
    }
}
