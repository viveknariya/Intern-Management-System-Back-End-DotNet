using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternManagementSystem.Models
{
    public partial class WorkingHour
    {
        public int Whid { get; set; }
        [Required]
        public string InternId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public string Monthly { get; set; }

        [Required]
        [RegularExpression("[0-9]{1,3}")]
        public string CompanyWorkingHour { get; set; }

        [Required]
        [RegularExpression("[0-9]{1,3}")]
        public string InternWorkingHour { get; set; }

        public virtual InternRecord Intern { get; set; }
    }
}
