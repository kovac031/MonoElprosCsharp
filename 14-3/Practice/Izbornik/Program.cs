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

        /*static void simpaDaNe1() // rad u tijeku, pokusaj prebacivanja da svi caseovi se vrte u biti kao odvojena funkcija, da bude preglednija switch petlja
        {
            //Console.WriteLine($"\nZelite aktivirati {opcija} po cijeni {cijena} EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");

            string simpaDaNe = Console.ReadLine();
            string simpaDaNeL = simpaDaNe.ToLower();
            switch (simpaDaNeL)
            {
                case "da":
                    Izracun();
                    break;

                case "ne":
                    goto simpa;

                default:
                    Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                    goto simpa;
                    break;
            }
            

        }*/
        static void Main(string[] args)
        {
            string[] mainIzbornik = { "1. Simpa opcije", "2. Zmajska", "3. Internet (ne radi)", "4. Televizija i glazba (ne radi)", "5. Roaming Surf (ne radi)", "6. VoLTE i VoWIFI (ne radi)", "7. Ostalo (ne radi)" };
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
                        string[] simpaIzbornik = { "1. Simpa L", "2. Simpa M (rad u tijeku)", "3. Simpa S (ne radi)", "4. Simpa XS (ne radi)" };
                        int j = 0;
                        do
                        {
                            Console.WriteLine(simpaIzbornik[j]);
                            j++;
                        }
                        while (j < simpaIzbornik.Length);

                        string simpaIzbor = Console.ReadLine();
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
                                Console.WriteLine("\nZelite aktivirati Simpa M po cijeni 11,81 EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");

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

                            /*case "3":
                            string opcija = "Simpa M";
                            string cijena = "11.81";

                            simpaDaNe1();*/

                            default:
                            Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                            goto izbornik;
                            break;
                        }
                        break;
                case "2":
                    zmajska:

                        Console.WriteLine("\nPosaljite broj opcije koju zelite aktivirati:\n");
                        string[] zmajIzbornik = { "1. Zmaj", "2. Zmajic" };
                        int h = 0;
                        do
                        {
                            Console.WriteLine(zmajIzbornik[h]);
                            h++;
                        }
                        while (h < zmajIzbornik.Length);

                        string zmajIzbor = Console.ReadLine();
                        switch (zmajIzbor)
                        {
                        case "1":
                            Console.WriteLine("\nZelite aktivirati opciju Zmaj po cijeni 10,27 EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");

                            string zmajIzbor1 = Console.ReadLine();
                            string zmajIzbor1L = zmajIzbor1.ToLower();
                            switch (zmajIzbor1L)
                            {
                                case "da":
                                Izracun();
                                break;

                                case "ne":
                                goto zmajska;

                                default:
                                    Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                                    goto zmajska;
                            }
                            break;

                            case "2":
                            Console.WriteLine("\nZelite aktivirati opciju Zmajic po cijeni 8,81 EUR, odgovori s DA. Opcija ukljucuje blablabla. Odgovori NE za povratak na prijasnji izbornik.\n");

                            string zmajIzbor2 = Console.ReadLine();
                            string zmajIzbor2L = zmajIzbor2.ToLower();
                            switch (zmajIzbor2L)
                            {
                                case "da":
                                Izracun();
                                break;

                                case "ne":
                                goto zmajska;

                                default:
                                    Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                                goto zmajska;
                            }
                            break;

                /*case "3":
                string opcija = "Simpa M";
                string cijena = "11.81";

                simpaDaNe1();*/

                default:
                    Console.WriteLine("\nNepoznat unos. Pokusajte ponovo.");
                    goto izbornik;
                    break;
            }
            break;
        }
        //}

        Console.ReadLine();
        }
    }
}
