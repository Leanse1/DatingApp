using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// A DbContext instance represents a session with the database and can be used to query and save instances of entities.
public class DataContext(DbContextOptions options) : DbContext(options)
{
    // Name of Table --> Users which use id of appuser as primary key
    public DbSet<AppUser> Users { get; set; }
}

