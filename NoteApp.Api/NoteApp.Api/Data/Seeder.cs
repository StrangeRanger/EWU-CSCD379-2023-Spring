using Microsoft.EntityFrameworkCore;
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
        var urlService = new UrlService(db);
        const string content =
            "<h1>Header 1</h1><p><strong>Bold</strong> <em>Italicize</em> <u>Underline</u> <s>Crossed out</s> <sub>Sub</sub>script <sup>Super</sup>script</p><p><span style=\"color: rgb(0, 102, 204);\">Blue</span> <span style=\"color: rgb(230, 0, 0);\">Red</span> <span style=\"color: rgb(0, 138, 0);\">Green</span></p>";

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

        // IMPORTANT: Each note must be added individually to the database, so that the urlService can generate a unique
        // url suffix for each note.
        for (var i = 0; i < 9; i++)
        {
            var chosenUser = i switch {
                0 => adminUserId,
                1 => hunterUserId,
                2 => nolanUserId,
                3 => adminUserId,
                4 => hunterUserId,
                5 => nolanUserId,
                6 => adminUserId,
                7 => hunterUserId,
                _ => nolanUserId
            };

            var note = new Notes { Title = $"Note {i + 1}",
                                   Content = content,
                                   Created = DateTime.Now,
                                   LastModified = DateTime.Now,
                                   UrlSuffix = urlService.GenerateUniqueUrlSuffixAsync().Result,
                                   AppUserId = chosenUser };

            db.Notes.Add(note);
        }

        db.SaveChangesAsync();
    }
}
