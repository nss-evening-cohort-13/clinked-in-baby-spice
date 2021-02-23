using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using ClinkedIn.Data;

namespace ClinkedIn.Controllers
{
    [Route("api/Clinkers")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        ClinkerRepository _repo;

        public ClinkerController()
        {
            _repo = new ClinkerRepository();
        }

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clinker = _repo.Get(id);
            if (clinker == null) return NotFound($"No clinker with Id {id} exists");
            return Ok(clinker);
        }

        [HttpPost]
        public IActionResult AddNewClinker(Clinker clinker)
        {
            _repo.Add(clinker);
            return Created($"api/Clinkers/{clinker.Id}", clinker);
        }

        [HttpGet("{id}/enemies")]

        public IActionResult EnemiesList(int id)
        {
            var clinker = _repo.Get(id);
            if (clinker.Enemies.Count == 0) return NotFound($"{clinker.Name} has no enemies...");
            return Ok(clinker.Enemies);
       }
    }
}
