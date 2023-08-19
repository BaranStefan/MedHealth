// Controllers/DoctorsController.cs
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private static List<Doctor> _doctors = new List<Doctor>
        {
            new Doctor { Id = 1, Name = "Dr. Smith", Specialty = "Cardiology" },
            new Doctor { Id = 2, Name = "Dr. Johnson", Specialty = "Dermatology" },
            // Add more doctor entries here...
        };

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_doctors);
        }
    }
}
