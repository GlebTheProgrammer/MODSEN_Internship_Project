using AutoMapper;
using Meetup_API.Domain;
using Meetup_API.DTOs;
using Meetup_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meetup_API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMeetupRepository mockMeetupRepository;
        private readonly IMapper mapper;

        public EventsController(IMeetupRepository meetupRepository, IMapper mapper)
        {
            mockMeetupRepository = meetupRepository;
            this.mapper = mapper;
        }

        //GET api/events
        [HttpGet]
        public ActionResult<IEnumerable<EventReadDto>> GetAllEvents()
        {
            var eventItems = mockMeetupRepository.GetEvents();

            return Ok(mapper.Map<IEnumerable<EventReadDto>>(eventItems));
        }

        //GET api/events/{id}
        [HttpGet("{id}")]
        public ActionResult<EventReadDto> GetEventById(int id)
        {
            var eventItem = mockMeetupRepository.GetEventById(id);

            if(eventItem != null)
                return Ok(mapper.Map<EventReadDto>(eventItem));

            return NotFound();
        }
    }
}
