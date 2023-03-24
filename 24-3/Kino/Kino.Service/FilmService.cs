using Kino.Model;
using Kino.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Service
{
    public class FilmService
    {
        public List<Film> GetAll()
        {
            FilmRepository repository = new FilmRepository();
            List<Film> filmList = repository.GetAll();
            return filmList;
        }

        public Film GetById(Guid id)
        {
            FilmRepository repository = new FilmRepository();
            Film film = repository.GetById(id);
            return film;
        }

        public Film Post(Film film)
        {
            FilmRepository repository = new FilmRepository();
            Film filmService = repository.Post(film);
            return filmService;
        }

        public Film Put(string id, Film film)
        {
            FilmRepository repository = new FilmRepository();
            Film filmService = repository.Put(id, film);
            return filmService;
        }

        public List<Film> Delete(string id)
        {
            FilmRepository repository = new FilmRepository();
            List<Film> filmService = repository.Delete(id);
            return filmService;
        }
    }
}
