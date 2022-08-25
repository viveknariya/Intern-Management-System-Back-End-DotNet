using System;
using System.Collections.Generic;

namespace InternManagementSystem.Models
{
    public partial class Designation
    {
        public Designation()
        {
            InternRecord = new HashSet<InternRecord>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<InternRecord> InternRecord { get; set; }
    }
}
