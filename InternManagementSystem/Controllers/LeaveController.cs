using CustomException;
using InternManagementSystem.BusinessLogic;
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

        private readonly ILogger<LeaveController> _logger;

        private readonly ILeave leaveLogic;


        public LeaveController(ILogger<LeaveController> logger,ILeave leaveLogi)
        {
            _logger = logger;
            leaveLogic = leaveLogi;
        }


        [HttpGet]
        public IActionResult LeaveList()
        {
            var temp = leaveLogic.LeaveList();
            return Ok(temp);
        }
        [HttpGet("intern/{id}")]
        public IActionResult LeavebyIntern(string id)
        {
            var temp = leaveLogic.LeaveByIntern(id);
            return Ok(temp);
        }

        [HttpGet("{id}")]
        public IActionResult LeaveRecord(int id)
        {
            var temp = leaveLogic.LeaveRecord(id);
            return Ok(temp);
        }

        [HttpPost]
        public IActionResult AddRecord(Leave leave)
        {
            try
            {
                var temp = leaveLogic.AddRecord(leave);
                return Ok(temp);
                
            }
            catch (LeaveAlradyExists er)
            {
                _logger.LogError("httppost leave already exists");
                return BadRequest(er.Message);
            }
            catch (UserNameNotFound er)
            {
                _logger.LogError("httppost user name not found");
                return BadRequest(er.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                var temp = leaveLogic.DeleteRecord(id);
                return Ok(temp);
               
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
                var temp = leaveLogic.PutRecord(leave);
                return Ok(leave);
                
            }
            catch (LeaveNotFound er)
            {
                _logger.LogError("httpput leave not found");
                return BadRequest(er.Message);
            }
            
        }
    }
}
