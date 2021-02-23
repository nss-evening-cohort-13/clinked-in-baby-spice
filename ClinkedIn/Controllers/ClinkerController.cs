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

        [HttpPut("{id}/add-friend-{friendId}")]
        public IActionResult AddFriend(int id, int friendId)
        {
            var clinker = _repo.Get(id);
            var friend = _repo.Get(friendId);
            if (clinker.Friends.IndexOf(friendId) >= 0)
            {
                return StatusCode(208);
            }
            clinker.Friends.Add(friend.Id);
            friend.Friends.Add(clinker.Id);
            return Ok($"Added {friend.Name} as a friend");
        }
            
        [HttpPost]
        public IActionResult AddNewClinker(Clinker clinker)
        {
            _repo.Add(clinker);
            return Created($"api/Clinkers/{clinker.Id}", clinker);
        }
    }
}
