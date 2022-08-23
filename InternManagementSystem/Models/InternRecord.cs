using System;
using System.Collections.Generic;

namespace InternManagementSystem.Models
{
    public partial class InternRecord
    {
        public InternRecord()
        {
            Leave = new HashSet<Leave>();
            WorkingHour = new HashSet<WorkingHour>();
        }

        public string InternId { get; set; }
        public string InternPassword { get; set; }
        public string InternName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string InternAddress { get; set; }
        public string InternStatus { get; set; }
        public string Designation { get; set; }

        public virtual Designation DesignationNavigation { get; set; }
        public virtual ICollection<Leave> Leave { get; set; }
        public virtual ICollection<WorkingHour> WorkingHour { get; set; }
    }
}
