using cqrsAndMediatR.Dtos;
using cqrsAndMediatR.Repositories;
using cqrsAndMediatR.Commands;
using MediatR;

namespace cqrsAndMediatR.Handlers;

public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, Note>
{
    private NotesRepository _notesRepository;
    public CreateNoteHandler(NotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }

    public Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_notesRepository.AddNote(new Note
        {
            Name = request.Name,
            Description = request.Description,
            CreatedDate = request.CreatedDate,
            Status = request.Status
        }));
    }
}