using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NoteApp.Api.Data;
using NoteApp.Api.Dtos;

namespace NoteApp.Api.Services;

public class UserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<string> GetUserIdAsync(string username)
    {

        var user = await _db.Users.FirstOrDefaultAsync(w => w.UserName == username);

        return user.Id;

    }

}