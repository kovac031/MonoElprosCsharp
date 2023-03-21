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
        // public Actor GetActor(int id) // ovaj Actor je isto novi i jednina je samo da se razlikuje od ranijeg Actors
        public HttpResponseMessage GetActor(int id) // zamijenio jer nam Actor tu nije sto zelimo da returna neg taj http response message
        {
            try
            {
                Actor actor = actorsList.Where(x => x.Id == id).FirstOrDefault();
                if (actor != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, actor);

                    //return actorsList[id]; // api/casting/[id] sa GET ... ali mi sad ne treba jer returnam actor tu iznad
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No actors here!");
                }                
            }
            catch (Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing GetActor");
            }
        }

        [HttpPost]
        //public List<Actor> CreateActor([FromBody] Actor actor)
        public HttpResponseMessage CreateActor([FromBody] Actor actor)
        {
            try
            {
                Actor actor2 =  actorsList.Where(x => x.Id == actor.Id).FirstOrDefault();
                if (actor2 == null)
                {
                    actorsList.Add(actor); // u postmanu u BODY raw JSON api/casting POST uneses u formatu kako je GET return bilo sa viticastim zagradama, bez dodatnih provjera moze i duplicirati unose, ne javlja gresku
                    return Request.CreateResponse(HttpStatusCode.OK, actorsList);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ID occupied!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing CreateActor");
            }

            //return actorsList; //isto ne treba jer vracam hrm 
        }

        [HttpPut]
        public HttpResponseMessage UpdateActor(int id, [FromBody]Actor actor) // int id je prvo da u postmanu kao i gore definiram id u URLu, a da ostalo trazi iz bodya
        {
            try
            {
                Actor actor2 = actorsList.Where(x => x.Id == id).FirstOrDefault();
                if (actor2 != null)
                {
                    //Actor actor2 = actorsList.Find(x => x.Id == id); // ovo u zagradi mi je autopopunio
                    actor2.Name = actor.Name; // e sad tu su actor i actor 2 varijable samo za ovu primjenu, actor2 je za ono sto ja unesem u body a actor je za ono sta mi ispise za updejtanog glumca
                    actor2.Gender = actor.Gender;

                    return Request.CreateResponse<List<Actor>>(HttpStatusCode.OK, actorsList); // unutar <> definira tip returna, kod mene lista, ali mogu i bez toga
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No actors to update here!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing UpdateActor");
                //return actorsList;            
            }
        } 
            
        [HttpDelete]
        //public List<Actor> DeleteActor(int id) // api/casting/id i obrisat ce tog glumca
        public HttpResponseMessage DeleteActor(int id)
        {
            try
            {
                Actor actor = actorsList.Find(x => x.Id == id);
                if (actor != null)
                {
                    actorsList.Remove(actor);

                    return Request.CreateResponse<List<Actor>>(HttpStatusCode.OK, actorsList);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No actors to delete here!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing DeleteActor");
                //return actorsList;            
            }
        }
         
    }
}