using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDEntrainement.Models.EntityFramework;

namespace TDEntrainement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiquesController : ControllerBase
    {
        private readonly TDEntrainementContext _context;

        public MusiquesController(TDEntrainementContext context)
        {
            _context = context;
        }

        // GET: api/Musiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musique>>> GetMusiques()
        {
          if (_context.Musiques == null)
          {
              return NotFound();
          }
            return await _context.Musiques.ToListAsync();
        }

        // GET: api/Musiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musique>> GetMusique(int id)
        {
          if (_context.Musiques == null)
          {
              return NotFound();
          }
            var musique = await _context.Musiques.FindAsync(id);

            if (musique == null)
            {
                return NotFound();
            }

            return musique;
        }

        // PUT: api/Musiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusique(int id, Musique musique)
        {
            if (id != musique.Idmusique)
            {
                return BadRequest();
            }

            _context.Entry(musique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusiqueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Musiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musique>> PostMusique(Musique musique)
        {
          if (_context.Musiques == null)
          {
              return Problem("Entity set 'TDEntrainementContext.Musiques'  is null.");
          }
            _context.Musiques.Add(musique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusique", new { id = musique.Idmusique }, musique);
        }

        // DELETE: api/Musiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusique(int id)
        {
            if (_context.Musiques == null)
            {
                return NotFound();
            }
            var musique = await _context.Musiques.FindAsync(id);
            if (musique == null)
            {
                return NotFound();
            }

            _context.Musiques.Remove(musique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusiqueExists(int id)
        {
            return (_context.Musiques?.Any(e => e.Idmusique == id)).GetValueOrDefault();
        }
    }
}
