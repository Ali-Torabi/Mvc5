using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common.Controller;
using Common.Controller.NotyHelper;

namespace Common.Controller
{
    public class BaseController : System.Web.Mvc.Controller
    {
        #region Validation
        [ChildActionOnly]
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        #endregion

    }
}

