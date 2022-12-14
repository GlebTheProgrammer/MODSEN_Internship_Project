using AutoMapper;
using Meetup_API.Domain;
using Meetup_API.DTOs;
using Meetup_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
        [Authorize]
        public ActionResult<IEnumerable<EventReadDto>> GetAllEvents()
        {
            var eventItems = meetupRepository.GetEvents();

            return Ok(mapper.Map<IEnumerable<EventReadDto>>(eventItems));
        }

        //GET api/events/{id}
        [HttpGet("{id}", Name = "GetEventById")]
        [Authorize]
        public ActionResult<EventReadDto> GetEventById(int id)
        {
            var eventItem = meetupRepository.GetEventById(id);

            if(eventItem != null)
                return Ok(mapper.Map<EventReadDto>(eventItem));

            return NotFound();
        }

        //POST api/events/{id}
        [HttpPost]
        [Authorize]
        public ActionResult<EventReadDto> CreateEvent(EventCreateDto eventCreateDto)
        {
            var eventModel = mapper.Map<Event>(eventCreateDto);

            meetupRepository.CreateEvent(eventModel);
            meetupRepository.SaveChanges();

            var eventReadDto = mapper.Map<EventReadDto>(eventModel);

            return CreatedAtRoute(nameof(GetEventById), new { Id = eventModel.Id }, eventReadDto);
        }

        //PUT api/events/{id}
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult UpdateEvent(int id, EventUpdateDto eventUpdateDto)
        {
            var eventModelFromRepo = meetupRepository.GetEventById(id);

            if(eventModelFromRepo == null)
                return NotFound();

            //Update automatically
            mapper.Map(eventUpdateDto, eventModelFromRepo);

            meetupRepository.UpdateEvent(eventModelFromRepo);
            meetupRepository.SaveChanges();

            return NoContent();
        }

        //PATCH api/events/{id}
        [HttpPatch("{id}")]
        [Authorize]
        public ActionResult PartialEventUpdate(int id, JsonPatchDocument<EventUpdateDto> patchDocument)
        {
            var eventModelFromRepo = meetupRepository.GetEventById(id);

            if (eventModelFromRepo == null)
                return NotFound();

            var eventToPatch = mapper.Map<EventUpdateDto>(eventModelFromRepo);

            try
            {
                patchDocument.ApplyTo(eventToPatch, ModelState);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            

            if (!TryValidateModel(eventToPatch))
                return ValidationProblem(ModelState);

            mapper.Map(eventToPatch, eventModelFromRepo);
            meetupRepository.UpdateEvent(eventModelFromRepo);
            meetupRepository.SaveChanges();

            return NoContent();
        }

        //DELETE api/events/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteEvent(int id)
        {
            var eventModelFromRepo = meetupRepository.GetEventById(id);

            if (eventModelFromRepo == null)
                return NotFound();

            meetupRepository.DeleteEvent(eventModelFromRepo);
            meetupRepository.SaveChanges();

            return NoContent();
        }
    }
}
