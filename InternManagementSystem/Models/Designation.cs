using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternManagementSystem.Models
{
    public partial class Designation
    {
        public Designation()
        {
            InternRecord = new HashSet<InternRecord>();
        }

       
        public int DesignationId { get; set; }
        [Required]
        public string DesignationName { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public virtual ICollection<InternRecord> InternRecord { get; set; }
    }
}
