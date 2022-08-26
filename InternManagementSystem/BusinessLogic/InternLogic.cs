using CustomException;
using InternManagementSystem.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.BusinessLogic
{
    public class InternLogic
    {
        private readonly InternContext _context = new InternContext();

        public InternRecord Login(Login login)
        {
            try
            {
                var user = _context.InternRecord.FirstOrDefault(u => u.InternId == login.UserName);
                if (user != null)
                {
                    if (user.InternPassword == login.Password)
                    {
                        return user;
                    }
                    else
                    {

                        throw new IncorrectPassword("IncorrectPassword");
                    }

                }
                else
                {

                    throw new UserNameNotFound("UserName Not Found");
                }
            }
            catch (UserNameNotFound)
            {
                throw;
            }
            catch (IncorrectPassword)
            {
                throw;
            }

        }

        public IQueryable<object> InternList()
        {
            var temp = from i in _context.InternRecord
                       join d in _context.Designation on i.Designation equals d.DesignationId into leftRecord
                       from l in leftRecord.DefaultIfEmpty()
                       select new
                       {
                            InternId = i.InternId,
                            InternPassword = i.InternPassword,
                            InternName = i.InternName,
                            PhoneNumber  = i.PhoneNumber,
                            EmailId = i.EmailId,
                            InternAddress = i.InternAddress,
                            InternStatus = i.InternStatus,
                            Designation = l.DepartmentName
                        };

            return temp;
        }

        public InternRecord InternRecord(string id)
        {
            try
            {
                var temp = _context.InternRecord.FirstOrDefault(i => i.InternId == id);
                if(temp != null)
                {
                    return temp;
                }
                else
                {
                    throw new UserNameNotFound("User Name Not Found");
                }
            }
            catch (UserNameNotFound)
            {
                throw;
            }
        }

        public InternRecord AddRecord(InternRecord intern)
        {

            try
            {
                var temp = _context.InternRecord.FirstOrDefault(i => i.InternId == intern.InternId);
                if (temp == null)
                {
                    _context.InternRecord.Add(intern);
                    _context.SaveChanges();

                    return intern;
                }
                else
                {
                    throw new UserNameAlradyExists("UserName Already Exists");
                }
            }
            catch (UserNameAlradyExists)
            {
                throw;
            }

        }


        public InternRecord DeleteRecord(string id)
        {

            try
            {
                var leave = _context.Leave.Where(l => l.InternId == id);
                if (leave != null)
                {
                    foreach (Leave l in leave)
                    {
                        _context.Leave.Remove(l);
                    }
                    _context.SaveChanges();

                }

                var workinghour = _context.WorkingHour.Where(w => w.InternId == id);
                if (workinghour != null)
                {
                    foreach (WorkingHour w in workinghour)
                    {
                        _context.WorkingHour.Remove(w);
                    }
                    _context.SaveChanges();

                }


                var intern = _context.InternRecord.FirstOrDefault(i => i.InternId == id);
                if (intern != null)
                {
                    _context.InternRecord.Remove(intern);
                    _context.SaveChanges();

                    return intern;
                }
                else
                {
                    throw new UserNameNotFound("UserName Not Found");
                }
            }
            catch (UserNameNotFound)
            {
                throw;
            }



        }


        public InternRecord PutRecord(InternRecord intern)
        {

            try
            {
                var I = _context.InternRecord.FirstOrDefault(i => i.InternId == intern.InternId);
                if (I != null)
                {
                    I.InternName = intern.InternName;
                    I.InternStatus = intern.InternStatus;
                    I.InternAddress = intern.InternAddress;
                    I.Designation = intern.Designation;
                    I.PhoneNumber = intern.PhoneNumber;
                    I.EmailId = intern.EmailId;

                    _context.InternRecord.Update(I);
                    _context.SaveChanges();

                    return I;
                }
                else
                {
                    throw new UserNameNotFound("UserName Not Found");
                }
            }
            catch (UserNameNotFound)
            {
                throw;
            }
        }
    }
}
