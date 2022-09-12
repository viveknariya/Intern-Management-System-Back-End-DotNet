using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternManagementSystem.Models
{
    public partial class InternRecord
    {
        public InternRecord()
        {
            Leave = new HashSet<Leave>();
            WorkingHour = new HashSet<WorkingHour>();
        }

        [Required]
        public string InternId { get; set; }
        [Required]
        public string InternPassword { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]+")]
        public string InternName { get; set; }
        [RegularExpression("[0-9]{10}")]
        public string PhoneNumber { get; set; }
        [EmailAddress] 
        public string EmailId { get; set; }
        public string InternAddress { get; set; }
        public string InternStatus { get; set; }

        public int? Designation { get; set; }

        public virtual Designation DesignationNavigation { get; set; }
        public virtual ICollection<Leave> Leave { get; set; }
        public virtual ICollection<WorkingHour> WorkingHour { get; set; }
    }
}
