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
        
        // Bloop insert

        var notes = new List<Notes> { new() { Title = "Note 1",
                                              Content = "Content 1",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 2",
                                              Content = "Content 2",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 3",
                                              Content = "Content 3",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 4",
                                              Content = "Content 4",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 5",
                                              Content = "Content 5",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 6",
                                              Content = "Content 6",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 7",
                                              Content = "Content 7",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 8",
                                              Content = "Content 8",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 9",
                                              Content = "Content 9",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" },
                                      new() { Title = "Note 10",
                                              Content = "Content 10",
                                              Created = DateTime.Now,
                                              LastModified = DateTime.Now,
                                              AppUserId = "1" } };

        db.Notes.AddRange(notes);
        db.SaveChanges();
    }
}
