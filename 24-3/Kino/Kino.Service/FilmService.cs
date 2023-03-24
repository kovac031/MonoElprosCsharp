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

    }
}
