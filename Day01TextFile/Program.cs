using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Day01TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            string[] username3 = {username,username, username};

            System.IO.File.WriteAllText("C:\\Users\\shift\\Documents\\GitHub\\AppDev\\ApplicationDevelopment\\Day01TextFile\\WriteLines1.txt", username);
            System.IO.File.WriteAllLines("C:\\Users\\shift\\Documents\\GitHub\\AppDev\\ApplicationDevelopment\\Day01TextFile\\WriteLines2.txt", username3);
            string shift = System.IO.File.ReadAllText("C:\\Users\\shift\\Documents\\GitHub\\AppDev\\ApplicationDevelopment\\Day01TextFile\\WriteLines2.txt");
            Console.WriteLine(shift);
            Console.ReadKey();
        }
    }
}
