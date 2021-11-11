using MediatR;
using cqrsAndMediatR.Dtos;

namespace cqrsAndMediatR.Queries;

public class GetNoteQuery : IRequest<Note>
{
    public int Id { get; }
    public GetNoteQuery(int id)
    {
        Id = id;
    }
}
