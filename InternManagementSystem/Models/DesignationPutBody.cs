using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Models
{
    public class DesignationPutBody
    {
        public string DesignationName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }

        public string OldDesignationName { get; set; }
    }
}
