using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackYourTrip.Data;
using TrackYourTrip.Data.Entities;
using TrackYourTrip.Repository.IRepository;

namespace TrackYourTrip.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly TrackYourTripDbContext _db;
        public ParticipantRepository(TrackYourTripDbContext db)
        {
            _db = db;
        }

        public async Task<Participant> CreateAsync(Participant participant)
        {
            await _db.Participants.AddAsync(participant);
            await _db.SaveChangesAsync();
            return participant;
        }

        public async Task<bool> DeleteAsync(int participantId)
        {
            var participant = await _db.Participants.FirstOrDefaultAsync(t => t.Id == participantId);
            if (participant is not null)
            {
                _db.Participants.Remove(participant);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Participant> GetAsync(int participantId)
        {
            var participant = await _db.Participants.FirstOrDefaultAsync(t => t.Id == participantId);

            if (participant is not null)
            {
                return participant;
            }
            else return new Participant();
        }



        public async Task<Participant> UpdateAsync(Participant participant)
        {
            _db.Participants.Update(participant);
            await _db.SaveChangesAsync();

            return participant;
        }

        public async Task<IEnumerable<Participant>> GetAllAsync(Expression<Func<Participant, bool>>? filter = null,
            string? includeProperties = null)
        {
            return await GetQuery(filter, includeProperties);
        }


        private async Task<IEnumerable<Participant>> GetQuery(Expression<Func<Participant, bool>>? filter, string? includeProperties)
        {
            IQueryable<Participant> query = _db.Set<Participant>();

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
