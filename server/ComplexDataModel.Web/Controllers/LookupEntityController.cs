using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities;
using ComplexDataModel.Data.Entities.Names;
using ComplexDataModel.Data.Extensions;

namespace ComplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class LookupEntityController : Controller
    {
        private readonly AppDbContext db;

        public LookupEntityController(AppDbContext db)
        {
            this.db = db;
        }

        #region GivenName

        [HttpGet("[action]")]
        public async Task<List<GivenName>> GetGivenNames() => await db.GetMany<GivenName>();

        [HttpGet("[action]/{id}")]
        public async Task<GivenName> GetGivenName([FromRoute] int id) => await db.Get<GivenName>(id);

        [HttpPost("[action]")]
        public async Task SaveGivenName([FromBody] GivenName gn) => await gn.Save(db);

        [HttpPost("[action]")]
        public async Task RemoveGivenName([FromBody] GivenName gn) => await gn.Remove(db);

        #endregion
    }
}