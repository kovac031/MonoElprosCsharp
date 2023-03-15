using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objektnostart
{
    internal class Screening : Movie
    {
        public string ScreeningTime { get; set; }

        public string Room { get; set; }    

        public List<Movie> Movies { get; set; }
    }
}
