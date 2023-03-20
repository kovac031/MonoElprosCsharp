using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezba.consoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Author> authors = new List<Author>
            {
            new Author { Name = "Mahesh Chand", Book = "ADO.NET Programming", Price = 49.95 },
            new Author { Name = "Neel Beniwal", Book = "Jump Ball", Price = 19.95 },
            new Author { Name = "Chris Love", Book = "Practical PWA", Price = 29.95 }
            };
            try
            {
                foreach (Author author in authors)
                {
                    Console.Write($"{author.Name}\t{author.Book}\t{author.Price}\n");
                }
            }
            catch (Exception ex) { }
            Console.ReadKey();

            //////////////////////////////////////////////////////////
            ///lista ali iz druge klase
            ///

            List<Lista> mojaLista = new List<Lista>();
            try
            {
                foreach (Lista lista in Lista.mojaLista)
                {
                    Console.Write($"{lista.Name}\t{lista.Book}\t{lista.Price}\n");
                }
            }
            catch (Exception ex) { }
            Console.ReadKey();



        }
    }
    public class Author
    {
        // Auto-Initialized properties
        public string Name { get; set; }
        public string Book { get; set; }
        public double Price { get; set; }
        
    }
}
