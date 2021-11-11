using Microsoft.AspNetCore.Mvc;
using cqrsAndMediatR.Dtos;
using cqrsAndMediatR.Repositories;
using MediatR;
using cqrsAndMediatR.Queries;

namespace cqrsAndMediatR.Controllers;

[Route("[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private NotesRepository _repository;
    private readonly ILogger<NotesController> _logger;
    private readonly IMediator _mediator;

    public NotesController(NotesRepository notesRepository, ILogger<NotesController> logger, IMediator mediator)
    {
        _repository = notesRepository;
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllNotesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetNoteQuery(id);
        var result = await _mediator.Send(query);
        if(result is not null)
            return Ok(result);
        return NotFound();
    }

    [HttpPost]
    public void Post([FromBody] Note task)
    {
        task.Id = _repository.GetNotes().Count();
        _repository.AddNote(task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _repository.GetNote(id);
        if(task is not null && _repository.RemoveNote(task))
            return Ok();

        return NotFound();
    }
}

