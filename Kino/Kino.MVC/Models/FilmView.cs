using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino.MVC.Models
{
    public class FilmView
    {
        public string Title { get; set; }
        public int Release { get; set; }
        public Guid Id { get; set; }
    }
}