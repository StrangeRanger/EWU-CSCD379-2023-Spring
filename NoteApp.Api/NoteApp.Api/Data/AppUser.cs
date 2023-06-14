using Microsoft.AspNetCore.Identity;

namespace NoteApp.Api.Data;

public class AppUser : IdentityUser
{
    public required string Name { get; set; }
    public ICollection<Notes>? Notes { get; set; }
}
