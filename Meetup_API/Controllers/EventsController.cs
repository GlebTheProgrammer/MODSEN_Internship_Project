using Meetup_API.Domain;
using Meetup_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meetup_API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMeetupRepository mockMeetupRepository;

        public EventsController(IMeetupRepository meetupRepository)
        {
            mockMeetupRepository = meetupRepository;
        }

        //GET api/events
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAllEvents()
        {
            var eventItem = mockMeetupRepository.GetEvents();

            return Ok(eventItem);
        }

        //GET api/events/{id}
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            var eventItems = mockMeetupRepository.GetEventById(id);

            return Ok(eventItems);
        }
    }
}
