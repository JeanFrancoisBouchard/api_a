using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_a.Models
{
    public class Livre
    {
        public string isbn { get; set; }
        public string titre { get; set; }
        public string auteur { get; set; }
        public string urlImage { get; set; }
        public string publication { get; set; }


        public Livre(string isbn, string titre, string auteur, string urlImage, string publication)
        {
            this.isbn = isbn;
            this.titre = titre;
            this.auteur = auteur;
            this.urlImage = urlImage;
            this.publication = publication;
        }
    }
}
