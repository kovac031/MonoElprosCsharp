using Kino.Common;
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
        public SmallCinemaContext Context { get; set; }
        public EFFilmRepository(SmallCinemaContext context)
        {
            Context = context;
        }
        public async Task<List<FilmDTO>> GetAllAsync()
        {
            //List<Film> filmList = null;
            List<FilmDTO> filmDTOs;
            //SmallCinemaContext kino = new SmallCinemaContext();
            //using (SmallCinemaContext kino = new SmallCinemaContext()) // ne treba using
            //{
                filmDTOs = await Context.Films.Select(film => new FilmDTO()
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
            //SmallCinemaContext kino = new SmallCinemaContext();
            FilmDTO tajFilm;
            
            tajFilm = await Context.Films.Where(film => film.Id == id).Select(film => new FilmDTO()
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

            //SmallCinemaContext kino = new SmallCinemaContext();

            Context.Films.Add(new Film()
            {
                Id = film.Id = Guid.NewGuid(),
                Title = film.Title,
                Release = film.Release,
                Genre = film.Genre,
                Duration = film.Duration
            });

            Context.SaveChanges();
            return film;
            
        }

        public async Task<FilmDTO> PutAsync(string id, FilmDTO film)
        {
            //SmallCinemaContext kino = new SmallCinemaContext();
            
            Guid guidId = Guid.Parse(id);

            Film existingFilm = await Context.Films.Where(f => f.Id == guidId).FirstOrDefaultAsync();

            if (existingFilm != null)
            {

                //existingFilm.Id = film.Id;
                existingFilm.Title = film.Title;
                existingFilm.Release = film.Release;
                existingFilm.Genre = film.Genre;
                existingFilm.Duration = film.Duration;

                Context.SaveChanges();
                
            }
            else
            {
                return (null);
            }

            return film; // radi ali za id vraca nule u prikazu iako dobro spremi u bazu
        }
        public async Task<List<FilmDTO>> DeleteAsync(Guid id)
        {
            //SmallCinemaContext kino = new SmallCinemaContext();
            
            List<FilmDTO> filmDTOs;

            Film tajFilm = await Context.Films.FindAsync(id);
            
            Context.Films.Remove(tajFilm);
            Context.SaveChanges();

            filmDTOs = await Context.Films.Select(film => new FilmDTO()
            {
                Id = film.Id,
                Title = film.Title,
                Release = film.Release,
                Genre = film.Genre,
                Duration = film.Duration
            }).ToListAsync<FilmDTO>();

            return filmDTOs;

        }

        public List<FilmDTO> GetPagingSortingFiltering(FilmFiltering filtering, Paging paging, Sorting sorting)
        {
            IQueryable<Film> query = Context.Films.AsQueryable();

            List<FilmDTO> filmDTOs = Context.Films.Select(film => new FilmDTO()
            {
                Id = film.Id,
                Title = film.Title,
                Release = film.Release,
                Genre = film.Genre,
                Duration = film.Duration
            }).ToList<FilmDTO>();

            switch (sorting.OrderBy)
            {
                case "Title":
                    if (sorting.SortOrderAsc) query = query.OrderBy(ord => ord.Title);
                    else query = query.OrderByDescending(ord => ord.Title);
                    break;
            }

            return (null);
        }

    }
}
