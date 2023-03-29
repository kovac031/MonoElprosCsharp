using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Common
{
    public class FilmFiltering
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        //public int? Release { get; set; }
        public int? ReleaseMin { get; set; }
        public int? ReleaseMax { get; set; }
        //public int? Duration { get; set; }
        public int? MinDuration { get; set; }
        public int? MaxDuration { get; set; }

    }
}
