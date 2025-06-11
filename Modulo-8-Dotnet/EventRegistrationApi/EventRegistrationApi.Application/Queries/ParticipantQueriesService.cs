using Dapper;

using EventRegistrationApi.Application.Abstractions.Queries;
using EventRegistrationApi.Application.Config;
using EventRegistrationApi.Application.Dtos.Queries.Participants;
using EventRegistrationApi.Application.Exceptions;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace EventRegistrationApi.Application.Queries
{
    public class ParticipantQueriesService : IParticipantQueriesService, IDisposable
    {

        private readonly SqlConnection _connection;
        private bool disposedValue;

        public ParticipantQueriesService(IOptionsSnapshot<DapperConfig> dapperConfig)
        {
            _connection = new SqlConnection(dapperConfig.Value.DefaultConnectionString);
            _connection.Open();
        }

        public async Task<List<ParticipantWithEventCountDto>> GetParticipants()
        {
            return (await _connection.QueryAsync<ParticipantWithEventCountDto>(
                @"SELECT
                    a.Id,
                    a.Name,
                    a.LastName,
                    a.Email,
                    COUNT(ab.EventsId) as EventCount
                  FROM
                    Participants a
                  LEFT JOIN 
                    ParticipantEvent ab ON a.Id = ab.ParticipantsId
                  GROUP BY 
                    a.Id, a.Name, a.LastName, a.Email")).ToList();
        }

        public async Task<ParticipantWithEventCountDto> GetParticipantById(int ParticipantId)
        {
            var Participant = await _connection.QuerySingleOrDefaultAsync<ParticipantWithEventCountDto>(
                @"SELECT
                    a.Id,
                    a.Name,
                    a.LastName,
                    a.Email,
                    COUNT(ab.EventsId) as EventCount
                  FROM
                    Participants a
                  LEFT JOIN 
                    ParticipantEvent ab ON a.Id = ab.ParticipantsId
                  WHERE a.Id = @ParticipantId
                  GROUP BY 
                    a.Id, a.Name, a.LastName, a.Email", new { ParticipantId = ParticipantId });

            if (Participant is null)
            {
                throw new EntityNotFoundException($"Unable to find the Participant with ID {ParticipantId}.");
            }

            return Participant;
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
