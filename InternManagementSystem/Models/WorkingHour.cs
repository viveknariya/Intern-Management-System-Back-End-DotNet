using System;
using System.Collections.Generic;

namespace InternManagementSystem.Models
{
    public partial class WorkingHour
    {
        public string InternId { get; set; }
        public string Monthly { get; set; }
        public string CompanyWorkingHour { get; set; }
        public string InternWorkingHour { get; set; }

        public virtual InternRecord Intern { get; set; }
    }
}
