using System.ComponentModel.DataAnnotations;

namespace NoteApp.Api.Data;

public class Notes
{
    [Key]
    public int NoteId { get; set; }
    public required string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public string AppUserId { get; set; } = null!;
}
