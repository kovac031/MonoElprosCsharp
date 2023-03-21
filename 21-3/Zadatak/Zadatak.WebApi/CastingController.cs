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

        [HttpGet]
        public Actor GetActor(int id) // ovaj Actor je isto novi i jednina je samo da se razlikuje od ranijeg Actors
        { 
            return actorsList[id]; // api/casting/[id] sa GET
        }

        [HttpPost]
        public List<Actor> CreateActor([FromBody] Actor actor)
        { 
            actorsList.Add(actor); // u postmanu u BODY raw JSON api/casting POST uneses u formatu kako je GET return bilo sa viticastim zagradama, bez dodatnih provjera moze i duplicirati unose, ne javlja gresku
            return actorsList;
        }

        [HttpPut]
        public List<Actor> UpdateActor(int id, [FromBody]Actor actor2) // int id je prvo da u postmanu kao i gore definiram id u URLu, a da ostalo trazi iz bodya
        {
            Actor actor = actorsList.Find(x => x.Id == id); // ovo u zagradi mi je autopopunio
            actor.Name = actor2.Name; // e sad tu su actor i actor 2 varijable samo za ovu primjenu, actor2 je za ono sto ja unesem u body a actor je za ono sta mi ispise za updejtanog glumca
            actor.Gender = actor2.Gender;

            return actorsList;
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