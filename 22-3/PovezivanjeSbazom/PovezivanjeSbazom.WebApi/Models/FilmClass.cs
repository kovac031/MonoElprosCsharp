using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PovezivanjeSbazom.WebApi.Models
{
    public class FilmClass
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Release { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}