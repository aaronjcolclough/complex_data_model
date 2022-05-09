using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Extensions;

namespace COmplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext db;

        public EnrollmentController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<Enrollment>> GetEnrollments() => await db.GetEnrollments();

        [HttpGet("[action]/{id}")]
        public async Task<Enrollment> GetEnrollment([FromBody] int id) => await db.GetEnrollment(id);

        [HttpPost("[action]")]
        public async Task SaveEnrollment([FromBody] Enrollment e) => await db.SaveEnrollment(e);

        [HttpPost("[action]")]
        public async Task RemoveEnrollment([FromBody] Enrollment e) => await db.RemoveEnrollment(e);
    }
}