using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hianyzasok
{
    internal class Program
    {
        static List<Absence> data = Absence.LoadFromCsv("szeptember.csv", Encoding.Default).ToList();
        static void Main(string[] args)
        {
            //2. feladat
            Console.WriteLine($"2. feladat\n\tÖsszes mulasztott órák száma: {data.Sum(x=>x.MissedClasses)} óra.");

            //3. feladat
            Console.Write($"3. feladat\n\tKérem adjon meg egy napot: ");
            int day = int.Parse( Console.ReadLine() );
            Console.Write($"\tTanuló neve: ");
            string student = Console.ReadLine();

            //4. feladat
            if (data.Exists(x => x.Name == student)) Console.WriteLine($"4. feladat\n\tA tanuló hiányzott szeptemberben");
            else Console.WriteLine($"4. feladat\n\tA tanuló nem hiányzott szeptemberben");

            //5. feladat
            Console.WriteLine($"5. feladat: Hiányzók 2017.09.{day}-n:");
            bool isThere = false;
            foreach (var item in data)
            {
                if (day >= item.FirstDay && day <= item.LastDay) 
                { 
                    Console.WriteLine($"\t{item.Name} ({item.Class})");
                    isThere = true;
                }             
            }
            if (!isThere) Console.WriteLine("\tNem volt hiányzó");

            //6. feladat
            var statisztika = data.OrderBy(x => x.Class).GroupBy(x=>x.Class).Select(n => new { Class = n.Key, misses = n.Sum(y=>y.MissedClasses)});

            StreamWriter sw = new StreamWriter("osszesites.csv", false, Encoding.UTF8);
            foreach (var item in statisztika) sw.WriteLine($"{item.Class};{item.misses}");
            sw.Close();



            Console.ReadKey();
        }
    }
}
