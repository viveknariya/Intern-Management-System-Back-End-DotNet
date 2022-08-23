using CustomException;
using InternManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private readonly ILogger<LeaveController> _logger;


        public LeaveController(ILogger<LeaveController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult LeaveList()
        {
            _logger.LogInformation("Leave List Excuted");
            return Ok(_context.Leave);
        }

        [HttpPost]
        public IActionResult AddRecord(Leave leave)
        {
            _logger.LogInformation(leave.InternId);
            try
            {
                var l = _context.Leave.FirstOrDefault(le => le.InternId == leave.InternId);
                if(l == null)
                {
                    _context.Leave.Add(leave);
                    _context.SaveChanges();

                    _logger.LogInformation("Leave Added successfully");
                    return Ok(leave);
                }
                else
                {
                    if(l.LeaveDate == leave.LeaveDate)
                    {
                        throw new LeaveAlradyExists("Leave Already Exists");
                    }
                    else
                    {
                        _context.Leave.Add(leave);
                        _context.SaveChanges();

                        _logger.LogInformation("Leave Added Successfully");
                        return Ok(leave);
                    }
                }
            }
            catch (LeaveAlradyExists er)
            {
                _logger.LogError("httppost leave already exists");
                return BadRequest(er.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteRecord(Leave L)
        {
            _logger.LogInformation(L.InternId);
            try
            {
                var leave = _context.Leave.FirstOrDefault(l => l.InternId == L.InternId && l.LeaveDate == L.LeaveDate);
                if(leave != null)
                {
                    _context.Leave.Remove(leave);
                    _context.SaveChanges();

                    _logger.LogInformation("Leave Deleted Successfully");
                    return Ok(leave);
                }
                else
                {
                    throw new LeaveNotFound("Leave Not Found");
                }

            }
            catch (LeaveNotFound er)
            {
                _logger.LogError("httpdelete leave not found");
                return BadRequest(er.Message);
            }
            
        }

        [HttpPut]

        public IActionResult PutRecord(Leave leave)
        {
            try
            {
                var L = _context.Leave.FirstOrDefault(l => l.LeaveId == leave.LeaveId);
                if(L != null)
                {
                    L.LeaveDate = leave.LeaveDate;
                    L.Reason = leave.Reason;

                    _context.Leave.Update(L);
                    _context.SaveChanges();

                    _logger.LogInformation("Leave Record Changed Successfully");
                    return Ok(L);
                }
                else
                {
                    throw new LeaveNotFound("Leave Not Found");
                }
            }
            catch (LeaveNotFound er)
            {
                _logger.LogError("httpput leave not found");
                return BadRequest(er.Message);
            }
            
        }
    }
}
