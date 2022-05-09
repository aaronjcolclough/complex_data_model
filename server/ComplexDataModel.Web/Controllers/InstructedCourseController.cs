using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Extensions;

namespace COmplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class InstructedCourseController : Controller
    {
        private readonly AppDbContext db;

        public InstructedCourseController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<InstructedCourse>> GetInstructedCourses() => await db.GetInstructedCourses();

        [HttpGet("[action]/{id}")]
        public async Task<InstructedCourse> GetInstructedCourse([FromRoute] int id) => await db.GetInstructedCourse(id);

        [HttpPost("[action]")]
        public async Task SaveInstructedCourse([FromBody] InstructedCourse ic) => await db.SaveInstructedCourse(ic);

        [HttpPost("[action]")]
        public async Task RemoveInstructedCourse([FromBody] InstructedCourse ic) => await db.RemoveInstructedCourse(ic);
    }
}