using Kino.Common;
using Kino.DAL;
using Kino.Model;
using Kino.MVC.Models;
using Kino.Service.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Kino.MVC.Controllers
{
    public class FilmController : Controller
    {
        protected IFilmService Service { get; set; }
        public FilmController(IFilmService service)
        {
            Service = service;
        }

        //-////////////////////////////////////////////////////////////////////

        // api/film/getallasync
        public async Task<ActionResult> GetAllAsync()
        {
            List<FilmDTO> filmList = await Service.GetAllAsync();
            List<FilmView> viewFilms = new List<FilmView>();
            foreach (FilmDTO film in filmList)
            {
                FilmView viewFilm = new FilmView();
                viewFilm.Id = film.Id;
                viewFilm.Title = film.Title;
                viewFilm.Release = film.Release;
                viewFilm.Genre = film.Genre;
                viewFilm.Duration = film.Duration;

                viewFilms.Add(viewFilm);
            }
            return View(viewFilms);
        }

        //-///////////////////////////////////////////////////////////////////////////

        // api/film/getbyidasync/{id}
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                FilmDTO film = await Service.GetByIdAsync(id);
                FilmView viewFilm = new FilmView();
                viewFilm.Id = film.Id;
                viewFilm.Title = film.Title;
                viewFilm.Release = film.Release;
                viewFilm.Genre = film.Genre;
                viewFilm.Duration = film.Duration;

                return View(viewFilm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        //-////////////////////////////////////////////////////////////////

        public async Task<ActionResult> Edit(Guid id)
        {

            FilmDTO film = await Service.GetByIdAsync(id);
            FilmView viewFilm = new FilmView();
            viewFilm.Id = film.Id;
            viewFilm.Title = film.Title;
            viewFilm.Release = film.Release;
            viewFilm.Genre = film.Genre;
            viewFilm.Duration = film.Duration;
            //List<FilmDTO> filmList = await Service.GetAllAsync();
            //Guid guidId = Guid.Parse(id);
            //FilmDTO film = filmList.Where(f => f.Id == guidId).FirstOrDefault();

            return View(viewFilm);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(FilmView film)
        {
            FilmDTO filmDTO = new FilmDTO();
            
            filmDTO.Id = film.Id;
            filmDTO.Title = film.Title;
            filmDTO.Release = film.Release;
            filmDTO.Genre = film.Genre; 
            filmDTO.Duration = film.Duration;
            
            await Service.PutAsync(filmDTO.Id.ToString(), filmDTO);

            return View();

        }

        //-////////////////////////////////////////////////////////////////////////

        public async Task<ActionResult> Details(Guid id)
        {
            FilmDTO film = await Service.GetByIdAsync(id);
            FilmView viewFilm = new FilmView();
            viewFilm.Id = film.Id;
            viewFilm.Title = film.Title;
            viewFilm.Release = film.Release;
            viewFilm.Genre = film.Genre;
            viewFilm.Duration = film.Duration;

            return View(viewFilm);

        }

        //-////////////////////////////////////////////////////////////////

        public async Task<ActionResult> Delete(Guid id)
        {

            FilmDTO film = await Service.GetByIdAsync(id);
            FilmView viewFilm = new FilmView();
            viewFilm.Id = film.Id;
            viewFilm.Title = film.Title;
            viewFilm.Release = film.Release;
            viewFilm.Genre = film.Genre;
            viewFilm.Duration = film.Duration;
            //List<FilmDTO> filmList = await Service.GetAllAsync();
            //Guid guidId = Guid.Parse(id);
            //FilmDTO film = filmList.Where(f => f.Id == guidId).FirstOrDefault();

            return View(viewFilm);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(FilmView film)
        {
            FilmDTO filmDTO = new FilmDTO();

            filmDTO.Id = film.Id;
            filmDTO.Title = film.Title;
            filmDTO.Release = film.Release;
            filmDTO.Genre = film.Genre;
            filmDTO.Duration = film.Duration;

            await Service.DeleteAsync(filmDTO.Id);

            return View();

        }

        //-/////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult> Create(/*FilmDTO filmDTO*/)
        {
            //await Service.PostAsync(filmDTO);

            return View(); 
        }
        [HttpPost]
        public async Task<ActionResult> Create(FilmView film)
        {
            FilmDTO filmDTO = new FilmDTO();

            filmDTO.Id = film.Id;
            filmDTO.Title = film.Title;
            filmDTO.Release = film.Release;
            filmDTO.Genre = film.Genre;
            filmDTO.Duration = film.Duration;

            await Service.PostAsync(filmDTO);

            return View();

        }

        /////////////////////////////////////////////////////////////////////////

        public async Task<ActionResult> GetPSFAsync(/*FilmFiltering filtering, Paging paging, */Sorting sorting)
        {
            List<FilmDTO> filmList = Service.GetPagingSortingFiltering(/*filtering, paging, */sorting); 
            List<FilmView> viewFilms = new List<FilmView>();
            foreach (FilmDTO film in filmList)
            {
                FilmView viewFilm = new FilmView();
                viewFilm.Id = film.Id;
                viewFilm.Title = film.Title;
                viewFilm.Release = film.Release;
                viewFilm.Genre = film.Genre;
                viewFilm.Duration = film.Duration;

                viewFilms.Add(viewFilm);
            }
            return View(viewFilms);
        }
    }
}
