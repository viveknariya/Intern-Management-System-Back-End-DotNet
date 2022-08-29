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
    public class WorkingHourController : ControllerBase
    {

        private readonly ILogger<WorkingHourController> _logger;

        private readonly WorkingHourLogic whlogic =  new WorkingHourLogic();


        public WorkingHourController(ILogger<WorkingHourController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult workingHourData()
        {
            var temp = whlogic.workingHourData();
            return Ok(temp);
        }

        [HttpGet("intern/{id}")]
        public IActionResult whByIntern(string id)
        {
            var temp = whlogic.WhbyIntern(id);
            return Ok(temp);
        }

        [HttpGet("{id}")]
        public IActionResult workingHourRecord(int id)
        {
            try
            {
                var temp = whlogic.WorikingHourRecord(id);
                return Ok(temp);
            }
            catch (WorkingDataNotFound er)
            {
                return BadRequest(er.Message);
            }
        }

        [HttpPost]
        public IActionResult AddRecord(WorkingHour wh)
        {
            try
            {
                var temp = whlogic.AddRecord(wh);
                return Ok(temp);

            }
            catch (WorkingDataAlreadyExists er)
            {
                _logger.LogError("httppost data already exists");
                return BadRequest(er.Message);
            }
            catch(UserNameNotFound er)
            {
                _logger.LogError("user name not found");
                return BadRequest(er.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                var temp = whlogic.DeleteRecord(id);
                return Ok(temp);
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
            try
            {
                var temp = whlogic.PutRecord(wh);
                return Ok(temp);
            }
            catch(WorkingDataNotFound er)
            {
                _logger.LogError("httpput working data not found");
                return BadRequest(er.Message);
            }
            
        }
    }
}
