using Kino.Common;
using Kino.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Service.Common
{
    public interface IFilmService
    {
        Task<List<Film>> GetAllAsync();
        Task<Film> GetByIdAsync(Guid id);
        Task<Film> PostAsync(Film film);
        Task<Film> PutAsync(string id, Film film);
        Task<List<Film>> DeleteAsync(string id);

        ///////////////////////////////////////////////////////
        List<Film> GetPagingSortingFiltering(FilmFiltering filtering, Paging paging);

    }
}
