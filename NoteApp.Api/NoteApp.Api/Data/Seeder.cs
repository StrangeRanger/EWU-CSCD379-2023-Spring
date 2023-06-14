using NoteApp.Api.Controllers;
using NoteApp.Api.Services;

namespace NoteApp.Api.Data;

public class Seeder
{
    public static void Seed(AppDbContext context)
    {
        SeedNotes(context);
    }

    public static void SeedNotes(AppDbContext db)
    {
        if (db.Notes.Any())
        {
            return;
        }
        
        var adminUserId = "";
        var hunterUserId = "";
        var nolanUserId = "";
        
        // Admin User Id
        var adminUser = db.AppUsers.FirstOrDefault(u => u.UserName == "admin@noteapp.com");
        if (adminUser != null)
        {
             adminUserId = adminUser.Id;
        }
        
        // Hunter User Id
        var hunterUser = db.AppUsers.FirstOrDefault(u => u.UserName == "hunter.t@noteapp.com");
        if (hunterUser != null)
        {
            hunterUserId = hunterUser.Id;
        }
        
        // Nolan User Id
        var nolanUser = db.AppUsers.FirstOrDefault(u => u.UserName == "nposey@noteapp.com");
        if (nolanUser != null)
        {
            nolanUserId = nolanUser.Id;
        }

        var notes = new List<Notes> { new() { Title = "Note 1",
                                              Content = "Content 1",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = adminUserId },
                                      new() { Title = "Note 2",
                                              Content = "Content 2",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = adminUserId },
                                      new() { Title = "Note 2",
                                              Content = "Content 3",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = adminUserId },
                                      new() { Title = "Note 1",
                                              Content = "Content 4",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = hunterUserId },
                                      new() { Title = "Note 2",
                                              Content = "Content 5",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = hunterUserId },
                                      new() { Title = "Note 2",
                                              Content = "Content 6",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = hunterUserId },
                                      new() { Title = "Note 1",
                                              Content = "Content 7",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = nolanUserId },
                                      new() { Title = "Note 2",
                                              Content = "Content 8",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = nolanUserId },
                                      new() { Title = "Note 2",
                                              Content = "Content 9",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = nolanUserId } };

        db.Notes.AddRange(notes);
        db.SaveChanges();
    }
}
