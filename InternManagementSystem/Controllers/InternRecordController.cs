using CustomException;
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
        private readonly InternContext _context = new InternContext();

        private readonly ILogger<InternRecordController> _logger;

        private readonly IConfiguration _config;

        public InternRecordController(ILogger<InternRecordController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            _logger.LogInformation(login.UserName + login.Password);
            try
            {
                var user = _context.InternRecord.FirstOrDefault(u => u.InternId == login.UserName);
                if (user != null)
                {
                    if (user.InternPassword == login.Password)
                    {
                        _logger.LogInformation("Login Successfull");
                        return Ok("Login Successfull");
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
            catch(UserNameNotFound e)
            {
                _logger.LogInformation("Incorrect Password");
                return BadRequest(e.Message);
            }
            catch(IncorrectPassword e)
            {
                _logger.LogInformation("UserName Not Found");
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet]
        public IActionResult InternList()
        {
            _logger.LogInformation("Intern List Excuted");
            return Ok(_context.InternRecord);
        }

        [HttpPost]
        public IActionResult AddRecord(InternRecord intern)
        {
            _logger.LogInformation(intern.InternId);

            try
            {
                var temp = _context.InternRecord.FirstOrDefault(i => i.InternId == intern.InternId);
                if(temp == null)
                {
                    _context.InternRecord.Add(intern);
                    _context.SaveChanges();
                    _logger.LogInformation("Intern Record Added Successfully");
                    return Ok(intern);
                }
                else
                {
                    throw new UserNameAlradyExists("UserName Already Exists");
                }
            }
            catch (UserNameAlradyExists er)
            {
                _logger.LogError("httppost user already exists");
                return BadRequest(er.Message);
            }
 
        }

        [HttpDelete]
        public IActionResult DeleteRecord(string id)
        {
            _logger.LogInformation(id);

            try
            {
                var intern = _context.InternRecord.FirstOrDefault(i => i.InternId == id);
                if(intern != null)
                {
                    _context.InternRecord.Remove(intern);
                    _context.SaveChanges();

                    _logger.LogInformation("Intern Record Deleted Successfully");
                    return Ok(intern);
                }
                else
                {
                    throw new UserNameNotFound("UserName Not Found");
                }
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
            _logger.LogInformation(intern.InternId);

            try
            {
                var I = _context.InternRecord.FirstOrDefault(i => i.InternId == intern.InternId);
                if(I != null)
                {
                    I.InternName = intern.InternName;
                    I.InternStatus = intern.InternStatus;
                    I.InternAddress = intern.InternAddress;
                    I.Designation = intern.Designation;
                    I.PhoneNumber = intern.PhoneNumber;
                    I.EmailId = intern.EmailId;

                    _context.InternRecord.Update(I);
                    _context.SaveChanges();

                    _logger.LogInformation("Intern Record Changed Successfully");
                    return Ok(I);
                }
                else
                {
                    throw new UserNameNotFound("UserName Not Found");
                }
            }
            catch (UserNameNotFound er)
            {
                _logger.LogError("httpput user not found");
                return BadRequest(er.Message);
            }
        }
    }
}
