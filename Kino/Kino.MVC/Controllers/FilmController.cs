using Kino.Model;
using Kino.MVC.Models;
using Kino.Service.Common;
using System;
using System.Collections.Generic;
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
                viewFilm.Title = film.Title;
                viewFilm.Release = film.Release;

                viewFilms.Add(viewFilm);
            }
            return View(viewFilms);
        }

        
        /////////////////////////////////////////////////////////////////////////
        

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
    }
}
