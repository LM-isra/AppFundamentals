using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppFundamentals.Contexts;
using AppFundamentals.Entities;

namespace AppFundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsTeachersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectsTeachersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectTeacher>>> Get() 
        {
            var subjectsTeachers = await _context.SubjectsTeachers.ToListAsync();

            if (!subjectsTeachers.Any()) return NotFound();

            return subjectsTeachers;
        }

        [HttpGet("{idSubject}/{idTeacher}", Name = "GetSubjectTeacher")]
        public async Task<ActionResult<SubjectTeacher>> Get(int idSubject, int idTeacher)
        {
            var subjectTeacher =  await _context.SubjectsTeachers.FirstOrDefaultAsync(x => x.IdSubject == idSubject && x.IdTeacher == idTeacher);

            if (subjectTeacher == null) return NotFound();

            return subjectTeacher;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectTeacher subjectTeacher)
        {
            await _context.SubjectsTeachers.AddAsync(subjectTeacher);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetSubjectTeacher", new { idSubject = subjectTeacher.IdSubject, idTeacher = subjectTeacher.IdTeacher }, subjectTeacher);
        }

        [HttpPut("{idSubject}/{idTeacher}")]
        public async Task<ActionResult> Put(int idSubject, int idTeacher, [FromBody]SubjectTeacher subjectTeacher)
        {
            if (subjectTeacher.IdSubject != idSubject && subjectTeacher.IdTeacher != idTeacher) return NotFound();

            _context.Entry(subjectTeacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idSubject}/{idTeacher}")]
        public async Task<ActionResult<SubjectTeacher>> Delete(int idSubject, int idTeacher)
        {
            var subjectTeacher = await _context.SubjectsTeachers.FirstOrDefaultAsync(x => x.IdSubject == idSubject && x.IdTeacher == idTeacher);
            
            if (subjectTeacher == null) return NotFound();

            _context.SubjectsTeachers.Remove(subjectTeacher);
            await _context.SaveChangesAsync();

            return subjectTeacher;
        }
    }
}

