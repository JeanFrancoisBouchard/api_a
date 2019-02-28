using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.Threading.Tasks;
using api_a.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace api_a.Services
{
    public class UserService
    {
        RestClient _client;
        RestClient _clientPrime;
        RestClient _clientLivre;
        RestClient _clientSerie;

        public UserService(IConfiguration config)
        {
            _client = new RestClient(config.GetConnectionString("client"));
            _clientPrime = new RestClient(config.GetConnectionString("clientPrime"));
            _clientLivre = new RestClient(config.GetConnectionString("clientLivre"));
            _clientSerie = new RestClient(config.GetConnectionString("clientSerie"));

            _clientPrime.Timeout = 5000;
            _client.Timeout = 5000;
        }

        public string Get()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            return RequestSorter(request).Content;
        }

        public string Get(string id)
        {
            var request = new RestRequest("{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", "value");
            request.AddUrlSegment("id", id);
            return RequestSorter(request).Content;
        }

        public string Post(string nom, string isbnLivrePrefere, string nomEmissionPreferee)
        {
            User user = new User { nom = nom };
            int i;
            // Appel de l'api C

            var request = new RestRequest("{isbn}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("isbn", isbnLivrePrefere);

            IRestResponse resp = _clientLivre.Execute(request);

            if(resp.StatusCode != 0)
            {
                var responseJson = JObject.Parse(resp.Content);

                if(responseJson.HasValues)
                {
                    user.isbnLivrePrefere = responseJson["isbn"].ToString();
                    user.titreLivrePrefere = responseJson["titre"].ToString();
                    user.auteurLivrePrefere = responseJson["auteur"].ToString();
                    user.urlCouvertureLivrePrefere = responseJson["urlImage"].ToString();
                    user.datePublicationLivrePrefere = responseJson["publication"].ToString();
                }
            }

            request = new RestRequest("{nomEmission}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", "value");
            request.AddUrlSegment("nomEmission", nomEmissionPreferee);

            resp = _clientSerie.Execute(request);

            if(resp.StatusCode != 0)
            {
                var responseJson = JObject.Parse(resp.Content);

                if(responseJson.HasValues)
                {
                    user.nomEmissionPreferee = responseJson["nomEmission"].ToString();
                    user.genreEmissionPreferee = responseJson["genres"].ToString();
                    user.jourEmissionPreferee = responseJson["jour"].ToString();
                    user.heureEmissionPreferee = responseJson["heure"].ToString();
                }
            }


            // Appel de l'api B
            request = new RestRequest(Method.POST);
            request.AddJsonBody(user);

            resp = RequestSorter(request);

            if(resp.StatusCode != 0)
            {
                return "Réussi";
            }

            return "Indisponible";
        }


        //Méthode qui appele le backup s'il n'y a pas de réponse du premier client
        private IRestResponse RequestSorter(RestRequest req)
        {
            IRestResponse response = _client.Execute(req);
            if(response.StatusCode == 0)
            {
                response = _clientPrime.Execute(req);
            }
            return response;
        }
    }
}
