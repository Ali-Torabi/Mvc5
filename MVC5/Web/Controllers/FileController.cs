using System.ComponentModel;
using System.Web.Mvc;
using Common.Controller;
using Common.Filters;
using ServiceLayer.Security;

namespace Web.Controllers
{
    public partial class FileController : BaseController
    {
        [DisplayName("دسترسی به تصاویر")]
        [Mcv5Authorize(AssignableToRolePermissions.CanAccessImages)]
        public virtual ActionResult Image(string name)
        {
            return View();
        }
        [DisplayName("دسترسی به فایل های ارسالی")]
        [Mcv5Authorize(AssignableToRolePermissions.CanAccessUsersFiles)]
        public virtual ActionResult UserFile(string name)
        {
            return View();
        }
        [DisplayName("دسترسی به تصاویر کاربران")]
        [Mcv5Authorize(AssignableToRolePermissions.CanAccessUsersAvatar)]
        public virtual ActionResult Avatar(string name)
        {
            return View();
        }
    }
}
