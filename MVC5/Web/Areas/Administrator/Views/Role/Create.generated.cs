﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
    using Common.Helpers;
    
    #line default
    #line hidden
    using Web;
    
    #line 2 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
    using Web.RazorHelpers;
    
    #line default
    #line hidden
    using StackExchange.Profiling;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Administrator/Views/Role/Create.cshtml")]
    public partial class _Areas_Administrator_Views_Role_Create_cshtml : System.Web.Mvc.WebViewPage<ViewModel.AdminArea.Role.AddRoleViewModel>
    {
        public _Areas_Administrator_Views_Role_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
  
    ViewBag.Title = "درج گروه کاربری کاربری";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
        
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
         using (Html.BeginForm(MVC.Administrator.Role.ActionNames.Create, MVC.Administrator.Role.Name, new { area = MVC.Administrator.Name }, FormMethod.Post, new { role = "form", @class = "form-horizontal", autocomplete = "off", id = "createRoleForm" }))
        {
            
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                                    

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    <strong>مشخصات گروه</strong>\r\n                </div>\r\n    " +
"            <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 19 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.LabelFor(m => m.Name, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 21 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                       Write(Html.NoAutoCompleteTextBoxFor(m => m.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 22 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                       Write(Html.ValidationMessageFor(m => m.Name, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 26 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                   Write(Html.LabelFor(m => m.Description, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 28 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                       Write(Html.NoAutoCompleteTextBoxFor(m => m.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 29 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                       Write(Html.ValidationMessageFor(m => m.Description, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"col-md-2 col-md-offset-2\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 35 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                           Write(Html.CheckBoxFor(m => m.IsActive, new { @class = "checkbox-inline" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 36 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
                           Write(Html.LabelFor(m => m.IsActive, new { @class = "control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </div>\r\n\r\n                        </div>\r\n\r\n       " +
"             </div>\r\n                </div>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    <strong>دسترسی ها</strong>\r\n                </div>\r\n      " +
"          <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 49 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
               Write(CheckBoxListBuilder.CheckBoxList("PermissionNames", ViewBag.Permissions));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"panel-footer\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" autocomplete=\"off\"");

WriteLiteral(" onclick=\"AjaxForm.CustomSubmit(this, \'createRoleForm\')\"");

WriteLiteral(" data-loading-text=\"در حال ارسال اطلاعات\"");

WriteLiteral(" class=\"btn btn-success btn-block\"");

WriteLiteral(">\r\n                                ثبت گروه کاربری\r\n                            <" +
"/button>\r\n                        </div>\r\n                    </div>\r\n\r\n        " +
"        </div>\r\n            </div>\r\n");

            
            #line 62 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 66 "..\..\Areas\Administrator\Views\Role\Create.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            warningBeforeLoad();\r\n      " +
"  })\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
