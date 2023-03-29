using Kino.Model;
using Kino.Repository;
using Kino.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Service
{
    public class FilmService : IFilmService
    {
        public async Task<List<Film>> GetAllAsync()
        {
            FilmRepository repository = new FilmRepository();
            List<Film> filmList = await repository.GetAllAsync();
            return filmList;
        }
        
        public async Task<Film> GetByIdAsync(Guid id)
        {
            FilmRepository repository = new FilmRepository();
            Film film = await repository.GetByIdAsync(id);
            return film;
        }
        
        public async Task<Film> PostAsync(Film film)
        {
            FilmRepository repository = new FilmRepository();
            Film filmService = await repository.PostAsync(film);
            return filmService;
        }
        
        public async Task<Film> PutAsync(string id, Film film)
        {
            FilmRepository repository = new FilmRepository();
            Film filmService = await repository.PutAsync(id, film);
            return filmService;
        }
        
        public async Task<List<Film>> DeleteAsync(string id)
        {
            FilmRepository repository = new FilmRepository();
            List<Film> filmService = await repository.DeleteAsync(id);
            return filmService;
        }
    }
}
