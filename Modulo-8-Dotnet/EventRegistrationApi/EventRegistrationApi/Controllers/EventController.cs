using AutoMapper;

using EventRegistrationApi.Api.Extensions;
using EventRegistrationApi.Application.Abstractions.Services;
using EventRegistrationApi.Application.Dtos.Commands.Events;
using EventRegistrationApi.Application.Abstractions.Queries;
using EventRegistrationApi.Application.Dtos.Commands.Participants;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationApi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IEventQueriesService _eventQueriesService;
    private readonly IMapper _mapper;

    public EventsController(IEventService eventService, IEventQueriesService eventQueriesService, IMapper mapper)
    {
        _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        _eventQueriesService = eventQueriesService ?? throw new ArgumentNullException(nameof(eventQueriesService));
        _mapper = mapper;
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> GetEvent([FromRoute] int eventId)
    {
        try
        {
            var eventDto = await _eventQueriesService.GetEvent(eventId);
            return Ok(_mapper.Map<EventDto>(eventDto));
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }

    [HttpGet("upcoming")]
    public async Task<IActionResult> GetUpcomingEvents([FromQuery] int limit = 10)
    {
        try
        {
            var events = await _eventQueriesService.GetUpcomingEvents(limit);
            return Ok(_mapper.Map<IList<EventDto>>(events));
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> AddEvent([FromBody] EventDto eventDto)
    {
        var result = await _eventService.AddEvent(eventDto);
        if (!result.ValidationResult.IsValid)
        {
            result.ValidationResult.AddToModelState(this.ModelState);
            return this.ValidationProblem();
        }

        return Created($"/api/events/{result.EventId}", eventDto);
    }

    [HttpPut("{eventId}")]
    public async Task<IActionResult> EditEvent([FromRoute] int eventId, [FromBody] EventDto eventDto)
    {
        try
        {
            var result = await _eventService.EditEvent(eventId, eventDto);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return this.ValidationProblem();
            }

            return Ok(eventDto);
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }

    
    [HttpDelete("{eventId}")]
    public async Task<IActionResult> DeleteEvent([FromRoute] int eventId)
    {
        try
        {
            await _eventService.DeleteEvent(eventId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }

    [HttpGet("{eventId}/participants")]
    public async Task<IActionResult> GetParticipants([FromRoute] int eventId)
    {
        try
        {
            var participants = await _eventQueriesService.GetParticipants(eventId);
            return Ok(participants);
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }

    
    [HttpPost("{eventId}/participants")]
    public async Task<IActionResult> AddParticipantToEvent([FromRoute] int eventId, [FromBody] ParticipantDto participant)
    {
        var result = await _eventService.AddParticipantToEvent(eventId, participant);
        if (!result.ValidationResult.IsValid)
        {
            result.ValidationResult.AddToModelState(this.ModelState);
            return this.ValidationProblem();
        }

        return Created($"/api/events/{eventId}/participants/{result.ParticipantId}", participant);
    }

    
    [HttpDelete("{eventId}/participants/{participantId}")]
    public async Task<IActionResult> RemoveParticipantFromEvent([FromRoute] int eventId, [FromRoute] int participantId)
    {
        try
        {
            await _eventService.RemoveParticipantFromEvent(eventId, participantId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }
}
