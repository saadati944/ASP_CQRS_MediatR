namespace cqrsAndMediatR.Dtos;

public class Note
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }
    public NoteStatus Status { get; set; }
}

public enum NoteStatus
{
    NotChecked = 1,
    Done = 2
}