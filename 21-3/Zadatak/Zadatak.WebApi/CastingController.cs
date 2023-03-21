using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Zadatak.WebApi
{
    public class CastingController : ApiController
    {
        public static List<Actor> actorsList = new List<Actor>
        {
            new Actor { Id = 1, Name = "John Wayne", Gender = "M" },
            new Actor { Id = 2, Name = "Kevin Costner", Gender = "M" },
            new Actor { Id = 3, Name = "Charlize Theron", Gender = "F" },
            new Actor { Id = 4, Name = "Sarah Gadon", Gender = "F" },
            new Actor { Id = 5, Name = "Liu Yifei", Gender = "F" }
        };

        public static List<Movie> moviesList = new List<Movie>
        {
            new Movie { Id = 1, Title = "Titanic"},
            new Movie { Id = 2, Title = "Avatar"},
            new Movie { Id = 3, Title = "Gladiator"},
            new Movie { Id = 4, Title = "Independce Day"},
            new Movie { Id = 5, Title = "Kako je počeo rat na mom otoku"}
        };

        [HttpGet]
        public List<Actor> GetActors() // ovaj Actors je tu prvi put nazvan, svejedno je kako se METODA zove tu
        {
            return actorsList; // https(dvotocka)//localhost:44333/api/casting jer je casting controller
        }


        /*
        // GET api/casting
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/casting/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/casting
        public void Post([FromBody] string value)
        {
        }

        // PUT api/casting/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/casting/5
        public void Delete(int id)
        {
        }
        */
    }
}