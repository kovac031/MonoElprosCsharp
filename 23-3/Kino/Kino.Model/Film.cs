using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Model
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Release { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}
