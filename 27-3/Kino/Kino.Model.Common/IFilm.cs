using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Model.Common
{
    public interface IFilm
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Genre { get; set; }
        int Duration { get; set; }

    }
}
