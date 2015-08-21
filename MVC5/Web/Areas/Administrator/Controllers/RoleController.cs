using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Common.Controller;
using Common.Filters;
using DataLayer.Context;
using ServiceLayer.Contracts;
using ServiceLayer.Security;
using ViewModel.AdminArea.Role;
using Web.Extentions;
using WebGrease.Css.Extensions;

namespace Web.Areas.Administrator.Controllers
{

    public partial class RoleController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRoleManager _roleManager;

        #endregion

        #region Const

        public RoleController(IUnitOfWork unitOfWork, IApplicationRoleManager roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        #endregion

        #region ListAjax , List
        [HttpGet]
        [Mcv5Authorize(AssignableToRolePermissions.CanViewRolesList)]
        [DisplayName("مشاهده لیست گروه های کاربری")]
        [ActivityLog(Name = "ViewRoles", Description = "مشاده گروه های کاربری")]
        public virtual ActionResult List()
        {
            return View();
        }

        //[CheckReferrer]
        [Mcv5Authorize(AssignableToRolePermissions.CanViewRolesList)]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult ListAjax(string term = "", int page = 1)
        {
            int total;
            var roles = _roleManager.GetPageList(out total, term, page, 5);
            ViewBag.TotalRoles = total;
            ViewBag.PageNumber = page;
            return PartialView(MVC.Administrator.Role.Views.ViewNames._ListAjax, roles);
        }
        #endregion

        #region Create

        [HttpGet]
        [Mcv5Authorize(AssignableToRolePermissions.CanCreateRole)]
        [DisplayName("ثبت گروه کاربری جدید")]
        [ActivityLog(Name = "CreateRole", Description = "درج گروه کاربری")]
        public virtual ActionResult Create()
        {
            var viewModel = new AddRoleViewModel
            {
                IsActive = true
            };
            PopulatePermissions();
            return View(viewModel);
        }
        [HttpPost]
        [Mcv5Authorize(AssignableToRolePermissions.CanCreateRole)]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        public virtual async Task<ActionResult> Create(AddRoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                this.NotyError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                PopulatePermissions(viewModel.PermissionNames);
                return View(viewModel);
            }
            if (!await _roleManager.AddRole(viewModel))
            {
                this.NotyWarning("لطفا برای گروه کاربری مورد نظر ، دسترسی تعیین کنید");
                PopulatePermissions();
                return View(viewModel);
            }

            await _unitOfWork.SaveChangesAsync();
            this.NotySuccess("عملیات ثبت گروه کاربری جدید با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region Edit
        [HttpGet]
        [DisplayName("ویرایش گروه کاربری")]
        [Mcv5Authorize(AssignableToRolePermissions.CanEditRole)]
        [ActivityLog(Name = "EditRole", Description = " ویرایش گروه کاربری")]
        //[Route("Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var viewModel = await _roleManager.GetRoleByPermissionsAsync(id.Value);
            if (viewModel == null)
                return HttpNotFound();
            PopulatePermissions(viewModel.PermissionNames);
            return View(viewModel);
        }

        //[Route("Edit/{id}")]
        [Mcv5Authorize(AssignableToRolePermissions.CanEditRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        public virtual async Task<ActionResult> Edit(EditRoleViewModel viewModel)
        {
            if (_roleManager.ChechForExisByName(viewModel.Name, viewModel.Id))
                this.AddErrors("Name", "این گروه  قبلا در سیستم ثبت شده است");

            if (!ModelState.IsValid)
            {
                this.NotyError("لطفا فیلد های مورد نظر را با دقت وارد کنید");
                PopulatePermissions(viewModel.PermissionNames);
                return View(viewModel);
            }

            var dbRole = await _roleManager.FindByIdAsync(viewModel.Id);
            if (dbRole == null)
                return HttpNotFound();

            if (!await _roleManager.EditRole(viewModel))
            {
                this.NotyWarning("لطفا برای گروه کاربری مورد نظر ، دسترسی تعیین کنید");
                PopulatePermissions();
                return View(viewModel);
            }
            await _unitOfWork.SaveChangesAsync();
            this.NotySuccess("عملیات ویرایش گروه کاربری  با موفقیت انجام شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region Delete

        [HttpPost]
        //[Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        //[CheckReferrer]
        [Mcv5Authorize(AssignableToRolePermissions.CanDeleteRole)]
        [DisplayName("حذف گروه کاربری")]
        [ActivityLog(Name = "DeleteRole", Description = " حذف گروه کاربری")]
        public virtual async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (await _roleManager.CheckRoleIsSystemRoleAsync(id.Value))
            {
                this.NotyWarning("این گروه کاربری سیستمی است و حذف آن باعث اختلال در سیستم خواهد شد");
                return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
            }
            await _roleManager.RemoveById(id.Value);
            this.NotySuccess("گروه مورد نظر با موفقیت حذف شد");
            return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        }

        #endregion

        #region SetAsDefaultRegisterRole
        //[HttpPost]
        //[AjaxOnly]
        //[ValidateAntiForgeryToken]
        ////[CheckReferrer]
        //[DotNetCmsAuthorize(AssignableToRolePermissions.CanSetDefaultRoleForRegister)]
        //[DisplayName("تغییر گروه کاربری پیش فرض")]
        //[Route("SetForRegister/{id}")]
        //[ActivityLog(Name = "SetDefaultRoleForRegister", Description = "انتخاب گروه کاربری پیشفرض برای ثبت نام کاربران")]
        //public virtual async Task<ActionResult> SetRoleForRegister(int? id)
        //{
        //    if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    await _roleManager.SetRoleAsRegistrationDefaultRoleAsync(id.Value);
        //    await _unitOfWork.SaveChangesAsync();
        //    NotySuccess("گروه کاربری مورد نظر با موفقیت به عنوان گروه کاربری پیشفرض ثبت نام انتخاب شد");
        //    return RedirectToAction(MVC.Administrator.Role.ActionNames.List, MVC.Administrator.Role.Name);
        //}
        #endregion

        #region RemoteValidation

        [HttpPost]
        [AjaxOnly]
        // [CheckReferrer]
        [Mcv5Authorize(AssignableToRolePermissions.CanCreateRole, AssignableToRolePermissions.CanEditRole)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual JsonResult RoleNameExist(string name, int? id)
        {
            return _roleManager.ChechForExisByName(name, id) ? Json(false) : Json(true);
        }

        #endregion

        #region Private
        [NonAction]
        private void PopulatePermissions(params string[] selectedpermissions)
        {
            var permissions = AssignableToRolePermissions.GetAsSelectListItems();

            if (selectedpermissions != null)
            {
                permissions.ForEach(
                    a => a.Selected = selectedpermissions.Any(s => s == a.Value));
            }

            ViewBag.Permissions = permissions;
        }

        #endregion
    }
}