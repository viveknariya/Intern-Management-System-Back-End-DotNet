using InternManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        [HttpGet]
        public IActionResult InternList()
        {
            return Ok(_context.InternRecord);
        }

        [HttpPost]
        public IActionResult AddRecord(InternRecord intern)
        {
            _context.InternRecord.Add(intern);
            _context.SaveChanges();

            return Ok(intern);
        }

        [HttpDelete]
        public IActionResult DeleteRecord(string id)
        {
            var intern = _context.InternRecord.FirstOrDefault(i => i.InternId == id);
            _context.InternRecord.Remove(intern);
            _context.SaveChanges();

            return Ok(intern);
        }

        [HttpPut]

        public IActionResult PutRecord(InternRecord intern)
        {
            var I = _context.InternRecord.FirstOrDefault(i => i.InternId == intern.InternId);
            I.InternName = intern.InternName;
            I.InternStatus = intern.InternStatus;
            I.InternAddress = intern.InternAddress;
            I.Designation = intern.Designation;
            I.PhoneNumber = intern.PhoneNumber;
            I.EmailId = intern.EmailId;

            _context.InternRecord.Update(I);
            _context.SaveChanges();

            return Ok(I);

        }
    }
}
