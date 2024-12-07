using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<UsersController> _logger;

        // Constructor to inject DataContext and ILogger
        public UsersController(DataContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            try
            {
                _logger.LogInformation("Getting list of users from the database.");
                var users = await _context.Users.ToListAsync();
                
                if (users == null || users.Count == 0)
                {
                    _logger.LogWarning("No users found in the database.");
                    return NotFound();
                }
                
                _logger.LogInformation("Successfully retrieved users.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting users: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            try
            {
                _logger.LogInformation($"Getting user with ID {id} from the database.");
                var user = await _context.Users.FindAsync(id);
                
                if (user == null)
                {
                    _logger.LogWarning($"User with ID {id} not found.");
                    return NotFound();
                }

                _logger.LogInformation($"Successfully retrieved user with ID {id}.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting user with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
