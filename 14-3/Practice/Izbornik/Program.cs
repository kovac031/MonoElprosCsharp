using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izbornik
{
    internal class Program
    {
         static void Izracun()
        {
            Console.WriteLine("Unesi cijenu opcije:\n");
            string cijena = Console.ReadLine();
            decimal cijenaD = decimal.Parse(cijena);
            Console.WriteLine("Unesi dostupan iznos na racunu:\n");
            string racun = Console.ReadLine();
            decimal racunD = decimal.Parse(racun);
            string kraj = (cijenaD <= racunD) ? "\nIznos na racunu je dovoljan i opcija je uspjesno aktivirana!" : "\nIznos na racunu je nedovoljan za aktivaciju.";
            Console.WriteLine(kraj);
        }
        static void Main(string[] args)
        {
            string[] mainIzbornik = { "1. Simpa opcije", "2. Zmajska", "3. Internet", "4. Televizija i glazba", "5. Roaming Surf", "6. VoLTE i VoWIFI", "7. Ostalo" };
            izbornik:
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

            //bool check = false;
            //while (check = false)
            //{
                switch (mainIzborStr)
                {
                   
                case "1":
                    simpa:
                        Console.WriteLine("\nPosaljite broj opcije koju zelite aktivirati:\n");
                        string[] simpaIzbornik = { "1. Simpa L", "2. Simpa M", "3. Simpa S", "4. Simpa XS" };
                        int j = 0;
                        do
                        {
                            Console.WriteLine(simpaIzbornik[j]);
                            j++;
                        }
                        while (j < simpaIzbornik.Length);

                        string simpaIzbor = Console.ReadLine();
                   // test:
                        switch (simpaIzbor)
                        {
                            case "1":
                                Console.WriteLine("\nZelite aktivirati Simpa L po cijeni 14,47 EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");

                                string simpaIzbor1 = Console.ReadLine();
                                string simpaIzbor1L = simpaIzbor1.ToLower();
                                switch (simpaIzbor1L)
                                {
                                    case "da":
                                        /*Program instanca = new Program();
                                        instanca.Izracun();*/
                                        Izracun();
                                        break;

                                    case "ne":
                                    goto simpa;

                                    default:
                                    Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                                    goto simpa;
                                }
                                break;

                            case "2":
                                Console.WriteLine("\nZelite aktivirati Simpa M po cijeni 12,47 EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");

                                string simpaIzbor2 = Console.ReadLine();
                                string simpaIzbor2L = simpaIzbor2.ToLower();
                                switch (simpaIzbor2L)
                                {
                                    case "da":
                                        Izracun();
                                        break;

                                    case "ne":
                                    goto simpa;

                                    default:
                                    Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                                    goto simpa;
                                }
                                break;

                            default:
                            Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                            goto izbornik;
                    }

                        break;
                }
            //}

            Console.ReadLine();
        }
    }
}
