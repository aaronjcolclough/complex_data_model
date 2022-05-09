using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Extensions;

namespace COmplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly AppDbContext db;

        public CourseController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<Course>> GetAllCourses() => await db.GetAllCourses();

        [HttpGet("[action]/{name}")]
        public async Task<List<Course>> GetDepartmentCourses([FromRoute] string name) =>
            await db.GetDepartmentCourses(name);

        [HttpPost("[action]")]
        public async Task<Course> GetCourse([FromBody] CourseId id) => await db.GetCourse(id);

        [HttpPost("[action]")]
        public async Task SaveCourse([FromBody] Course c) => await db.SaveCourse(c);

        [HttpPost("[action]")]
        public async Task RemoveCourse([FromBody] Course c) => await db.RemoveCourse(c);
    }
}