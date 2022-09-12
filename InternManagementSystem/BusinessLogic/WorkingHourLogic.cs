using InternManagementSystem.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomException;

namespace InternManagementSystem.BusinessLogic
{
    public class WorkingHourLogic
    {
        private readonly InternContext _context = new InternContext();



        public List<WorkingHour> workingHourData()
        {

            return _context.WorkingHour.ToList();
        }

        public List<WorkingHour> WhbyIntern(string id)
        {
            try
            {
                var temp = _context.WorkingHour.Where(i => i.InternId == id);
                if (temp != null)
                {
                    return temp.ToList();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw;
            }
        }

            public WorkingHour WorikingHourRecord(int id)
        {
            try
            {
                var temp = _context.WorkingHour.FirstOrDefault(i => i.Whid == id);
                if (temp != null)
                {
                    return temp;
                }
                else
                {
                    throw new WorkingDataNotFound("WorkingData Not Found");
                }
            }
            catch (WorkingDataNotFound)
            {
                throw;
            }

        }

        public WorkingHour AddRecord(WorkingHour wh)
        {
            try
            {
                var temp = _context.InternRecord.FirstOrDefault(i => i.InternId == wh.InternId);
                if (temp == null)
                {
                    throw new UserNameNotFound("User Name Not Found");
                }
                else
                {
                    var temp2 = _context.WorkingHour.FirstOrDefault(w => w.InternId == wh.InternId && w.Monthly == wh.Monthly);
                    if (temp2 == null)
                    {
                        _context.WorkingHour.Add(wh);
                        _context.SaveChanges();

                        return wh;
                    }
                    else
                    {
                        throw new WorkingDataAlreadyExists("Working Data Already Exists");
                    }
                }

            }
            catch (WorkingDataAlreadyExists)
            {
                throw;
            }
            catch (UserNameNotFound)
            {
                throw;
            }


        }

        public WorkingHour DeleteRecord(int id)
        {
            try
            {
                var temp = _context.WorkingHour.FirstOrDefault(w => w.Whid == id);
                if (temp != null)
                {
                    _context.WorkingHour.Remove(temp);
                    _context.SaveChanges();

                    return temp;
                }
                else
                {
                    throw new WorkingDataNotFound("Working Data Not Found");
                }
            }
            catch (WorkingDataNotFound)
            {
                throw;
            }


        }



        public WorkingHour PutRecord(WorkingHour wh)
        {
            try
            {
                var temp = _context.WorkingHour.FirstOrDefault(w => w.Whid == wh.Whid);
                if (temp != null)
                {
                    temp.Monthly = wh.Monthly;
                    temp.CompanyWorkingHour = wh.CompanyWorkingHour;
                    temp.InternWorkingHour = wh.InternWorkingHour;

                    _context.WorkingHour.Update(temp);
                    _context.SaveChanges();

                    return temp;
                }
                else
                {
                    throw new WorkingDataNotFound("Working Data Not Found");
                }
            }
            catch (WorkingDataNotFound)
            {
                throw;
            }
        }
    }
}
