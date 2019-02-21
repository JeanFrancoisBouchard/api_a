using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_a.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_a.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public string Get()
        {
            return _userService.Get();
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            return _userService.Get(id);
        }

        [HttpPost("{nom}/{isbnLivrePrefere}/{nomEmissionPreferee}")]
        public string Post(string nom, string isbnLivrePrefere, string nomEmissionPreferee)
        {
            return _userService.Post(nom, isbnLivrePrefere, nomEmissionPreferee);
        }
    }
}