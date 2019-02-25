using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_a.Models
{
    public class User
    {
        public string id { get; set; }
        public string nom { get; set; }
        public string isbnLivrePrefere { get; set; }
        public string titreLivrePrefere { get; set; }
        public string[] auteurLivrePrefere { get; set; }
        public string urlCouvertureLivrePrefere { get; set; }
        public string datePublicationLivrePrefere { get; set; }
        public string nomEmissionPreferee { get; set; }
        public string[] genreEmissionPreferee { get; set; }
        public string[] jourEmissionPreferee { get; set; }
        public string heureEmissionPreferee { get; set; }

    }
}
