using Kino.Model;
using Kino.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kino.WebApi
{
    public class FilmController : ApiController
    {
        [HttpGet]
        [Route("api/film/getall")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            FilmService service = new FilmService();
                        
            try
            {
                List<Film> filmList = await service.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, filmList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetAll: {ex.Message}");
            }
        }
        
        [HttpGet]
        [Route("api/film/getbyid/{id}")]
        public async Task<HttpResponseMessage> GetByIdAsync(Guid id)
        {
            FilmService service = new FilmService();

            try
            {
                Film film = await service.GetByIdAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, film);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetById: {ex.Message}");
            }
        }
        
        [HttpPost]
        [Route("api/film/post")]
        public async Task<HttpResponseMessage> PostAsync(Film filmService)
        {
            FilmService service = new FilmService();

            try
            {
                Film film = await service.PostAsync(filmService);
                return Request.CreateResponse(HttpStatusCode.OK, film);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Post: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/film/put/{id}")]
        public async Task<HttpResponseMessage> PutAsync(string id, Film filmService)
        {
            FilmService service = new FilmService();

            try
            {
                Film film = await service.PutAsync(id, filmService);
                return Request.CreateResponse(HttpStatusCode.OK, film);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Put: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/film/del/{id}")]
        public async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            FilmService service = new FilmService();

            try
            {
                List<Film> filmList = await service.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, filmList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Put: {ex.Message}");
            }
        }
        
    }
}