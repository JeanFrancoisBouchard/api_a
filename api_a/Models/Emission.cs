using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_a.Models
{
    public class Emission
    {
        public string heure { get; set; }
        public string jour { get; set; }
        public string genre { get; set; }

        public Emission(string heure, string jour, string genre)
        {
            this.heure = heure;
            this.jour = jour;
            this.genre = genre;

        }
    }
}
