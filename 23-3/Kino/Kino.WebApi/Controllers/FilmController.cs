using Kino.Model;
using Kino.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace Kino.WebApi
{
    public class FilmController : ApiController
    {
        [HttpGet]
        [Route("api/film/getall")]
        public HttpResponseMessage GetAll()
        {
            FilmService service = new FilmService();
            List<Film> filmList = service.GetAll();
            
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, filmList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetFilms: {ex.Message}");
            }
        }
    }
}