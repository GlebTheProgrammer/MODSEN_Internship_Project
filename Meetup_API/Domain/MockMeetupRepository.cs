using Meetup_API.Models;

namespace Meetup_API.Domain
{
    public class MockMeetupRepository : IMeetupRepository
    {
        List<Event> events = new List<Event>()
        {
            new Event
            {
                Id = 0,
                Name = "My birthDay",
                Description = "Celebrate my 20 y.o.",
                Plan = "Buy some fashion clothes & sleep before the start",
                Organizer = "Gleb Sukristik",
                Speaker = "Gleb Sukristik & his friends",
                Date = "15.04.2023",
                Place = "Pizza Tempo"
            },
            new Event()
            {
                    Id = 1,
                    Name = "OpenIT Conference",
                    Description = "Conference for IT specialists",
                    Plan = "Come and have some fun",
                    Organizer = "HTP",
                    Speaker = "Different people from different countries & positions",
                    Date = "01.09.2023",
                    Place = "Victoria Hottel"
            },
            new Event()
            {
                Id = 2,
                Name = "University studies",
                Description = "NOOOOO PLEASE",
                Plan = "Study, study, study...",
                Organizer = "BSUIR",
                Speaker = "Lecturers",
                Date = "01.09.2023",
                Place = "BSUIR University"
            }
        };
        public void CreateEvent(Event eventItem)
        {
            events.Add(eventItem);
            return;
        }

        public Event GetEventById(int id)
        {
            return events.FirstOrDefault(eventItem => eventItem.Id == id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return events;
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}
