using AutoMapper;
using EventRegistrationApi.Domain.Entities.Participants;
using DalEntities = EventRegistrationApi.DataAccess.Entities;
namespace EventRegistrationApi.DataAccess.MappingProfiles;

public class ParticipantMappingProfile : Profile
{

    public ParticipantMappingProfile()
    {
        CreateMap<DalEntities.Participant, Participant>()
            .ConstructUsing(s => new Participant(s.Id, s.Name, s.LastName, s.Email));
        CreateMap<Participant, DalEntities.Participant>();
    }
}