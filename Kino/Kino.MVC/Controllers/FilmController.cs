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

            await Service.DeleteAsync(filmDTO.Id);

            return View();

        }

        //-/////////////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<ActionResult> Create(FilmDTO filmDTO)
        {
            
            

            await Service.PostAsync(filmDTO);

            return View(); 
        }



        /////////////////////////////////////////////////////////////////////////

        /*

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        */
    }
}
