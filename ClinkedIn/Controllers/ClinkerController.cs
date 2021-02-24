using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using ClinkedIn.Data;
using System.Globalization;

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

        // Get All Clinkers
        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var clinkers = _repo.GetAll();
            var clinkerNames = new List<string>();
            foreach (var clinker in clinkers) clinkerNames.Add(clinker.Name);
            return Ok(clinkerNames);
        }

        // Get Clinker By ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clinker = _repo.Get(id);
            if (clinker == null) return NotFound($"No clinker with Id {id} exists");
            return Ok(clinker);
        }

        //Add Friend
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


        //Get Friends
        [HttpGet("{id}/friends")]
        public IActionResult GetFriends(int id)
        {
            var clinker = _repo.Get(id);
            if (clinker == null) return NotFound($"There is no clinker with Id: {id}.");
            if (clinker.Friends.Count == 0) return NotFound($"No Friends of {clinker.Name} exists....This is one lonely clinker");
            return Ok(clinker.Friends);
        }

        //Add Clinker
        [HttpPost]
        public IActionResult AddNewClinker(Clinker clinker)
        {
            _repo.Add(clinker);
            return Created($"api/Clinkers/{clinker.Id}", clinker);
        }

        //Get Enemies
        [HttpGet("{id}/enemies")]
        public IActionResult EnemiesList(int id)
        {
            var clinker = _repo.Get(id);
            if (clinker == null) return NotFound($"No clinker with Id {id} exists");
            if (clinker.Enemies.Count == 0) return NotFound($"{clinker.Name} has no enemies...");
            return Ok(clinker.Enemies);
        }

        //Get Services
        [HttpGet("{id}/services")]
        public IActionResult GetServices(int id)
        {
            var clinker = _repo.Get(id);
            if (clinker == null) return NotFound($"No Clinker of {id} exists...");
            if (clinker.Services.Count == 0) return NotFound($"{clinker.Name} has no services...");
            return Ok(clinker.Services);
        }

        // Get Friends of Friends
        [HttpGet("{id}/friends-of-friends")]
        public IActionResult FriendsOfFriends(int id)
        {
            var clinker = _repo.Get(id);
            var friendsOfFriends = new List<Clinker>();
            clinker.Friends.ForEach(friendId =>
            {
                var friend = _repo.Get(friendId);
                friend.Friends.ForEach(fofId =>
                {
                    var friendOfFriend = _repo.Get(fofId);
                    if (fofId != id && friendsOfFriends.IndexOf(friendOfFriend) < 0)
                    {
                        friendsOfFriends.Add(friendOfFriend);
                    }
                });
            });
            if (friendsOfFriends.Count == 0) return NotFound($"{clinker.Name} has no friends");
            return Ok(friendsOfFriends);
        }

        // Add enemies to clinker
        [HttpPut("{id}/add-enemy-{enemyId}")]

        public IActionResult AddEnemy(int id, int EnemyId)
        {
            var clinker = _repo.Get(id);
            var enemy = _repo.Get(EnemyId);
            if (clinker != null && enemy != null)
            {
                if (clinker.Enemies.IndexOf(EnemyId) >= 0)
                {
                    return StatusCode(208);
                }
                clinker.Enemies.Add(enemy.Id);
                return Ok($"Added {enemy.Name} as a Enemy");
            }
            return NotFound("Not valid clinker and enemy");

        }
    }
}
