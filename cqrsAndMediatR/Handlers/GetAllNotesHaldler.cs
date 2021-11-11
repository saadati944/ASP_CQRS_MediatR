using cqrsAndMediatR.Dtos;
using cqrsAndMediatR.Repositories;
using cqrsAndMediatR.Queries;
using MediatR;

namespace cqrsAndMediatR.Handlers;

public class GetAllNotesHaldler : IRequestHandler<GetAllNotesQuery, IEnumerable<Note>>
{
    private NotesRepository _notesRepository;
    public GetAllNotesHaldler(NotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }
    public Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = _notesRepository.GetNotes();
        return Task.FromResult(notes);
    }
}