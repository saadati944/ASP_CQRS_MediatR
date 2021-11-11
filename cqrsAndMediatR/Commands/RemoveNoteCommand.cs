using MediatR;
using cqrsAndMediatR.Dtos;

namespace cqrsAndMediatR.Commands;

public class RemoveNoteCommand : IRequest<Note>
{
    public int Id { get; }
    public RemoveNoteCommand(int id)
    {
        Id = id;
    }
}
