using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteRouteAPI.Data;
using WasteRouteAPI.Models;

namespace WasteRouteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionPointsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CollectionPointsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionPoint>>> GetAll()
        {
            return await _context.CollectionPoints.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionPoint>> GetById(int id)
        {
            var point = await _context.CollectionPoints.FindAsync(id);
            if (point == null) return NotFound();
            return point;
        }

        [HttpGet("wastetype/{type}")]
        public async Task<ActionResult<IEnumerable<CollectionPoint>>> GetByWasteType(string type)
        {
            return await _context.CollectionPoints
                .Where(p => p.WasteType == type)
                .ToListAsync();
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<CollectionPoint>>> GetByStatus(string status)
        {
            return await _context.CollectionPoints
                .Where(p => p.Status == status)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CollectionPoint>> Create(CollectionPoint point)
        {
            _context.CollectionPoints.Add(point);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = point.Id }, point);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var point = await _context.CollectionPoints.FindAsync(id);
            if (point == null) return NotFound();
            point.Status = status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var point = await _context.CollectionPoints.FindAsync(id);
            if (point == null) return NotFound();
            _context.CollectionPoints.Remove(point);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}