using AutoMapper;
using EventRegistrationApi.DataAccess.Context;
using EventRegistrationApi.Domain.Abstractions.Entities;
using EventRegistrationApi.Domain.Abstractions.Repositories;
using EventRegistrationApi.Domain.Entities.Events;
using EventRegistrationApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DalEntities = EventRegistrationApi.DataAccess.Entities;

namespace EventRegistrationApi.DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventRegistrationApiDbContext _context;
        private readonly IMapper _mapper;

        public EventRepository(EventRegistrationApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Event> GetEvent(int eventId)
        {
            var eventEntity = await _context.Events
                .Include(e => e.Participants) // si tienes navegación a participantes
                .SingleOrDefaultAsync(e => e.Id == eventId);

            if (eventEntity is null)
            {
                throw new EntityNotFoundException($"Unable to find an event with id {eventId}.");
            }

            return _mapper.Map<Event>(eventEntity);
        }

        public Task<IIdentifiable> AddEvent(Event eventEntity)
        {
            var dalEvent = _mapper.Map<DalEntities.Event>(eventEntity);
            _context.Events.Add(dalEvent);
            return Task.FromResult((IIdentifiable)dalEvent);
        }

        public async Task EditEvent(Event eventEntity)
        {
            var eventFromDb = await _context.Events.FindAsync(eventEntity.Id);
            if (eventFromDb is null)
            {
                throw new EntityNotFoundException($"The event with ID {eventEntity.Id} was not found.");
            }

            _mapper.Map(eventEntity, eventFromDb);
        }

        public async Task DeleteEvent(int eventId)
        {
            var eventFromDb = await _context.Events.FindAsync(eventId);
            if (eventFromDb is null)
            {
                throw new EntityNotFoundException($"The event with ID {eventId} was not found.");
            }

            _context.Events.Remove(eventFromDb);
        }
    }
}
