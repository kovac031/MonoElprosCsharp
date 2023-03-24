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
                        
            try
            {
                List<Film> filmList = service.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, filmList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetAll: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/film/getbyid/{id}")]
        public HttpResponseMessage GetById(Guid id)
        {
            FilmService service = new FilmService();

            try
            {
                Film film = service.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, film);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetById: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/film/post")]
        public HttpResponseMessage Post(Film filmService)
        {
            FilmService service = new FilmService();

            try
            {
                Film film = service.Post(filmService);
                return Request.CreateResponse(HttpStatusCode.OK, film);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Post: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/film/put/{id}")]
        public HttpResponseMessage Put(string id, Film filmService)
        {
            FilmService service = new FilmService();

            try
            {
                Film film = service.Put(id, filmService);
                return Request.CreateResponse(HttpStatusCode.OK, film);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Put: {ex.Message}");
            }
        }

    }
}