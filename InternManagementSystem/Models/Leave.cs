using System;
using System.Collections.Generic;

namespace InternManagementSystem.Models
{
    public partial class Leave
    {
        public int LeaveId { get; set; }
        public string InternId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string Reason { get; set; }

        public virtual InternRecord Intern { get; set; }
    }
}
