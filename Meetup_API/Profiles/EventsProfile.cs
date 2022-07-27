using AutoMapper;
using Meetup_API.DTOs;
using Meetup_API.Models;

namespace Meetup_API.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Event, EventReadDto>();
        }
    }
}
