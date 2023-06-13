using Microsoft.AspNetCore.Mvc;
using NoteApp.Api.Data;
using NoteApp.Api.Dtos;
using NoteApp.Api.Services;

namespace NoteApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly NoteService _noteService;

    public NoteController(NoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet("GetNote")]
    public async Task<Notes> GetNote(NoteDto note)
    {
        return await _noteService.GetNoteAsync(note.Title, note.AppUserId);
    }

    [HttpPost("CreateOrEditNote")]
    public async Task<Notes> CreateOrEditNote(NoteDto note)
    {
        return await _noteService.CreateOrEditNoteAsync(note);
    }
}
