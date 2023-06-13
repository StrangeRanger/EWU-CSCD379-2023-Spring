namespace NoteApp.Api.Dtos;

public class NoteDto
{
    public required string Title { get; set; } = null!;
    public required string Content { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public string AppUserId { get; set; } = null!;
}
