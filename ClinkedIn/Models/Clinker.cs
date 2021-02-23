using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Clinker
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<string> Services { get; set; } = new List<string>();
        public List<string> Interests { get; set; } = new List<string>();
        public List<Clinker> Friends { get; set; } = new List<Clinker>();
        public List<Clinker> Enemies { get; set; } = new List<Clinker>();
        public bool Lonely { get; set; }
        public int DaysLeft { get; set; }
    }
}
