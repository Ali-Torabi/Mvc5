using System;
using System.Collections.Generic;

namespace ServiceLayer.Security
{
    public  class PermissionRecord
    {
        public string RoleName { get; set; }
        public IEnumerable<PermissionModel> Permissions { get; set; }
    }
}
