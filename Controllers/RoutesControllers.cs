using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteRouteAPI.Data;
using WasteRouteAPI.Models;

namespace WasteRouteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoutesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WasteRoute>>> GetAll()
        {
            return await _context.Routes
                .Include(r => r.Vehicle)
                .Include(r => r.CollectionPoints)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WasteRoute>> GetById(int id)
        {
            var route = await _context.Routes
                .Include(r => r.Vehicle)
                .Include(r => r.CollectionPoints)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (route == null) return NotFound();
            return route;
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<WasteRoute>>> GetByStatus(string status)
        {
            return await _context.Routes
                .Include(r => r.Vehicle)
                .Include(r => r.CollectionPoints)
                .Where(r => r.Status == status)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<WasteRoute>> Create(WasteRoute route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = route.Id }, route);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) return NotFound();
            route.Status = status;
            if (status == "Completed")
                route.CompletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) return NotFound();
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}