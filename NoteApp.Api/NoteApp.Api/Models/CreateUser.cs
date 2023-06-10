namespace NoteApp.Api.Models;

public class CreateUser : UserCredentials
{
    public CreateUser(string username, string password) : base(username, password)
    { }
}
