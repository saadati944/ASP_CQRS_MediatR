using cqrsAndMediatR.Dtos;
using MediatR;

namespace cqrsAndMediatR.Commands;

public class CreateNoteCommand : IRequest<Note>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }
    public NoteStatus Status { get; set; }
}