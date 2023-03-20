using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Baza.WebApi.Controllers
{
    public class MovieController : ApiController // zato sto je "movie"controller pokupio jer movie iz naslova 
    {
        // GET api/movie
        public IEnumerable<string> Get()
        {
            //return new string[] { , "value2" };

            Film film = new Film();
            return new string[] { film.Title };

        }

        // GET api/movie/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/movie
        public void Post([FromBody]int id, [FromBody]string title)
        {
            
            
            //Movie film = new Movie();
            //film.Id = Guid.NewGuid();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}