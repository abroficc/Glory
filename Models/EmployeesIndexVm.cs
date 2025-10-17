using System;
using System.Collections.Generic;
using ASP.Net_Core_MVC.Full.Models;

namespace ASP.Net_Core_MVC.Full.Models
{
    public class EmployeesIndexVm
    {
        public List<EmployeeModel> Employees { get; set; }
        public List<PermissionVm> Permissions { get; set; }
        public List<PagePermissionVm> Pages { get; set; }
    }
}