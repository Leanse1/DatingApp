using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// ASP.NET Core automatically strips the "Controller" part in UserController, leaving "Users" to be added in path
[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase
{
    // HTTP GET request for /api/users
    [HttpGet]
    //GetUsers() - simple GET controller action that retrieves all users from the database
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        return users;
    }
    // HTTP GET request for /api/users/1
    [HttpGet("{id:int}")]  // /api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }
}