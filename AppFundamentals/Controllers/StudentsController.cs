using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppFundamentals.Entities;
using AppFundamentals.Contexts;

namespace AppFundamentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var students =  await _context.Students.ToListAsync();
            
            if (!students.Any()) return NotFound();

            return students;
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);

            if (student == null) return NotFound();

            return student;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetStudent", new { id = student.IdStudent }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody]Student student)
        {
            if (student.IdStudent != id) return BadRequest();
            
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.IdStudent == id);
            if (student == null) BadRequest();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }
    }
}
