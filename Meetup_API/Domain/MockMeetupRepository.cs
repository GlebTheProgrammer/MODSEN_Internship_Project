using Meetup_API.Models;

namespace Meetup_API.Domain
{
    public class MockMeetupRepository : IMeetupRepository
    {
        public Event GetEventById(int id)
        {
            return new Event
            {
                Id = 0,
                Name = "My birthDay",
                Description = "Celebrate my 20 y.o.",
                Plan = "Cook some dish & sleep before the start",
                Organizer = "Gleb Sukristik",
                Speaker = "Gleb Sukristik & his friends",
                Date = "15.04.2023",
                Place = "Pizza Tempo"
            };
        }

        public IEnumerable<Event> GetEvents()
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    Id = 0,
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
                    Id = 1,
                    Name = "University studies",
                    Description = "NOOOOO PLEASE",
                    Plan = "Study, study, study...",
                    Organizer = "BSUIR",
                    Speaker = "Lecturers",
                    Date = "01.09.2023",
                    Place = "BSUIR University"
                }
            };

            return events;
        }
    }
}
