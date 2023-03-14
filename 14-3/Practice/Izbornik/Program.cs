using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izbornik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mainIzbornik = { "1. Simpa opcije", "2. Zmajska", "3. Internet", "4. Televizija i glazba", "5. Roaming Surf", "6. VoLTE i VoWIFI", "7. Ostalo" };
            Console.WriteLine("Posaljite broj pokraj grupe opcija koju zelite aktivirati.\n");
            int i = 0;
            do 
            {
                Console.WriteLine(mainIzbornik[i]); 
                i++; 
            } 
            while (i < mainIzbornik.Length);
            
            string mainIzborStr = Console.ReadLine();
            //int mainIzborInt = int.Parse(mainIzborStr); /// a ni ovo mi ne treba jer hocu da prihvaca unos "NE" i switch prihvaca tak da mi ne treba int parse
            //int mainIzbor = mainIzborInt + 1; // ovo mi ne treba jer se nigdje ne vezem za string

            switch(mainIzborStr)
            {
                case "1":
                    Console.WriteLine("\nPosaljite broj opcije koju zelite aktivirati:\n");
                    string[] simpaIzbornik = { "1. Simpa L", "2. Simpa M", "3. Simpa S", "4. Simpa XS" };
                    int j  = 0;
                    do
                    {
                        Console.WriteLine(simpaIzbornik[j]);
                        j++;
                    }
                    while (j < simpaIzbornik.Length);

                    string simpaIzbor = Console.ReadLine();
                    
                    switch(simpaIzbor)
                    {
                        case "1":
                            Console.WriteLine("\nZelite aktivirati Simpa L po cijeni 14,47 EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");
                            
                            string simpaIzbor1 = Console.ReadLine();
                            string simpaIzbor1L =simpaIzbor1.ToLower();
                            switch(simpaIzbor1L)
                            {
                                case "da":
                                    Console.WriteLine("\nUnesite dostupan iznos na racunu:\n");

                                    string simpaIznosStr  = Console.ReadLine();
                                    int simpaIznosInt = int.Parse(simpaIznosStr);

                                break;
                            }

                            break;
                    }

                    break;
            }

            Console.ReadLine();
        }
    }
}
