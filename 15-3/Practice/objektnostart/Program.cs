using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


// Screening koji nasljedjuje od Movie, Movie ima podatke o filmu a Screening vrijeme prikazivanja i sl
namespace objektnostart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ovo je popis filmova koji se prikazuju u kinu:\n");

            Screening film = new Screening();

            film.Title = "Matrix";
            film.Genre = "fantasy";
            film.ReleaseYear = "2001";
            film.Room = "Dvorana 1";
            film.ScreeningTime = "petak 21:30";

            Console.WriteLine(film.Title);
            Console.WriteLine(film.Genre);
            Console.WriteLine(film.ReleaseYear);
            Console.WriteLine(film.Room);
            Console.WriteLine(film.ScreeningTime);

            Console.WriteLine("\nPošto imam samo jedan film, ajmo unijeti neke druge:\n");

            /*List<Movie> listOfMovies = new List<Movie>();

            string closeLoop = "x";
            //int i = 0;
            do
            {
                Console.WriteLine("\nNaziv filma molim:");
                film.Title = Console.ReadLine();
                Console.WriteLine("\nŽanr filma molim:");
                film.Genre = Console.ReadLine();
                Console.WriteLine("\nGodinu izlaska filma molim:");
                film.ReleaseYear = Console.ReadLine();
                
                listOfMovies.Add(film);

                Console.WriteLine("\nNastaviti unos? y/x\n");
                closeLoop = Console.ReadLine();
            }
            while (closeLoop != "x");

            foreach (Movie movie in listOfMovies) 
            {
            
                Console.WriteLine (movie.Title + "\n");
            
            }*/

            List<string> authors = new List<string>(); // tu doda autore u listu
            authors.Add("Mahesh Chand");
            authors.Add("Chris Love");
            authors.Add("Allen O'neill");
            authors.Add("Naveen Sharma");
            authors.Add("Monica Rathbun");
            authors.Add("David McCarter");

            foreach (string author in authors) // ovdje ih ispise jedan ispod drugog
            {
                Console.WriteLine(author);
            }

            string novoIme; // ovdje pokrecem loop za unos novih imena
            string closeLoop = "x";
            do
            {
                Console.WriteLine("Unesi ime:\n");
                authors.Add((novoIme = Console.ReadLine()));

                Console.WriteLine("\nNastaviti unos? y/x\n");
                closeLoop = Console.ReadLine();

            }
            while (closeLoop != "x");

            foreach (string author in authors) // ovdje opet ispisuje i sad su svi tu
            { 
                Console.WriteLine(author); 
            }

            Console.ReadLine();
        }
    }
}
