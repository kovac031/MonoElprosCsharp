using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baza.WebApi
{
    public class Film
    {
        public int Id { get; set; }

        public string Title { get; set; }

        List<Film> filmList = new List<Film>
            {
                new Film { Id = 1, Title = "Titanic" },
                new Film { Id = 2, Title = "Hellboy"}
            };

        /*public Film(int movieId, string movieTitle) 
        {
            //this.Id = movieId;
            //this.Title = movieTitle;

            

           // Film film = new Film(1, "Titanic");
           // filmList.Add(film.Id = 1, film.Title = "Titanic");

        }*/

    }
}