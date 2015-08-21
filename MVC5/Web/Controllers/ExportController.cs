using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using Common.Controller;
using Common.Filters;
using VikingErik.Mvc.ResumingActionResults;

namespace Web.Controllers
{
    public partial class ExportController : BaseController
    {
        [Route("Export/{*id}")]
        [DisplayName("امکان دانلود فایل ها")]
        [Mcv5Authorize]
        public virtual ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Redirect("/");
            }
            var filename = Path.GetFileName(id);
            var path = Server.MapPath("~/Export/" + filename);
            return new ResumingFilePathResult(path, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}