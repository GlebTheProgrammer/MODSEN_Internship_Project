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

        public void CreateEvent(Event eventItem)
        {
            if (eventItem == null)
                throw new ArgumentNullException(nameof(eventItem));

            context.Events.Add(eventItem);
            return;
        }

        public void DeleteEvent(Event eventItem)
        {
            if(eventItem == null)
                throw new ArgumentNullException(nameof(eventItem));

            context.Events.Remove(eventItem);

            return;
        }

        public Event GetEventById(int id)
        {
            return context.Events.FirstOrDefault(eventItem => eventItem.Id == id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return context.Events.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        public void UpdateEvent(Event eventItem)
        {
            //Nothing
        }
    }
}
