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

            /*string NekiTekst = "Ovo je neki tekst";
            Console.WriteLine(NekiTekst);

            int NekiBroj = 123;
            Console.WriteLine("Tvoj broj je: \n" + NekiBroj);

            Console.WriteLine("\nUnesi neki broj: ");
            string NekiBroj2 = Console.ReadLine();
            int NekiBroj3 = Convert.ToInt32(NekiBroj2); //dakle posto nemos unositi int direktno, uneses string ali kazes da int poprimi tu vrijednost, tj convertas
            Console.WriteLine("(Converttoint32) Tvoj broj je: \n" + NekiBroj2);

            Console.WriteLine("\nUnesi neki broj: ");
            string NekiBroj4 = Console.ReadLine();
            int NekiBroj5 = int.Parse (NekiBroj4); //isto ali s parse ... u biti nismo ni morali ni convertat radi samo ispisa
            Console.WriteLine("(Parse) Tvoj broj je: \n" + NekiBroj5);
            //int Kvadratic = NekiBroj4 * NekiBroj4; aha znači ovaj neće jer je string, dakle za dalje računanje na treba convert ali samo za ispis ne
            int Kvadrat = NekiBroj5 * NekiBroj5;
            Console.WriteLine("Kvadrat broja je: \n" + Kvadrat);*/

            /*Console.WriteLine("Jesi li prošao ispit?\n");
            Console.WriteLine("Unesi svoj broj bodova:\n");
            string Rezultat = Console.ReadLine(); 
            int Bodovi = Convert.ToInt32(Rezultat);
            bool Prolaz = true;
            bool Pad = true;
            if (Bodovi >= 60) 
            {
                Console.WriteLine("\nČisti prolaz!");
                Console.WriteLine("\nProlaz=true?\n" + Prolaz); 
            }
            else
            {
                Console.WriteLine("\nNedovoljno za prolaz!");
                Console.WriteLine("\nPad=true?\n" + Pad);
            }*/

            string[] jezici = { "hrvatski", "engleski", "njemacki", "kineski" };
            Console.WriteLine("\nPogodi koji mi je drugi strani jezik:\n");
            Console.WriteLine(jezici[1]);
            Console.WriteLine(jezici[0]);
            Console.WriteLine(jezici[3]);
            Console.WriteLine(jezici[2]);
            Console.WriteLine("\n");
            string Jezik = Console.ReadLine();
            int Izbor = int.Parse (Jezik);
            int Izbor2 = Izbor + 1;
            if (Izbor2 == 1) 
            {
                Console.WriteLine("\nNije hrvatski, to mi je materinski jezik.");            
            }
            else if (Izbor2 == 2)
            {
                Console.WriteLine("\nEngleski mi je drugi jezik, tako je.");
            }
            else if (Izbor2 == 3) 
            {
                Console.WriteLine("\nNjemački mi je treći, ali više ga baš i ne znam.");
            }
            else if (Izbor2 == 4) 
            {
                Console.WriteLine("\nKineski mi je četvrti strani jezik.");
            }
            else 
            { 
                Console.WriteLine("Znam samo "); 
                Console.WriteLine(jezici.Length);
                Console.WriteLine(" jezika.");
            }





            Console.ReadLine(); 
        }

    }
}
