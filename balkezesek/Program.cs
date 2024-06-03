using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace balkezesek
{
    internal class Program
    {
        static List<Balkezesek> data= Balkezesek.LoadFromCsv("balkezesek.csv", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {
            //3. feladat
            Console.WriteLine($"3. feladat: {data.Count}");

            //4. feladat
            Console.WriteLine("4. feladat:");
            var Oktober99 = data.Where(x => x.LastDay < DateTime.Parse("1999.11.01") && x.LastDay >= DateTime.Parse("1999.10.01"));
            foreach(var x in Oktober99) {  Console.WriteLine($"\t{x.Name}, {(double)x.HeightInch*2.54: .0}"); }

            //5. feladat
            Console.WriteLine("5. feladat:");
            int inputYear = 0;
            while (inputYear <1990 || inputYear > 1999)
            {
                Console.Write("Kerek egy 1990 és 1999 közötti évszámot: ");
                inputYear = int.Parse(Console.ReadLine());
                if (inputYear >=1990 && inputYear <= 1999) break;
                else Console.Write("Hibás adat!");
            }

            //6.feladat
            Console.WriteLine($"6. feladat {data.Where(y => y.FirstDay.Year <= inputYear && y.LastDay.Year >= inputYear).Average(x=>x.WeightPound): .00} font");














            Console.ReadKey();
        }
    }
}
