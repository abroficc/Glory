using System;
using System.Collections.Generic;

namespace Inspinia.Models
{
    public class CustomerAndWebDevicesIndexVm
    {
        public List<CustomerDevice> CustomerDevices { get; set; }
        public List<WebDevice> WebDevices { get; set; }
    }
}