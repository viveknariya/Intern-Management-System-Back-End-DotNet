using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternManagementSystem.Models
{
    public partial class Leave
    {
        public int LeaveId { get; set; }

        [Required]
        public string InternId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LeaveDate { get; set; }

        public string Reason { get; set; }

        public virtual InternRecord Intern { get; set; }
    }
}
