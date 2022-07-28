using AutoMapper;
using Meetup_API.DTOs;
using Meetup_API.Models;

namespace Meetup_API.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            //Source -> Target

            CreateMap<Event, EventReadDto>();

            CreateMap<EventCreateDto, Event>();

            CreateMap<EventUpdateDto, Event>();

            CreateMap<Event, EventUpdateDto>();
        }
    }
}
