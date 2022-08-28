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
    public class DesignationController : ControllerBase
    {

        private readonly ILogger<DesignationController> _logger;

        private readonly IDesignation designationlogic;

        public DesignationController(ILogger<DesignationController> logger, IDesignation dlogic)
        {
            _logger = logger;
            designationlogic = dlogic;
        }


        [HttpGet]
        public IActionResult DesignationList()
        {
            _logger.LogInformation("Designation List Excuted");
            return Ok(designationlogic.DesignationList());
        }

        [HttpGet("{id}")]
        public IActionResult DesignationRecord(int id)
        {
            try
            {
                var temp = designationlogic.DesignationRecord(id);
                return Ok(temp);
            }
            catch (DesignationNotFound er)
            {
                return BadRequest(er.Message);
            }


        }

        [HttpPost]
        public IActionResult AddRecord(Designation designation)
        {
            try
            {
                var temp = designationlogic.AddRecord(designation);
                return Ok(temp);
            }
            catch (DesignationAlreadyExists er)
            {
                _logger.LogError("httppost designation already exists");
                return BadRequest(er.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                var temp = designationlogic.DeleteRecord(id);
                return Ok(temp);
            }
            catch (DesignationNotFound er)
            {
                _logger.LogError("httpdelete designation not found");
                return BadRequest(er.Message);
            }
            
        }

        [HttpPut]

        public IActionResult PutRecord(Designation designation)
        {
            try
            {
                var temp = designationlogic.PutRecord(designation);
                return Ok(temp);
            }
            catch (DesignationNotFound er)
            {
                _logger.LogError("httpput designation not found");
                return BadRequest(er.Message);
            }
        }

    }
}
