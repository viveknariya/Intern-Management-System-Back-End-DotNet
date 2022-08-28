using InternManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.BusinessLogic
{
    public interface IIntern
    {
        public InternRecord Login(Login login);


        public IQueryable<object> InternList();


        public InternRecord InternRecord(string id);


        public InternRecord AddRecord(InternRecord intern);



        public InternRecord DeleteRecord(string id);



        public InternRecord PutRecord(InternRecord intern);
        
    }
}
