using cqrsAndMediatR.Dtos;
using cqrsAndMediatR.Repositories;
using cqrsAndMediatR.Commands;
using MediatR;

namespace cqrsAndMediatR.Handlers;

public class RemoveNoteHandler : IRequestHandler<RemoveNoteCommand, Note?>
{
    private NotesRepository _notesRepository;
    public RemoveNoteHandler(NotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }

    public Task<Note?> Handle(RemoveNoteCommand request, CancellationToken cancellationToken)
    {
        var note = _notesRepository.GetNote(request.Id);
        if(note is not null)
            _notesRepository.RemoveNote(note);
        return Task.FromResult(note);
    }
}