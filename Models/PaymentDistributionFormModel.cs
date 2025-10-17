using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glory77.Models
{
    public class PaymentDistributionFormModel
    {
        public string Mode { get; set; } // "Add", "Edit", or "View"
        // Removed PaymentDistributionPrinciple property
        
        public bool IsViewMode => Mode == "View";
        public bool IsEditMode => Mode == "Edit";
        public bool IsAddMode => Mode == "Add";
    }
}