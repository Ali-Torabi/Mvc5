using System.ComponentModel;
using System.Web.Mvc;
using Common.Filters;
using ServiceLayer.Security;
using Common.Controller;

namespace Web.Areas.Administrator.Controllers
{
    public partial class HomeController : BaseController
    {
        [Mcv5Authorize(AssignableToRolePermissions.CanViewAdminPanel)]
        [DisplayName("مشاهده پنل مدیریت")]
        public virtual ActionResult Index()
        {

            return View();
        }
    }
}