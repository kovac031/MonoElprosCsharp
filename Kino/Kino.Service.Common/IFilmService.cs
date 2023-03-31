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
        Task<List<FilmDTO>> GetAllAsync();
        Task<FilmDTO> GetByIdAsync(Guid id);
        Task<FilmDTO> PostAsync(FilmDTO film);
        Task<FilmDTO> PutAsync(string id, FilmDTO film);
        Task<List<FilmDTO>> DeleteAsync(string id);

        ///////////////////////////////////////////////////////
        List<FilmDTO> GetPagingSortingFiltering(FilmFiltering filtering, Paging paging, Sorting sorting);

    }
}
