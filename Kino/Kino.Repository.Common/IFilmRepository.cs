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
        Task<List<Film>> GetAllAsync();
        Task<Film> GetByIdAsync(Guid id);
        Task<Film> PostAsync(Film film);
        Task<Film> PutAsync(string id, Film film);
        Task<List<Film>> DeleteAsync(string id);

    }
}
