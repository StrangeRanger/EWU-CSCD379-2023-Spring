using Microsoft.EntityFrameworkCore;
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

    public async Task<Notes?> GetNoteAsync(int noteId)
    {
        return await _db.Notes.FirstOrDefaultAsync(w => w.NoteId == noteId);
    }

    public async Task<Notes> CreateOrEditNoteAsync(NoteDto note)
    {
        if (note == null)
        {
            throw new ArgumentNullException("The note is null");
        }
    
        var savedNote =
            await _db.Notes.FirstOrDefaultAsync(w => w.Title == note.Title && w.AppUserId == note.AppUserId);
        var urlService = new UrlService(_db);
    
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
                                UrlSuffix =  urlService.GenerateUniqueUrlSuffixAsync().Result,
                                Created = DateTime.Now };
            _db.Notes.Add(savedNote);
        }
    
        await _db.SaveChangesAsync();
        return savedNote;
    }
}
