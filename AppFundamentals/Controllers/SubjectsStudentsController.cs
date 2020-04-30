using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppFundamentals.Contexts;
using AppFundamentals.Entities;

namespace AppFundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsStudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectsStudentsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectStudent>>> Get()
        {
            var subjectsStudents = await _context.SubjectsStudents.ToListAsync();

            if (!subjectsStudents.Any()) return NotFound();

            return subjectsStudents;
        }

        [HttpGet("{idSubject}/{idStudent}", Name = "GetSubjectStudent")]
        public async Task<ActionResult<SubjectStudent>> Get(int idSubject, int idStudent)
        {
            var subjectsStudents = await _context.SubjectsStudents.FirstOrDefaultAsync(x => x.IdSubject == idSubject && x.IdStudent == idStudent);

            if (subjectsStudents == null) return NotFound();

            return subjectsStudents;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectStudent subjectStudent)
        {
            await _context.SubjectsStudents.AddAsync(subjectStudent);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult
                ("GetSubjectStudent", new { idSubject = subjectStudent.IdSubject, idStudent = subjectStudent.IdStudent }, subjectStudent);
        }

        [HttpPut("{idSubject}/{idStudent}")]
        public async Task<ActionResult> Put(int idSubject, int idStudent, [FromBody]SubjectStudent subjectStudent)
        {
           if (subjectStudent.IdStudent != idStudent && subjectStudent.IdSubject != idSubject) return BadRequest();

            _context.Entry(subjectStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idSubject}/{idStudent}")]
        public async Task<ActionResult<SubjectStudent>> Delete(int idSubject, int idStudent)
        {
            var subjectStudent = await _context.SubjectsStudents.FirstOrDefaultAsync(x => x.IdStudent == idStudent && x.IdSubject == idSubject);

            if (subjectStudent == null) BadRequest();

            _context.SubjectsStudents.Remove(subjectStudent);
            await _context.SaveChangesAsync();
            
            return subjectStudent;
        }
    }
}
