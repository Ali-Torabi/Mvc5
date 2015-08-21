using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace ServiceLayer.Security
{
    public static class AssignableToRolePermissions
    {
        #region Fields

        private static Lazy<IEnumerable<PermissionModel>> _permissionsLazy =
            new Lazy<IEnumerable<PermissionModel>>(GetPermision, LazyThreadSafetyMode.ExecutionAndPublication);

        private static Lazy<IEnumerable<string>> _permissionNamesLazy = new Lazy<IEnumerable<string>>(
            GetPermisionNames, LazyThreadSafetyMode.ExecutionAndPublication);
        #endregion

        #region permissionNames
        public static bool AllowSendPrivateMessage { get; set; }
        public static bool AllowSendNewsItem { get; set; }
        public static bool AllowSendBlogPostDraft { get; set; }
        public static bool AllowSendPollItem { get; set; }
        public static bool AllowSendFriendRequest { get; set; }
        public static bool CanUploadFile { get; set; }
        public static bool CanChangeProfilePicture { get; set; }
        public static bool CanModifyFirsAndLastName { get; set; }
        public const string CanEditRole = "CanEditRole";
        public const string CanDeleteRole = "CanDeleteRole";
        public const string CanViewRolesList = "CanViewRolesList";
        public const string CanCreateRole = "CanCreateRole";
        public const string CanEditUser = "CanEditUser";
        public const string CanCreateUser = "CanCreateUser";
        public const string CanDeleteUser = "CanDeleteUser";
        public const string CanSoftDeleteUser = "CanSoftDeleteUser";
        public const string CanViewUsersList = "CanViewUsersList";
        public const string CanEditUsersSetting = "CanEditUsersSetting";
        public const string CanAccessImages = "CanAccessImages";
        public const string CanViewAdminPanel = "CanViewAdminPanel";
        public const string CanAccessUsersFiles = "CanAccessUsersFiles";
        public const string CanAccessUsersAvatar = "CanAccessUsersAvatar";
        #endregion //permissions

        #region Permissions

        public static readonly PermissionModel CanEditRolePermission = new PermissionModel { Name = CanEditRole, Description = "میتوانند گروه کاربری را ویرایش کنند" };
        public static readonly PermissionModel CanDeleteRolePermission = new PermissionModel { Name = CanDeleteRole, Description = "میتوانند گروه کاربری را حذف کنند" };
        public static readonly PermissionModel CanViewRolesListPermission = new PermissionModel { Name = CanViewRolesList, Description = "میتوانند لیست گروه های کاربری را مشاهده کنند" };
        public static readonly PermissionModel CanCreateRolePermission = new PermissionModel { Name = CanCreateRole, Description = "میتوانند گروه کاربری جدید ایجاد کنند" };
        public static readonly PermissionModel CanEditUserPermission = new PermissionModel { Name = CanEditUser, Description = "میتوانند مشخصات کاربر را ویرایش کنند" };
        public static readonly PermissionModel CanCreateUserPermission = new PermissionModel { Name = CanCreateUser, Description = "میتوانند کاربر جدید ایجاد کنند" };
        public static readonly PermissionModel CanViewUsersListPermission = new PermissionModel { Name = CanViewUsersList, Description = "میتوانند لیست کاربران را مشاهده کنند" };
        public static readonly PermissionModel CanDeleteUserPermission = new PermissionModel { Name = CanDeleteUser, Description = "میتوانند کاربر را حذف کنند" };
        public static readonly PermissionModel CanSoftDeleteUserPermission = new PermissionModel { Name = CanSoftDeleteUser, Description = "میتوانند کاربر را به صورت منطقی حذف کنند" };
        public static readonly PermissionModel CanViewAdminPanelPermission = new PermissionModel { Name = CanViewAdminPanel, Description = "میتوانند پنل مدیریت را مشاهده کنند" };
        public static readonly PermissionModel CanEditUsersSettingPermission = new PermissionModel { Name = CanEditUsersSetting, Description = "میتوانند تنظیمات کاربران را ویرایش کنند" };
        public static readonly PermissionModel CanAccessImagesPermission = new PermissionModel { Name = CanAccessImages, Description = "میتوانند به تصاویر دسترسی داشته باشند" };
        public static readonly PermissionModel CanAccessUsersAvatarPermission = new PermissionModel { Name = CanAccessUsersAvatar, Description = "میتوانند به تصاویر پروفایل کاربرن دسترسی داشته باشند" };
        public static readonly PermissionModel CanAccessUsersFilesPermission = new PermissionModel { Name = CanAccessUsersFiles, Description = "میتوانند فایل های ضمیمه شده توسط کاربران را دانلود کنند" };
        #endregion

        #region Properties
        public static IEnumerable<PermissionModel> Permissions
        {
            get
            {
                return _permissionsLazy.Value;
            }
        }

        public static IEnumerable<string> PermissionNames
        {
            get
            {
                return _permissionNamesLazy.Value;
            }
        }

        #endregion

        #region GetAllPermisions
        private static IEnumerable<PermissionModel> GetPermision()
        {
            return new List<PermissionModel>
            {
                CanAccessImagesPermission,
                CanAccessUsersAvatarPermission,
                CanAccessUsersFilesPermission,
                CanCreateRolePermission,
                CanCreateUserPermission,
                CanDeleteRolePermission,
                CanDeleteUserPermission,
                CanEditRolePermission,
                CanEditUserPermission,
                CanEditUsersSettingPermission,
                CanSoftDeleteUserPermission,
                CanViewAdminPanelPermission,
                CanViewRolesListPermission,
                CanViewUsersListPermission
            };
        }

        private static IEnumerable<string> GetPermisionNames()
        {
            return new List<string>()
            {
               CanEditRole ,
               CanDeleteRole,
               CanViewRolesList ,
               CanCreateRole ,
               CanEditUser ,
               CanCreateUser ,
               CanDeleteUser,
               CanSoftDeleteUser ,
               CanViewUsersList ,
               CanEditUsersSetting ,
               CanAccessImages ,
               CanViewAdminPanel ,
               CanAccessUsersFiles ,
               CanAccessUsersAvatar
            };
        }
        #endregion

        #region GetAsSelectedList

        public static IEnumerable<SelectListItem> GetAsSelectListItems()
        {
            return Permissions.Select(a => new SelectListItem { Text = a.Description, Value = a.Name }).ToList();
        }
        #endregion
    }
}
