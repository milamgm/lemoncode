using AutoMapper;
using EventRegistrationApi.Domain.Entities.Events;
using EventRegistrationApi.Domain.Entities.Participants;
using DalEntities = EventRegistrationApi.DataAccess.Entities;
using System.Linq;

namespace EventRegistrationApi.DataAccess.MappingProfiles
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<DalEntities.Event, Event>()
                .ConstructUsing(e => new Event(
                    e.Id,
                    e.Name,
                    e.StartDate,
                    e.EndDate,
                    new EventDescription(e.Description),
                    e.Participants.Select(p => new Participant(p.Id, p.Name, p.LastName, p.Email)).ToList()
                ));

            CreateMap<Event, DalEntities.Event>()
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants));
        }
    }
}
