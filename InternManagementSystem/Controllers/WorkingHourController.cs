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
    public class WorkingHourController : ControllerBase
    {
        private readonly InternContext _context = new InternContext();


        private readonly ILogger<WorkingHourController> _logger;


        public WorkingHourController(ILogger<WorkingHourController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult workingHourData()
            
        {

            _logger.LogInformation("WorkingHour Data Excuted");
            return Ok(_context.WorkingHour);
        }

        [HttpPost]
        public IActionResult AddRecord(WorkingHour wh)
        {
            _logger.LogInformation(wh.InternId);
            try
            {
                var temp = _context.WorkingHour.FirstOrDefault(w => w.InternId == wh.InternId && w.Monthly == wh.Monthly);
                if(temp == null)
                {
                    _context.WorkingHour.Add(wh);
                    _context.SaveChanges();

                    _logger.LogInformation("Working Data Added Successfully");
                    return Ok(wh);
                }
                else
                {
                    throw new WorkingDataAlreadyExists("Working Data Already Exists");
                }

            }
            catch (WorkingDataAlreadyExists er)
            {
                _logger.LogError("httppost data already exists");
                return BadRequest(er.Message);
            }
            
        }

        [HttpDelete]
        public IActionResult DeleteRecord(WorkingHour workinghour)
        {
            _logger.LogInformation(workinghour.InternId);
            try
            {
                var wh = _context.WorkingHour.FirstOrDefault(w => w.Whid == workinghour.Whid);
                if(wh != null)
                {
                    _context.WorkingHour.Remove(wh);
                    _context.SaveChanges();

                    _logger.LogInformation("Working Data Deleted Successfully");
                    return Ok(wh);
                }
                else
                {
                    throw new WorkingDataNotFound("Working Data Not Found");
                }
            }
            catch (WorkingDataNotFound er)
            {
                _logger.LogError("httpdelete working data not found");
                return BadRequest(er.Message);
            }
            
            
        }


        [HttpPut]

        public IActionResult PutRecord(WorkingHour wh)
        {
            _logger.LogInformation(wh.InternId);
            try
            {
                var workingHour = _context.WorkingHour.FirstOrDefault(w => w.Whid == wh.Whid);
                if(workingHour != null)
                {
                    workingHour.CompanyWorkingHour = wh.CompanyWorkingHour;
                    workingHour.InternWorkingHour = wh.InternWorkingHour;

                    _context.WorkingHour.Update(workingHour);
                    _context.SaveChanges();

                    _logger.LogInformation("Working Data Record Changed Successfully");
                    return Ok(workingHour);
                }
                else
                {
                    throw new WorkingDataNotFound("Working Data Not Found");
                }
            }
            catch(WorkingDataNotFound er)
            {
                _logger.LogError("httpput working data not found");
                return BadRequest(er.Message);
            }
            
            

        }
    }
}
