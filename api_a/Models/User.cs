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
        public string isbnLivrePreferee { get; set; }
        public string nomEmissionPreferee { get; set; }
    }
}
