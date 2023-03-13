using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Koji je sada mjesec?");

            string userMonth = Console.ReadLine();
            string result = userMonth.ToLower();
            
            if (userMonth == "ozujak")
            {
                Console.WriteLine(userMonth + ". Jeste dabome.");
            }
            else if (userMonth == "sijecanj" )
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec"); 
            }
            else if (userMonth == "veljaca")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "travanj")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "svibanj")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "lipanj")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "srpanj")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "kolovoz")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "rujan")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "listopad")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "studeni")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else if (userMonth == "prosinac")
            {
                Console.WriteLine(userMonth + " ...Krivi mjesec");
            }
            else 
            {
                Console.WriteLine(userMonth + " ...Pa jel to mjesec?");
            } */

            string NekiTekst = "Ovo je neki tekst";
            Console.WriteLine(NekiTekst);

            int NekiBroj = 123;
            Console.WriteLine("Tvoj broj je: \n" + NekiBroj);

            Console.WriteLine("Unesi neki broj: ");
            string NekiBroj2 = Console.ReadLine();
            int NekiBroj3 = Convert.ToInt32(NekiBroj2);
            Console.WriteLine("Tvoj broj je: \n" + NekiBroj2);

            bool NekiBool = false;





            Console.ReadLine(); 
        }

    }
}
