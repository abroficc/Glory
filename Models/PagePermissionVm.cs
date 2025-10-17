using System;
using System.Collections.Generic;

namespace ASP.Net_Core_MVC.Full.Models
{
    public class PagePermissionVm
    {
        public string PageKey { get; set; }
        public string PageTitle { get; set; }
        public List<PermissionOptionVm> Options { get; set; }
    }
}