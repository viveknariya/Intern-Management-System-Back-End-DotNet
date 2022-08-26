using CustomException;
using InternManagementSystem.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.BusinessLogic
{
    public class LeaveLogic
    {
        private readonly InternContext _context = new InternContext();

        public List<Leave> LeaveList()
        {
            return _context.Leave.ToList();
        }

        public Leave LeaveRecord(int id)
        {
            try
            {
                var temp = _context.Leave.FirstOrDefault(i => i.LeaveId == id);
                if (temp != null)
                {
                    return temp;
                }
                else
                {
                    throw new LeaveNotFound("Leave Not Found");
                }
            }
            catch (LeaveNotFound)
            {
                throw;
            }
        }

        public Leave AddRecord(Leave leave)
        {
            try
            {
                var temp = _context.InternRecord.Where(i => i.InternId == leave.InternId);
                if(temp == null)
                {
                    throw new UserNameNotFound("User Name Not Found");
                }

                var l = _context.Leave.FirstOrDefault(le => le.InternId == leave.InternId);
                if (l == null)
                {
                    _context.Leave.Add(leave);
                    _context.SaveChanges();

                    return leave;
                }
                else
                {
                    if (l.LeaveDate == leave.LeaveDate)
                    {
                        throw new LeaveAlradyExists("Leave Already Exists");
                    }
                    else
                    {
                        _context.Leave.Add(leave);
                        _context.SaveChanges();

                        return leave;
                    }
                }
            }
            catch (LeaveAlradyExists)
            {
                throw;
            }
            catch(UserNameNotFound)
            {
                throw;
            }
        }

        public Leave DeleteRecord(int id)
        {
            try
            {
                var temp = _context.Leave.FirstOrDefault(l => l.LeaveId == id);
                if (temp != null)
                {
                    _context.Leave.Remove(temp);
                    _context.SaveChanges();

                    return temp;
                }
                else
                {
                    throw new LeaveNotFound("Leave Not Found");
                }

            }
            catch (LeaveNotFound)
            {
                throw;
            }

        }


        public Leave PutRecord(Leave leave)
        {
            try
            {
                var temp = _context.Leave.FirstOrDefault(l => l.LeaveId == leave.LeaveId);
                if (temp != null)
                {
                    temp.LeaveDate = leave.LeaveDate;
                    temp.Reason = leave.Reason;

                    _context.Leave.Update(temp);
                    _context.SaveChanges();

                    return temp;
                }
                else
                {
                    throw new LeaveNotFound("Leave Not Found");
                }
            }
            catch (LeaveNotFound)
            {
                throw;

            }

        }
    }
}

