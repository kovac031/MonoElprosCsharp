using Kino.Common;
using Kino.Model;
using Kino.Service;
using Kino.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kino.WebApi
{
    public class FilmController : ApiController
    {
        protected IFilmService Service { get; set; }
        public FilmController(IFilmService service) 
        {
            Service = service;
        }

        [HttpGet]
        [Route("api/film/getbyPSF")]
        public HttpResponseMessage GetPagingSortingFiltering([FromUri]FilmFiltering filtering)
        {
            try
            {
                List<Film> filmList = Service.GetPagingSortingFiltering(filtering);
                return Request.CreateResponse(HttpStatusCode.OK, filmList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing getbyPSF: {ex.Message}");
            }
        }





        ///////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("api/film/getallrest")] //rest varijanta
        public async Task<HttpResponseMessage> GetAllRestAsync()
        {
            //FilmService service = new FilmService(); // DI 

            try
            {
                List<Film> filmList = await Service.GetAllAsync();
                List<FilmRest> restFilms = new List<FilmRest>();
                foreach (Film film in filmList)
                {
                    FilmRest restFilm = new FilmRest();
                    restFilm.Title = film.Title;
                    restFilm.Release = film.Release;
                    
                    restFilms.Add(restFilm);
                }
                return Request.CreateResponse(HttpStatusCode.OK, restFilms);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetAll: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/film/getall")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            //FilmService service = new FilmService();
                        
            try
            {
                List<Film> filmList = await Service.GetAllAsync();
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
            //FilmService service = new FilmService();

            try
            {
                Film film = await Service.GetByIdAsync(id);
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
            //FilmService service = new FilmService();

            try
            {
                Film film = await Service.PostAsync(filmService);
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
            //FilmService service = new FilmService();

            try
            {
                Film film = await Service.PutAsync(id, filmService);
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
            //FilmService service = new FilmService();

            try
            {
                List<Film> filmList = await Service.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, filmList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Delete: {ex.Message}");
            }
        }
        
    }
}