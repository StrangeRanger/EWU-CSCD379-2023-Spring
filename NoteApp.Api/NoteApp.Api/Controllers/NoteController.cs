using Microsoft.AspNetCore.Mvc;
using NoteApp.Api.Data;
using NoteApp.Api.Dtos;
using NoteApp.Api.Services;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("Note")]
public class NoteController : ControllerBase
{
    private readonly NoteService _noteService;

    public NoteController(NoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public async Task<Notes?> GetNote(int noteId)
    {
        return await _noteService.GetNoteAsync(noteId);
    }

    [HttpPost("CreateOrEditNote")]
    public async Task<Notes> CreateOrEditNote(NoteDto note)
    {
        return await _noteService.CreateOrEditNoteAsync(note);
    }
}
