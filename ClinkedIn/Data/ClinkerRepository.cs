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
            new Clinker { Name = "Dingus", Id = 1, Services = { "Penguin Thievery", "Antarctic Sushi Making", "Toilet Sake Making" },  Interests = { "Home Brewing", "Romance Novels"}, DaysLeft = 500},
            new Clinker { Name = "Pingus", Id = 2, Services = { "Penguin Thievery", "Trumpet", "Ice Fishing" }, Interests = { "Animals", "Fishing", "Home Brewing" }, DaysLeft = 470 },
            new Clinker { Name = "Jim", Id = 3, Services = { "Soda Embezzlement", "Grand Theft Pastry" }, Interests = { "Art", "Fishing", "Philosphy" }, DaysLeft = 228 },
            new Clinker { Name = "Bill", Id = 4, Services = { "Shank Art", "Temporary Tattoo", "Home-sitting" }, Interests = { "Reading", "Yard Walks", "Meditation" }, DaysLeft = 396 },
            new Clinker { Name = "Fred", Id = 5, Services = { "Pencil Larceny", "Questionable Hootch Brewing" }, Interests = { "Art", "Meditation", "Home Brewing" }, DaysLeft = 872 },
        };

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }

        public Clinker Get(int id)
        {
            return _clinkers.FirstOrDefault(clinker => clinker.Id == id);
        }

        public void Add(Clinker clinker)
        {
            var biggestId = _clinkers.Max(clinker => clinker.Id) + 1;
            clinker.Id = biggestId;
            _clinkers.Add(clinker);
        }
     }
}
