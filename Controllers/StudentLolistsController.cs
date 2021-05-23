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
    public class StudentLolistsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentLolistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentLolists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentLolist>>> GetStudentLolists()
        {
            return await _context.StudentLolists.ToListAsync();
        }

        // GET: api/StudentLolists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentLolist>> GetStudentLolist(Guid id)
        {
            var studentLolist = await _context.StudentLolists.FindAsync(id);

            if (studentLolist == null)
            {
                return NotFound();
            }

            return studentLolist;
        }

        // PUT: api/StudentLolists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentLolist(Guid id, StudentLolist studentLolist)
        {
            if (id != studentLolist.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentLolist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentLolistExists(id))
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

        // POST: api/StudentLolists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentLolist>> PostStudentLolist(StudentLolist studentLolist)
        {
            _context.StudentLolists.Add(studentLolist);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentLolistExists(studentLolist.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentLolist", new { id = studentLolist.StudentId }, studentLolist);
        }

        // DELETE: api/StudentLolists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentLolist>> DeleteStudentLolist(Guid id)
        {
            var studentLolist = await _context.StudentLolists.FindAsync(id);
            if (studentLolist == null)
            {
                return NotFound();
            }

            _context.StudentLolists.Remove(studentLolist);
            await _context.SaveChangesAsync();

            return studentLolist;
        }

        private bool StudentLolistExists(Guid id)
        {
            return _context.StudentLolists.Any(e => e.StudentId == id);
        }
    }
}
