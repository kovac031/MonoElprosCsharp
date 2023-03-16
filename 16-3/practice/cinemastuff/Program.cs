using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemastuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Buyer buyer = new Buyer();

            List<Buyer> membersList = new List<Buyer>();
            
            string closeLoop = "x";
            int i = 1;
            do
            {
                int count = i;
                Buyer buyer = new Buyer(); // ovaj ne ide van petlje, inace se rezultat ponavlja
                buyer.Id = Guid.NewGuid();
                buyer.Name = Console.ReadLine();
                buyer.Address = Console.ReadLine();
                buyer.ContactPhone = Console.ReadLine();

                membersList.Add(buyer);

                i++;

                foreach (Buyer buyer2 in membersList) // tu mora ici buyer2 jer se mora razlikovati od buyera, ali taj buyer2 ne postoji izvan ove petlje
                {
                    Console.WriteLine(count+"." + "\t" + buyer2.Id + "\t" + buyer2.Name + "\t" + buyer2.Address + "\t" + buyer2.ContactPhone);
                }
                closeLoop = Console.ReadLine();
            }
            while (closeLoop != "x");

            var rezultat = membersList.ElementAt(1);
            Console.WriteLine(rezultat); 
            
            /*foreach (Buyer buyer in membersList)
            {
                Console.WriteLine(buyer.Name + "\t" + buyer.Address + "\t" + buyer.ContactPhone);
            }*/



            /*buyer.Name = Console.ReadLine();
            //buyer.Name = Console.ReadLine();


            Guid newGuid = Guid.NewGuid();
            Console.WriteLine();*/

            Console.ReadLine();
        }
    }
}
