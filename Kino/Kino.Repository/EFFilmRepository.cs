using Kino.DAL;
using Kino.Model;
using Kino.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Repository
{
    public class EFFilmRepository : IFilmRepository
    {
        
        public async Task<List<FilmDTO>> GetAllAsync()
        {
            //List<Film> filmList = null;
            List<FilmDTO> filmDTOs;
            SmallCinemaContext kino = new SmallCinemaContext();
            //using (SmallCinemaContext kino = new SmallCinemaContext())
            //{
                filmDTOs = await kino.Films.Select(film => new FilmDTO()
                {
                    Id = film.Id,
                    Title = film.Title,
                    Release = film.Release,
                    Genre = film.Genre,
                    Duration = film.Duration
                }).ToListAsync<FilmDTO>();

            //}
            return filmDTOs;
        }

        

        public Task<FilmDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FilmDTO> PostAsync(FilmDTO film)
        {
            throw new NotImplementedException();
        }

        public Task<FilmDTO> PutAsync(string id, FilmDTO film)
        {
            throw new NotImplementedException();
        }
        public Task<List<FilmDTO>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

    }
}
