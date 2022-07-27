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
        private readonly IMeetupRepository meetupRepository;
        private readonly IMapper mapper;

        public EventsController(IMeetupRepository meetupRepository, IMapper mapper)
        {
            this.meetupRepository = meetupRepository;
            this.mapper = mapper;
        }

        //GET api/events
        [HttpGet]
        public ActionResult<IEnumerable<EventReadDto>> GetAllEvents()
        {
            var eventItems = meetupRepository.GetEvents();

            return Ok(mapper.Map<IEnumerable<EventReadDto>>(eventItems));
        }

        //GET api/events/{id}
        [HttpGet("{id}")]
        public ActionResult<EventReadDto> GetEventById(int id)
        {
            var eventItem = meetupRepository.GetEventById(id);

            if(eventItem != null)
                return Ok(mapper.Map<EventReadDto>(eventItem));

            return NotFound();
        }

        //POST api/events/{id}
        [HttpPost]
        public ActionResult<EventReadDto> CreateEvent(EventCreateDto eventCreateDto)
        {
            var eventModel = mapper.Map<Event>(eventCreateDto);
            meetupRepository.CreateEvent(eventModel);

            return Ok(eventModel);
        }
    }
}
