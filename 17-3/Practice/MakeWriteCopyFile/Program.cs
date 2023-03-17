using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;

namespace MakeWriteCopyFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = $"D:\\BEKEND\\MonoElprosCsharp\\17-3\\test123";

            if (!Directory.Exists(directoryPath)) // default je ako vrijedi znaci true, pa napravi; sa ! znaci ako NIJE da vrijedi Exists onda napravi
            {
                Directory.CreateDirectory(directoryPath);            
            }

            string filePath = "D:\\BEKEND\\MonoElprosCsharp\\17-3\\test123\\abc.txt";

            if (!File.Exists(filePath)) 
            {
                FileStream stream = File.Create(filePath);
                stream.Flush();
                stream.Close();
            }


            ///// tu mi je napravio folder i prazan file *\test123\abc.txt

            File.WriteAllText(filePath, "Hello World!"); // napisao je u fajlu Hello World

            string tekst = File.ReadAllText(filePath);
            Console.WriteLine(tekst); // napisao u konzoli, za sad sve oke

            //////////////////

            string filePath2 = "D:\\BEKEND\\MonoElprosCsharp\\17-3\\test123\\abc2.txt";

            if (!File.Exists(filePath2))
            {
                FileStream stream = File.Create(filePath2);
                stream.Flush();
                stream.Close();
            }
            
            FileStream startStream = File.OpenRead(filePath);
            FileStream endStream = File.OpenWrite(filePath2);
            startStream.CopyTo(endStream); ///// u napravljenom fajlu abc2.txt se sada nalazi Hello World!



            Console.Read();
        }
    }
}
