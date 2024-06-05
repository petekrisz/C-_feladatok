using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    public class Program
    {
        static List<Prize> data=Prize.LoadFromCsv("nobel.csv", Encoding.Default).ToList();
        static void Main(string[] args)
        {
            //3. feladat
            Console.WriteLine($"3. feladat: {data.Where(x=>x.LastName == "McDonald" && x.FirstName == "Arthur B.").Select(x=>x.Type).FirstOrDefault()}");

            //4. feladat
            var lit2017 = data.Where(x => x.Year == 2017 && x.Type == "irodalmi").ToList();                      
            Console.Write($"4. feladat: ");
            foreach( var x in lit2017 ) {  Console.Write($"{x.FirstName} {x.LastName}\t "); }

                //Ha feltételezem, hogy csak 1 van:
                Console.WriteLine($"\n4. feladat: {data.Where(x => x.Year == 2017 && x.Type == "irodalmi").Select(x=>x.FirstName).FirstOrDefault()} {data.Where(x => x.Year == 2017 && x.Type == "irodalmi").Select(x => x.LastName).FirstOrDefault()}");

            //5. feladat
            var organizations = data.Where(x => x.LastName == "" && x.Year>=1990).ToList();
            Console.WriteLine($"5. feladat: ");
            foreach (var x in organizations) { Console.WriteLine($"\t{x.Year}: {x.FirstName}"); }

            //6. feladat
            var Curie = data.Where(x => x.LastName.Contains("Curie")).ToList();
            Console.WriteLine($"6. feladat: ");
            foreach (var x in Curie) { Console.WriteLine($"\t{x.Year}: {x.FirstName} {x.LastName} ({x.Type})"); }

            //7. feladat

            var statistics = data.GroupBy(x => x.Type).Select(n => new { Type = n.Key, db = n.Count() });
            Console.WriteLine("7. feladat:");
            foreach(var item in statistics) Console.WriteLine($"\t{item.Type,-30}{item.db,3} db");

            //8. feladat
            Console.WriteLine("8. feladat: orvosi.txt");
            StreamWriter sw = new StreamWriter("orvosi.txt", false, Encoding.UTF8);
            var med = data.Where(x => x.Type == "orvosi").OrderBy(x=>x.Year).ToList();
            foreach (var item in med) { sw.WriteLine($"{item.Year}:{item.FirstName} {item.LastName}"); }
            sw.Close();



            Console.ReadKey();
        }
    }
}
