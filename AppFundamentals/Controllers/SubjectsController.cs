using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AppFundamentals.Contexts;
using AppFundamentals.Entities;

namespace AppFundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> Get() 
        {
            var subjects = await _context.Subjects.ToListAsync();
            
            if (!subjects.Any()) return NotFound();

            return subjects;
        }

        [HttpGet("{id}", Name = "GetSubject")]
        public async Task<ActionResult<Subject>> Get(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.IdSubject == id);
            if (subject == null) NotFound();

            return subject;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetSubject", new { id = subject.IdSubject }, subject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Subject subject)
        {
            if (subject.IdSubject != id) return BadRequest();

            _context.Entry(subject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> Delete(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.IdSubject == id);
            if (subject == null) return NotFound();

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return subject;
        }
    }
}
