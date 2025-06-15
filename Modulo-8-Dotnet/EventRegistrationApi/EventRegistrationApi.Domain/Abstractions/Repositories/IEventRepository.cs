using EventRegistrationApi.Domain.Entities.Events;
using EventRegistrationApi.Domain.Abstractions.Entities;
using System.Threading.Tasks;

namespace EventRegistrationApi.Domain.Abstractions.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetEvent(int eventId);

        Task<IIdentifiable> AddEvent(Event eventEntity);

        Task EditEvent(Event eventEntity);

        Task DeleteEvent(int eventId);
    }
}
