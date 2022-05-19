using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Extensions;

namespace COmplexDataModel.Web.Controllers;

    [Route("api/[controller]")]
    public class OfficeController : Controller
    {
        private readonly AppDbContext db;

        public OfficeController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<Office>> GetOffices() => await db.GetOffices();

        [HttpGet("[action]/{id}")]
        public async Task<Office> GetOffice([FromRoute] int id) => await db.GetOffice(id);

        [HttpPost("[action]")]
        public async Task SaveOffice([FromBody] Office o) => await db.SaveOffice(o);

        [HttpPost("[action]")]
        public async Task RemoveOffice([FromBody] Office o) => await db.RemoveOffice(o);
    }