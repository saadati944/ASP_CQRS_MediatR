using MediatR;
using cqrsAndMediatR.Dtos;

namespace cqrsAndMediatR.Queries;

public class GetAllNotesQuery : IRequest<IEnumerable<Note>>
{
}
