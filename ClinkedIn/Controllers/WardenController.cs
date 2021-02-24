using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;

namespace ClinkedIn.Controllers
{
    [Route("api/Warden")]
    [ApiController]
    public class WardenController : ControllerBase
    {
        ClinkerRepository _repo;

        public WardenController()
        {
            _repo = new ClinkerRepository();
        }
        // Get All Clinkers
        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            return Ok(_repo.GetAll());
        }
    }
}
