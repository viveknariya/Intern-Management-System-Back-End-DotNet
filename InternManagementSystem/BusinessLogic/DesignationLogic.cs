using CustomException;
using InternManagementSystem.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.BusinessLogic
{
    public class DesignationLogic : IDesignation
    {
        private readonly InternContext _context = new InternContext();


        private readonly InternLogic internlogic = new InternLogic();


        public  List<Designation> DesignationList()
        {
            return _context.Designation.ToList();
        }

        public Designation DesignationRecord(int id)
        {
            try
            {
                var temp = _context.Designation.FirstOrDefault(i => i.DesignationId == id);
                if (temp != null)
                {
                    return temp;
                }
                else
                {
                    throw new DesignationNotFound("Designation Not Found");
                }
            }
            catch (DesignationNotFound)
            {
                throw;
            }
        }

        public  Designation AddRecord(Designation designation)
        {

            try
            {
                var temp = _context.Designation.FirstOrDefault(d => d.DesignationName == designation.DesignationName);
                if (temp == null)
                {
                    _context.Designation.Add(designation);
                    _context.SaveChanges();

                    return designation;
                }
                else
                {
                    throw new DesignationAlreadyExists("Designation Already Exists");
                }
            }
            catch (DesignationAlreadyExists)
            {
                throw;
            }

        }

        public  Designation DeleteRecord(int id)
        {
            try
            {
                var temp = _context.Designation.FirstOrDefault(d => d.DesignationId == id);
                if (temp != null)
                {
                    _context.Designation.Remove(temp);
                    _context.SaveChanges();

                    return temp;
                }
                else
                {
                    throw new DesignationNotFound("Designation Not Found");
                }
            }
            catch (DesignationNotFound)
            {
                throw;
            }
        }


        public  Designation PutRecord(Designation designation)
        {
            try
            {
                var temp = _context.Designation.FirstOrDefault(d => d.DesignationId == designation.DesignationId);
                if (temp != null)
                {

                    temp.DesignationName = designation.DesignationName;
                    temp.DepartmentName = designation.DepartmentName;
                    temp.RoleName = designation.RoleName;

                    _context.Designation.Update(temp);
                    _context.SaveChanges();

                    return temp;
                }
                else
                {
                    throw new DesignationNotFound("Designation Not Found");
                }
            }
            catch (DesignationNotFound)
            {
                throw;
            }
        }

    }
}

