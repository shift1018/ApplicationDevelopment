using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Day01TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try { 
            //Console.WriteLine("Enter username:");
            //string username = Console.ReadLine();
            //string[] username3 = { username, username, username };

            //System.IO.File.WriteAllText("C:\\Users\\shift\\Documents\\GitHub\\AppDev\\ApplicationDevelopment\\Day01TextFile\\WriteLines1.txt", username);
            //System.IO.File.WriteAllLines("C:\\Users\\shift\\Documents\\GitHub\\AppDev\\ApplicationDevelopment\\Day01TextFile\\WriteLines2.txt", username3);
            //string shift = System.IO.File.ReadAllText("C:\\Users\\shift\\Documents\\GitHub\\AppDev\\ApplicationDevelopment\\Day01TextFile\\WriteLines2.txt");
            //Console.WriteLine(shift);
            //Console.ReadKey();

            const string filePath = @"C:\Users\shift\Documents\GitHub\AppDev\ApplicationDevelopment\Day01TextFile\WriteLines1.txt";

            Console.WriteLine("what is your name");
            string name = Console.ReadLine();

            try
            {

            
                {
                    string[] namesArray = { name, name, name }; 
                }
                {
                    string filecontents = $"{name}\n{name}\n{name}\n";
                    File.WriteAllText(filePath, filecontents);
                }
            }
            catch(SystemException ex) {
                Console.WriteLine("Error write to file: " + ex.Message);
            }
            try
            {
                    {
                        string[] linesArray = File.ReadAllLines(filePath);
                        foreach(String line in linesArray)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    {
                        string allContent = File.ReadAllText(filePath);
                        Console.WriteLine(allContent);
                    }

            }
            catch(SystemException ex)
                {
                    Console.WriteLine("Error writing to file: " + ex.Message);
                }




                } finally{
                    Console.WriteLine("press any key to finish");
                    Console.ReadKey();
                }
        }
    }
}
