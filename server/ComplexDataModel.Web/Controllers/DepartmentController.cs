using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Extensions;

namespace ComplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext db;

        public DepartmentController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<Department>> GetDepartments() => await db.GetDepartments();

        [HttpGet("[action]/{id}")]
        public async Task<Department> GetDepartment([FromRoute] int id) => await db.GetDepartment(id);

        [HttpPost("[action]")]
        public async Task SaveDepartment([FromBody] Department d) => await db.SaveDepartment(d);

        [HttpPost("[action]")]
        public async Task RemoveDepartment([FromBody] Department d) => await db.RemoveDepartment(d);
    }
}