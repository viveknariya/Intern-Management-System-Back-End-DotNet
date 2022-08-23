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
    public class DesignationController : ControllerBase
    {
        private readonly InternContext _context = new InternContext();

        private readonly ILogger<DesignationController> _logger;


        public DesignationController(ILogger<DesignationController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult DesignationList()
        {
            _logger.LogInformation("Designation List Excuted");
            return Ok(_context.Designation);
        }

        [HttpPost]
        public IActionResult AddRecord(Designation designation)
        {
            _logger.LogInformation(designation.DepartmentName);

            try
            {
                var desi = _context.Designation.FirstOrDefault(d => d.DesignationName == designation.DesignationName);
                if(desi == null)
                {
                    _context.Designation.Add(designation);
                    _context.SaveChanges();

                    _logger.LogInformation("Designation Added Successfully");
                    return Ok(designation);
                }
                else
                {
                    throw new DesignationAlreadyExists("Designation Already Exists");
                }
            }
            catch (DesignationAlreadyExists er)
            {
                _logger.LogError("httppost designation already exists");
                return BadRequest(er.Message);
            }
            
        }

        [HttpDelete]
        public IActionResult DeleteRecord(string name)
        {
            _logger.LogInformation(name);
            try
            {
                var designation = _context.Designation.FirstOrDefault(d => d.DepartmentName == name);
                if(designation != null)
                {
                    _context.Designation.Remove(designation);
                    _context.SaveChanges();

                    _logger.LogInformation("Designation Deleted Successfully");
                    return Ok(designation);
                }
                else
                {
                    throw new DesignationNotFound("Designation Not Found");
                }
            }
            catch (DesignationNotFound er)
            {
                _logger.LogError("httpdelete designation not found");
                return BadRequest(er.Message);
            }
            
        }

        [HttpPut]

        public IActionResult PutRecord(DesignationPutBody designation)
        {
            _logger.LogInformation(designation.DepartmentName);
            try
            {
                var D = _context.Designation.FirstOrDefault(d => d.DesignationName == designation.OldDesignationName);
                if(D != null)
                {
                    _context.Designation.Remove(D);
                    _context.SaveChanges();

                    var newDesignation = new Designation();

                    newDesignation.DepartmentName = designation.DepartmentName;
                    newDesignation.DesignationName = designation.DesignationName;
                    newDesignation.RoleName = designation.RoleName;

                    _context.Designation.Add(newDesignation);
                    _context.SaveChanges();

                    _logger.LogInformation("Designation Edited Successfully");
                    return Ok(newDesignation);
                }
                else
                {
                    throw new DesignationNotFound("Designation Not Found");
                }
            }
            catch (DesignationNotFound er)
            {
                _logger.LogError("httpput designation not found");
                return BadRequest(er.Message);
            }
            
            

        }

    }
}
