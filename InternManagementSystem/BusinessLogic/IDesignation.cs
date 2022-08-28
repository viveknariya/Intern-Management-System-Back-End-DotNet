using InternManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.BusinessLogic
{
    public interface IDesignation
    {
        public List<Designation> DesignationList();


        public Designation DesignationRecord(int id);


        public Designation AddRecord(Designation designation);
        

        public Designation DeleteRecord(int id);

        public Designation PutRecord(Designation designation);
        
    }
}
