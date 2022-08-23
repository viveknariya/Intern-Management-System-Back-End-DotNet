using InternManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly InternContext _context = new InternContext();


        [HttpGet]
        public IActionResult DesignationList()
        {
            return Ok(_context.Designation);
        }

        [HttpPost]
        public IActionResult AddRecord(Designation designation)
        {
            _context.Designation.Add(designation);
            _context.SaveChanges();

            return Ok(designation);
        }

        [HttpDelete]
        public IActionResult DeleteRecord(string name)
        {
            var designation = _context.Designation.FirstOrDefault(d => d.DepartmentName == name);
            _context.Designation.Remove(designation);
            _context.SaveChanges();

            return Ok(designation);
        }

        [HttpPut]

        public IActionResult PutRecord(Designation designation, string oldname)
        {
            var D = _context.Designation.FirstOrDefault(d => d.DesignationName == oldname);
            _context.Designation.Remove(D);
            _context.SaveChanges();

            _context.Designation.Add(designation);
            _context.SaveChanges();

            return Ok(designation);

        }

    }
}
