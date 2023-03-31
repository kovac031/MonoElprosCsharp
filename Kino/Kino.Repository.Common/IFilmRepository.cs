using Kino.DAL;
using Kino.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Repository.Common
{
    public interface IFilmRepository
    {
        Task<List<FilmDTO>> GetAllAsync();
        Task<FilmDTO> GetByIdAsync(Guid id);
        Task<FilmDTO> PostAsync(FilmDTO film);
        Task<FilmDTO> PutAsync(string id, FilmDTO film);
        Task<List<FilmDTO>> DeleteAsync(Guid id);

        

    }
}
