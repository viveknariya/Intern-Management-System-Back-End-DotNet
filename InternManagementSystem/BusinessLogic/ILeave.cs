using InternManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.BusinessLogic
{
    public interface ILeave
    {
        public List<Leave> LeaveList();


        public List<Leave> LeaveByIntern(string id);


        public Leave LeaveRecord(int id);


        public Leave AddRecord(Leave leave);


        public Leave DeleteRecord(int id);



        public Leave PutRecord(Leave leave);
        
    }
}
