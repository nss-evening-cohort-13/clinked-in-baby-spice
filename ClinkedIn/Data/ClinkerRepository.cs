using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.Data
{
    public class ClinkerRepository
    {
        static List<Clinker> _clinkers = new List<Clinker>
        {
            new Clinker { Name = "Dingus", Id = 1, Services = { "Penguin Thievery", "Antarctic Sushi Making", "Toilet Sake Making" },  Interests = { "Home Brewing", "Romance Novels"}, DaysLeft = 666},
            new Clinker { Name = "Pingus", Id = 2, Services = { "Penguin Thievery", "Trumpet", "Ice Fishing"}, Interests = { "Animals", "Fishing" }, DaysLeft = 420 },
        };

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }
    }
}
