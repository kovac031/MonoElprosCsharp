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
            //using (SmallCinemaContext kino = new SmallCinemaContext()) // ne treba using
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

        

        public async Task<FilmDTO> GetByIdAsync(Guid id)
        {
            SmallCinemaContext kino = new SmallCinemaContext();
            FilmDTO tajFilm;
            
            tajFilm = await kino.Films.Where(film => film.Id == id).Select(film => new FilmDTO()
            {
                Id = film.Id,
                Title = film.Title,
                Release = film.Release,
                Genre = film.Genre,
                Duration = film.Duration
            }).FirstOrDefaultAsync<FilmDTO>();

            return tajFilm;
        }

        public async Task<FilmDTO> PostAsync(FilmDTO film)
        {

            SmallCinemaContext kino = new SmallCinemaContext();

            kino.Films.Add(new Film()
            {
                Id = film.Id = Guid.NewGuid(),
                Title = film.Title,
                Release = film.Release,
                Genre = film.Genre,
                Duration = film.Duration
            });

            kino.SaveChanges();
            return film;
            
        }

        public async Task<FilmDTO> PutAsync(string id, FilmDTO film)
        {
            SmallCinemaContext kino = new SmallCinemaContext();
            FilmDTO postojeciFilm;

            Guid guidId = Guid.Parse(id);

            postojeciFilm = await kino.Films.Where(f => f.Id == guidId).Select(f => new FilmDTO
            {
                Id = guidId,
                Title = f.Title,
                Release = f.Release,
                Genre = f.Genre,
                Duration = f.Duration

            }).FirstOrDefaultAsync();

            //if (postojeciFilm != null)
            //{
            //    postojeciFilm.Id = film.Id;
            //    postojeciFilm.Title = film.Title;
            //    postojeciFilm.Release = film.Release;
            //    postojeciFilm.Genre = film.Genre;
            //    postojeciFilm.Duration = film.Duration;

            //    kino.SaveChanges();
            //}
            //else
            //{
            //    return (null);
            //}

            return postojeciFilm; // id budu nule neznam zasto
        }
        public async Task<List<FilmDTO>> DeleteAsync(Guid id)
        {
            SmallCinemaContext kino = new SmallCinemaContext();
            FilmDTO tajFilm;
            List<FilmDTO> filmDTOs;
            //Guid guidId = Guid.Parse(id);

            tajFilm = await kino.Films.Where(f => f.Id == id).FirstOrDefaultAsync<FilmDTO>();

            kino.Entry(tajFilm).State = EntityState.Deleted;
            kino.SaveChanges();

            filmDTOs = await kino.Films.Select(film => new FilmDTO()
            {
                Id = film.Id,
                Title = film.Title,
                Release = film.Release,
                Genre = film.Genre,
                Duration = film.Duration
            }).ToListAsync<FilmDTO>();

            return filmDTOs;

            //throw new NotImplementedException();
        }

    }
}
