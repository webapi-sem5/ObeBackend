using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LolistPosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LolistPosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LolistPos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LolistPo>>> GetLolistPos()
        {
            return await _context.LolistPos
                .Include(c => c.Lolist)
                .Include(c => c.Polist)
                .ToListAsync();
        }

        // GET: api/LolistPos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LolistPo>> GetLolistPo(Guid id)
        {
            var lolistPo = await _context.LolistPos.FindAsync(id);

            if (lolistPo == null)
            {
                return NotFound();
            }

            return lolistPo;
        }

        // PUT: api/LolistPos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLolistPo(Guid id, LolistPo lolistPo)
        {
            if (id != lolistPo.LolistId)
            {
                return BadRequest();
            }

            _context.Entry(lolistPo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LolistPoExists(id))
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

        // POST: api/LolistPos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LolistPo>> PostLolistPo(LolistPo lolistPo)
        {
            _context.LolistPos.Add(lolistPo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LolistPoExists(lolistPo.LolistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLolistPo", new { id = lolistPo.LolistId }, lolistPo);
        }

        // DELETE: api/LolistPos/5
        [HttpDelete("{id}")]
        public  ActionResult<LolistPo> DeleteLolistPo(Guid id)
        {
            var lolistPo =  _context.LolistPos.FirstOrDefault(e => e.PolistId == id);
            if (lolistPo == null)
            {
                return NotFound();
            }

            _context.LolistPos.Remove(lolistPo);
             _context.SaveChanges();

            return lolistPo;
        }

        private bool LolistPoExists(Guid id)
        {
            return _context.LolistPos.Any(e => e.LolistId == id);
        }
    }
}
