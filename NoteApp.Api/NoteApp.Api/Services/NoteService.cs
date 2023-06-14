using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NoteApp.Api.Data;
using NoteApp.Api.Dtos;

namespace NoteApp.Api.Services;

public class NoteService
{
    private readonly AppDbContext _db;

    public NoteService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Notes> GetNoteAsync(string title, string userID)
    {
        if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("User ID or Title cannot be null or empty");
        }

        var note = await _db.Notes.FirstOrDefaultAsync(w => w.Title == title && w.AppUserId == userID);
        return note;
    }

    public async Task<Notes> CreateOrEditNoteAsync(NoteDto note)
    {
        if (note == null)
        {
            throw new ArgumentNullException("The note is null");
        }

        var savedNote =
            await _db.Notes.FirstOrDefaultAsync(w => w.Title == note.Title && w.AppUserId == note.AppUserId);

        if (savedNote != null)
        {
            savedNote.Content = note.Content;
            savedNote.LastModified = DateTime.Now;
        }
        else
        {
            savedNote = new() { AppUserId = note.AppUserId,
                                Title = note.Title,
                                Content = note.Content,
                                LastModified = DateTime.Now,
                                Created = DateTime.Now };
            _db.Notes.Add(savedNote);
        }

        await _db.SaveChangesAsync();
        return savedNote;
    }
}
