using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            string fileName = "D:\\BEKEND\\MonoElprosCsharp\\17-3\\test123\\abc.txt";

            if (!File.Exists(fileName)) 
            {
                File.Create(fileName);
            }

            Console.Read();
        }
    }
}
