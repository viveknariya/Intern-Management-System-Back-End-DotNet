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
            return Ok(_context.WorkingHour);
        }

        [HttpPost]
        public IActionResult AddRecord(WorkingHour wh)
        {
            _context.WorkingHour.Add(wh);
            _context.SaveChanges();

            return Ok(wh);
        }

        [HttpDelete]
        public IActionResult DeleteRecord(string id)
        {
            var wh = _context.WorkingHour.FirstOrDefault(w => w.InternId == id);
            _context.WorkingHour.Remove(wh);
            _context.SaveChanges();

            return Ok(wh);
        }

        [HttpPut]

        public IActionResult PutRecord(WorkingHour wh)
        {
            var workingHour = _context.WorkingHour.FirstOrDefault(w => w.InternId == wh.InternId);
            workingHour.CompanyWorkingHour = wh.CompanyWorkingHour;
            workingHour.InternWorkingHour = wh.InternWorkingHour;

            _context.WorkingHour.Update(workingHour);
            _context.SaveChanges();

            return Ok(workingHour);

        }
    }
}
