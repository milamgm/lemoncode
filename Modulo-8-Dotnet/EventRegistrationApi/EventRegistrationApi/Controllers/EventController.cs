using Microsoft.AspNetCore.Mvc;
using EventRegistrationApi.Application.Abstractions.Services;
using EventRegistrationApi.Application.Abstractions.Queries;

using CommandEventDto = EventRegistrationApi.Application.Dtos.Commands.Events.EventDto;
using QueryEventDto = EventRegistrationApi.Application.Dtos.Queries.Events.EventDto;
using EventRegistrationApi.Api.Extensions;

namespace EventRegistrationApi.Api.Controllers;

[ApiController]
[Route("api/eventos")]
public class EventosController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IEventQueriesService _eventQueriesService;

    public EventosController(IEventService eventService, IEventQueriesService eventQueriesService)
    {
        _eventService = eventService;
        _eventQueriesService = eventQueriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IList<QueryEventDto> eventos = await _eventQueriesService.GetAllEvents();
        return Ok(eventos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        QueryEventDto evento = await _eventQueriesService.GetEvent(id);
        if (evento == null) return NotFound();
        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommandEventDto evento)
    {
        evento.Operation = CommandEventDto.OperationType.Add;
        var result = await _eventService.AddEvent(evento);
        if (!result.ValidationResult.IsValid)
        {
            result.ValidationResult.AddToModelState(this.ModelState);
            return this.ValidationProblem();
        }

        return CreatedAtAction(nameof(GetById), new { id = result.EventId }, evento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CommandEventDto evento)
    {
        evento.Operation = CommandEventDto.OperationType.Edit;
        var result = await _eventService.EditEvent(id, evento);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return this.ValidationProblem();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _eventService.DeleteEvent(id);
        return NoContent();
    }

    // GET /api/eventos/{id}/participantes
    [HttpGet("{id}/participantes")]
    public async Task<IActionResult> GetEventParticipants(int id)
    {
        var participantes = await _eventQueriesService.GetParticipants(id);
        return Ok(participantes);
    }

    // POST /api/eventos/{id}/participantes
    [HttpPost("{id}/participantes")]
    public async Task<IActionResult> AddParticipantToEvent(int id, [FromBody] int participantId)
    {
        var result = await _eventService.AddParticipantToEvent(id, participantId);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return this.ValidationProblem();
        }

        return NoContent();
    }

    // DELETE /api/eventos/{id}/participantes/{participantId}
    [HttpDelete("{id}/participantes/{participantId}")]
    public async Task<IActionResult> RemoveParticipantFromEvent(int id, int participantId)
    {
        var result = await _eventService.RemoveParticipantFromEvent(id, participantId);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return this.ValidationProblem();
        }

        return NoContent();
    }

}
