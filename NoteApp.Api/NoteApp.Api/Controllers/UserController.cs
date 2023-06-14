using Microsoft.AspNetCore.Mvc;
using NoteApp.Api.Services;

namespace NoteApp.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUser")]
    public async Task<string> GetUser(string username)
    {
        return await _userService.GetUserIdAsync(username);
    }
}