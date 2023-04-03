using Kino.Common;
using Kino.Model;
using Kino.Repository;
using Kino.Repository.Common;
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
        protected IFilmRepository Repository { get; set; }
        public FilmService(IFilmRepository repository)
        {
            Repository = repository;
        }

        public List<FilmDTO> GetPagingSortingFiltering(FilmFiltering filtering, Paging paging, Sorting sorting)
        {
            //FilmRepository repository = new FilmRepository();
            List<FilmDTO> filmList = Repository.GetPagingSortingFiltering(filtering, paging, sorting);
            return filmList;
        }


        /// ////////////////////////////////////////////////////////////////////

        public async Task<List<FilmDTO>> GetAllAsync()
        {
            //FilmRepository repository = new FilmRepository();
            List<FilmDTO> filmList = await Repository.GetAllAsync();
            return filmList;
        }
        
        public async Task<FilmDTO> GetByIdAsync(Guid id)
        {
            //FilmRepository repository = new FilmRepository();
            FilmDTO film = await Repository.GetByIdAsync(id);
            return film;
        }
        
        public async Task<FilmDTO> PostAsync(FilmDTO film)
        {
            //FilmRepository repository = new FilmRepository();
            FilmDTO filmService = await Repository.PostAsync(film);
            return filmService;
        }
        
        public async Task<FilmDTO> PutAsync(string id, FilmDTO film)
        {
            //FilmRepository repository = new FilmRepository();
            FilmDTO filmService = await Repository.PutAsync(id, film);
            return filmService;
        }
        
        public async Task<List<FilmDTO>> DeleteAsync(Guid id)
        {
            //FilmRepository repository = new FilmRepository();
            List<FilmDTO> filmService = await Repository.DeleteAsync(id);
            return filmService;
        }
    }
}
