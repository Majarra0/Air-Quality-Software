using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication8.Data;

[Route("api/[controller]")]
[ApiController]
public class MigrationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly dbContext _context;

    public MigrationController(IConfiguration configuration, dbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    // GET: api/migration/apply
    [HttpGet("apply")]
    public IActionResult ApplyMigrations()
    {
        try
        {
            // Apply migrations
            _context.Database.Migrate();
            return Ok("Migrations applied successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error applying migrations: {ex.Message}");
        }
    }
}
