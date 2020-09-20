using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StaffWebApplication.Models;

namespace StaffWebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffsController : Controller
    {
        IStaffRepository StaffRepository;

        public StaffsController(IStaffRepository staffRepository)
        {
            StaffRepository = staffRepository;
        }

        [HttpGet("{id}", Name = "GetStaff")]
        public IActionResult Get(int Id)
        {
            Staff staff = StaffRepository.Get(Id);

            if (staff == null)
            {
                return NotFound();
            }
            Console.WriteLine(staff);
            return new ObjectResult(staff);
        }

        [HttpGet("{id}", Name = "GetFromCompany")]
        public IActionResult GetFromCompany(int Id)
        {
            IEnumerable<Staff> staffs = StaffRepository.GetFromCompany(Id);

            return new ObjectResult(staffs);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Staff staff)
        {
            if (staff == null)
            {
                return BadRequest();
            }
            StaffRepository.Create(staff);
            return new ObjectResult(staff.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Staff deletedStaff = StaffRepository.Delete(Id);

            if (deletedStaff == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, [FromBody] Staff updatedStaff)
        {
            if (updatedStaff == null)
            {
                return BadRequest();
            }

            Staff staff = StaffRepository.Get(Id);
            if (staff == null)
            {
                return NotFound();
            }

            updatedStaff.Id = Id;
            StaffRepository.Update(updatedStaff);
            return Ok();
        }

    }
}
