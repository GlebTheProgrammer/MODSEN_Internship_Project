using Meetup_API.Models;

namespace Meetup_API.Domain
{
    public class SqlMeetupRepository : IMeetupRepository
    {
        private readonly MeetupDbContext context;

        public SqlMeetupRepository(MeetupDbContext context)
        {
            this.context = context;
        }

        public Event GetEventById(int id)
        {
            return context.Events.FirstOrDefault(eventItem => eventItem.Id == id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return context.Events.ToList();
        }
    }
}
