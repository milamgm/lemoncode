using Dapper;
using EventRegistrationApi.Application.Abstractions.Queries;
using EventRegistrationApi.Application.Config;
using EventRegistrationApi.Application.Dtos.Queries.Events;
using EventRegistrationApi.Application.Dtos.Queries.Participants;
using EventRegistrationApi.Application.Exceptions;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace EventRegistrationApi.Application.Queries
{
    public class EventQueriesService : IEventQueriesService, IDisposable
    {
        private readonly SqlConnection _connection;
        private bool disposedValue;

        public EventQueriesService(IOptionsSnapshot<DapperConfig> dapperConfig)
        {
            _connection = new SqlConnection(dapperConfig.Value.DefaultConnectionString);
            _connection.Open();
        }

        public async Task<EventDto> GetEvent(int eventId)
        {
            var ev = await _connection.QuerySingleOrDefaultAsync<EventDto>(
                @"SELECT Id, Name, StartDate, EndDate, Description
                  FROM Events
                  WHERE Id = @eventId",
                new { eventId });

            if (ev == null)
                throw new EntityNotFoundException($"Event with ID {eventId} not found.");

            return ev;
        }

        public async Task<IList<EventDto>> GetAllEvents()
        {
            var events = await _connection.QueryAsync<EventDto>(
                @"SELECT Id, Name, StartDate, EndDate, Description
                  FROM Events
                  ORDER BY StartDate DESC");

            return events.AsList();
        }

        public async Task<IList<ParticipantDto>> GetParticipants(int eventId)
        {
            var participants = await _connection.QueryAsync<ParticipantDto>(
                @"SELECT p.Id, p.Name, p.LastName, p.Email
                  FROM Participants p
                  INNER JOIN EventParticipant ep ON p.Id = ep.ParticipantsId
                  WHERE ep.EventsId = @eventId",
                new { eventId });

            return participants.AsList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
