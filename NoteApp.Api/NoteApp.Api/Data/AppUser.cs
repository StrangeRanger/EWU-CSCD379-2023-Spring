using Microsoft.AspNetCore.Identity;

namespace NoteApp.Api.Data;

public class AppUser : IdentityUser
{
    public ICollection<Notes> Notes { get; set; } = null!;
}