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
    public class TeachersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeachersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> Get()
        {
            var teachers = await _context.Teachers.ToListAsync();

            if (!teachers.Any()) return NotFound();

            return teachers;
        }

        [HttpGet("{id}", Name = "GetTeacher")]
        public async Task<ActionResult<Teacher>> Get(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == id);

            if (teacher == null) return NotFound();

            return teacher;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetTeacher", new { id = teacher.IdTeacher }, teacher);
        }

        [HttpPut("{}id")]
        public async Task<ActionResult> Put(int id, [FromBody]Teacher teacher)
        {
            if (teacher.IdTeacher != id) return NotFound();

            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> Delete(int id) 
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.IdTeacher == id);
            if (teacher == null) return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }
    }
}
