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
    public class LeaveController : ControllerBase
    {
        private readonly InternContext _context = new InternContext();


        [HttpGet]
        public IActionResult LeaveList()
        {
            return Ok(_context.Leave);
        }

        [HttpPost]
        public IActionResult AddRecord(Leave leave)
        {
            _context.Leave.Add(leave);
            _context.SaveChanges();

            return Ok(leave);
        }

        [HttpDelete]
        public IActionResult DeleteRecord(string id)
        {
            var leave = _context.Leave.FirstOrDefault(l => l.InternId == id);
            _context.Leave.Remove(leave);
            _context.SaveChanges();

            return Ok(leave);
        }

        [HttpPut]

        public IActionResult PutRecord(Leave leave)
        {
            var L = _context.Leave.FirstOrDefault(l => l.InternId == leave.InternId);
            L.LeaveDate = leave.LeaveDate;
            L.Reason = leave.Reason;

            _context.Leave.Update(L);
            _context.SaveChanges();
 
            return Ok(L);

        }
    }
}
