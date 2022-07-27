using Meetup_API.Models;

namespace Meetup_API.Domain
{
    public interface IMeetupRepository
    {
        IEnumerable<Event> GetEvents();
        Event GetEventById(int id);
    }
}
