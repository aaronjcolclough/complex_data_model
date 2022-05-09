using Microsoft.AspNetCore.Mvc;

using ComplexDataModel.Data;
using ComplexDataModel.Data.Entities.Names;
using ComplexDataModel.Data.Extensions;

namespace COmplexDataModel.Web.Controllers
{
    [Route("api/[controller]")]
    public class NameController : Controller
    {
        private readonly AppDbContext db;

        public NameController(AppDbContext db)
        {
            this.db = db;
        }

        #region GivenName

        [HttpPost("[action]/{name}")]
        public async Task<GivenName> GetGivenName([FromBody] string name) => await db.GetGivenName(name);

        [HttpPost("[action]")]
        public async Task SaveGivenName([FromBody] GivenName gn) => await db.SaveGivenName(gn);

        [HttpPost("[action]")]
        public async Task RemoveGivenName([FromBody] GivenName gn) => await db.RemoveGivenName(gn);

        #endregion
        #region Surname

        [HttpPost("[action]")]
        public async Task<Surname> GetSurname([FromBody] string name) => await db.GetSurname(name);

        [HttpPost("[action]")]
        public async Task SaveSurname([FromBody] Surname s) => await db.SaveSurname(s);

        [HttpPost("[action]")]
        public async Task RemoveSurname([FromBody] Surname s) => await db.RemoveSurname(s);

        #endregion
    }
}