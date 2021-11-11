using cqrsAndMediatR.Dtos;
using cqrsAndMediatR.Repositories;
using cqrsAndMediatR.Queries;
using MediatR;

namespace cqrsAndMediatR.Handlers;

public class GetNoteHaldler : IRequestHandler<GetNoteQuery, Note>
{
    private NotesRepository _notesRepository;
    public GetNoteHaldler(NotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }
    public Task<Note> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var note = _notesRepository.GetNote(request.Id);
        return Task.Run(()=>note);
    }
}