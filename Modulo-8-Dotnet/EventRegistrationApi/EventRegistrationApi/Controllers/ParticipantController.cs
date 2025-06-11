using EventRegistrationApi.Api.Extensions;
using EventRegistrationApi.Application.Abstractions.Queries;
using EventRegistrationApi.Application.Abstractions.Services;
using QueryDtos = EventRegistrationApi.Application.Dtos.Queries.Participants;
using CommandDtos = EventRegistrationApi.Application.Dtos.Commands.Participants;

using EventRegistrationApi.Domain.Exceptions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;
using EventRegistrationApi.Api.Extensions;

namespace EventRegistrationApi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantsController : ControllerBase
{

    private readonly IParticipantService _participantService;

    private readonly IParticipantQueriesService _participantQueriesService;

    public ParticipantsController(IParticipantService ParticipantService, IParticipantQueriesService ParticipantQueriesService)
    {
        _participantService = ParticipantService;
        _participantQueriesService = ParticipantQueriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetParticipants(
        [FromQuery, Range(1, int.MaxValue, ErrorMessage = "The page number must be greater than 1.")] int page = 1,
        [FromQuery, Range(1, int.MaxValue, ErrorMessage = "The page size must be greater than 1.")] int pageSize = 10)
    {
        return Ok(await _participantQueriesService.GetParticipants());
    }


    [HttpGet("{ParticipantId}")]
    public async Task<IActionResult> GetParticipant([FromRoute] int ParticipantId)
    {
        try
        {
            return Ok(await _participantQueriesService.GetParticipantById(ParticipantId));
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }


    [HttpPost]
    public async Task<IActionResult> AddParticipant(CommandDtos.ParticipantDto Participant)
    {
        var operationInfo = await _participantService.AddParticipant(Participant);
        if (!operationInfo.ValidationResult.IsValid)
        {
            operationInfo.ValidationResult.AddToModelState(this.ModelState);
            return ValidationProblem();
        }

        Participant.Id = operationInfo.ParticipantId!.Value;
        return Created($"/api/events/{Participant.Id}", Participant);
    }

    [HttpPut]
    public async Task<IActionResult> EditParticipant(CommandDtos.ParticipantDto Participant)
    {
        try
        {
            var validationResult = await _participantService.EditParticipant(Participant);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return ValidationProblem();
            }

            return Ok(Participant);
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }

    [HttpDelete("{ParticipantId}")]
    public async Task<IActionResult> Delete(int ParticipantId)
    {
        try
        {
            await _participantService.DeleteParticipant(ParticipantId);
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }

        return NoContent();
    }
}
