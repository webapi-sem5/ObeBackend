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
    public class AssessmentStudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssessmentStudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AssessmentStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssessmentStudent>>> GetAssessmentStudents()
        {
            return await _context.AssessmentStudents.Include(c => c.Assessment).Include(c => c.Student).ToListAsync();
        }

        // GET: api/AssessmentStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentStudent>> GetAssessmentStudent(Guid id)
        {
            var assessmentStudent = await _context.AssessmentStudents.FindAsync(id);

            if (assessmentStudent == null)
            {
                return NotFound();
            }

            return assessmentStudent;
        }

        // PUT: api/AssessmentStudents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentStudent(Guid id, AssessmentStudent assessmentStudent)
        {
            if (id != assessmentStudent.AssessmentId)
            {
                return BadRequest();
            }

            _context.Entry(assessmentStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentStudentExists(id))
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

        // POST: api/AssessmentStudents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssessmentStudent>> PostAssessmentStudent(AssessmentStudent assessmentStudent)
        {
            _context.AssessmentStudents.Add(assessmentStudent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssessmentStudentExists(assessmentStudent.AssessmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssessmentStudent", new { id = assessmentStudent.AssessmentId }, assessmentStudent);
        }

        // DELETE: api/AssessmentStudents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssessmentStudent>> DeleteAssessmentStudent(Guid id)
        {
            var assessmentStudent = await _context.AssessmentStudents.FindAsync(id);
            if (assessmentStudent == null)
            {
                return NotFound();
            }

            _context.AssessmentStudents.Remove(assessmentStudent);
            await _context.SaveChangesAsync();

            return assessmentStudent;
        }

        private bool AssessmentStudentExists(Guid id)
        {
            return _context.AssessmentStudents.Any(e => e.AssessmentId == id);
        }
    }
}
