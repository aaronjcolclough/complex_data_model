using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Extensions;

namespace ComplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly AppDbContext db;

        public PersonController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<Person>> GetPeople() => await db.GetPeople<Person>();

        [HttpGet("[action]")]
        public async Task<List<Student>> GetStudents() => await db.GetPeople<Student>();

        [HttpGet("[action]")]
        public async Task<List<Instructor>> GetInstructors() => await db.GetPeople<Instructor>();

        [HttpGet("[action]/{id}")]
        public async Task<Student> GetStudent([FromRoute] int id) => await db.GetPerson<Student>(id);

        [HttpGet("[action]/{id}")]
        public async Task<Instructor> GetInstructor([FromRoute] int id) => await db.GetPerson<Instructor>(id);

        [HttpPost("[action]")]
        public async Task SaveStudent([FromBody] Student p) => await db.SavePerson<Student>(p);
        [HttpPost("[action]")]
        public async Task SaveInstructor([FromBody] Instructor p) => await db.SavePerson<Instructor>(p);

        [HttpPost("[action]")]
        public async Task RemovePerson([FromBody] Person p) => await db.RemovePerson(p);
    }
}