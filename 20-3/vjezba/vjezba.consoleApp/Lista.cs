using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezba.consoleApp
{
    internal class Lista
    {

        public string Name { get; set; }
        public string Book { get; set; }
        public double Price { get; set; }

        List<Lista> mojaLista = new List<Lista>
            {
            new Lista { Name = "Mahesh Chand", Book = "ADO.NET Programming", Price = 49.95 },
            new Lista { Name = "Neel Beniwal", Book = "Jump Ball", Price = 19.95 },
            new Lista { Name = "Chris Love", Book = "Practical PWA", Price = 29.95 }
            };
    }
}
