using System.Linq.Expressions;
using TrackYourTrip.Data.Entities;

namespace TrackYourTrip.Repository.IRepository
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAllAsync(Expression<Func<Participant, bool>>? filter = null, string? includeProperties = null);
        Task<Participant> GetAsync(int participantId);
        Task<Participant> CreateAsync(Participant participant);
        Task<Participant> UpdateAsync(Participant participant);
        Task<bool> DeleteAsync(int participantId);
    }
}
