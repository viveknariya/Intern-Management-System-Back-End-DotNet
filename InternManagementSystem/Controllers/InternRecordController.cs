using CustomException;
using InternManagementSystem.BusinessLogic;
using InternManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternRecordController : ControllerBase
    {

        private readonly ILogger<InternRecordController> _logger;

        private readonly IIntern internlogic;
        public InternRecordController(IIntern intern, ILogger<InternRecordController> logger)
        {
            internlogic = intern;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            try
            {
                var temp = internlogic.Login(login);
                return Ok(temp);
            }
            catch (UserNameNotFound e)
            {
                _logger.LogInformation("Incorrect Password");
                return BadRequest(e.Message);
            }
            catch (IncorrectPassword e)
            {
                _logger.LogInformation("UserName Not Found");
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        public IActionResult InternList()
        {
            var temp = internlogic.InternList();
            return Ok(temp);
        }

        [HttpGet("{id}")]
        public IActionResult InternRecord(string id)
        {
            try
            {
                var temp = internlogic.InternRecord(id);
                return Ok(temp);
            }
            catch(UserNameNotFound er)
            {
                return BadRequest(er.Message);
            }
            
            
        }

        [HttpPost]
        public IActionResult AddRecord(InternRecord intern)
        {

            try
            {
                var temp = internlogic.AddRecord(intern);
                return Ok(temp);
            }
            catch (UserNameAlradyExists er)
            {
                _logger.LogError("httppost user already exists");
                return BadRequest(er.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(string id)
        {

            try
            {
                var temp = internlogic.DeleteRecord(id);
                return Ok(temp);
            }
            catch (UserNameNotFound er)
            {
                _logger.LogError("httpdelete user not found");
                return BadRequest(er.Message);
            }

            
            
        }

        [HttpPut]

        public IActionResult PutRecord(InternRecord intern)
        {

            try
            {
                var temp = internlogic.PutRecord(intern);
                return Ok(temp);
            }
            catch (UserNameNotFound er)
            {
                _logger.LogError("httpput user not found");
                return BadRequest(er.Message);
            }
        }
    }
}
