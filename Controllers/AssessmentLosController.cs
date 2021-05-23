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
    public class AssessmentLosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssessmentLosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AssessmentLos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssessmentLo>>> GetAssessmentLos()
        {
            return await _context.AssessmentLos.Include(c => c.Assessment).Include(c=>c.Lolist).ToListAsync();
        }

        // GET: api/AssessmentLos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AssessmentLo>>> GetAssessmentLo(Guid id)
        {
            List<AssessmentLo> items = await _context.AssessmentLos.ToListAsync();

            var assessmentLo = await _context.AssessmentLos.FindAsync(id);
             

            if (assessmentLo == null)
            {
                return NotFound();
            }

            return items;
        }

        // PUT: api/AssessmentLos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentLo(Guid id, AssessmentLo assessmentLo)
        {
            if (id != assessmentLo.LolistId)
            {
                return BadRequest();
            }

            _context.Entry(assessmentLo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentLoExists(id))
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

        // POST: api/AssessmentLos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssessmentLo>> PostAssessmentLo(AssessmentLo assessmentLo)
        {
            _context.AssessmentLos.Add(assessmentLo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssessmentLoExists(assessmentLo.LolistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssessmentLo", new { id = assessmentLo.LolistId }, assessmentLo);
        }

        // DELETE: api/AssessmentLos/5
        [HttpDelete("{id}")]
        public  ActionResult<AssessmentLo> DeleteAssessmentLo(Guid id)
        {
            var assessmentLo =  _context.AssessmentLos.FirstOrDefault(e => e.LolistId == id);
            if (assessmentLo == null)
            {
                return NotFound();
            }

            _context.AssessmentLos.Remove(assessmentLo);

            _context.SaveChanges();

            return assessmentLo;
        }

        private bool AssessmentLoExists(Guid id)
        {
            return _context.AssessmentLos.Any(e => e.LolistId == id);
        }
    }
}
