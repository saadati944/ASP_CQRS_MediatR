using Microsoft.AspNetCore.Mvc;
using cqrsAndMediatR.Dtos;
using cqrsAndMediatR.Repositories;
using MediatR;
using cqrsAndMediatR.Queries;
using cqrsAndMediatR.Commands;

namespace cqrsAndMediatR.Controllers;

[Route("[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;
    private readonly IMediator _mediator;

    public NotesController(ILogger<NotesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllNotesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(int id)
    {
        var query = new GetNoteQuery(id);
        var result = await _mediator.Send(query);
        if(result is not null)
            return Ok(result);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateNoteCommand note)
    {
        var result = await _mediator.Send(note);
        return CreatedAtAction("GetNote", new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new RemoveNoteCommand(id);
        var removedNote = await _mediator.Send(command);
        if(removedNote is not null)
            return Ok();

        return NotFound();
    }
}

