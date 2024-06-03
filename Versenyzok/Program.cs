using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Versenyzok
{
   
    internal class Program
    {
        static List<Pilots> data = Pilots.LoadFromCsv("pilotak.csv", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {  
            Console.WriteLine($"3. feladat: {data.Count}");
            Console.WriteLine($"4. feladat: {data.Select(x => x.Name).Last()}");
            Console.WriteLine("5. feladat:");
            DateTime szford = new DateTime(1901,1,1);
            var multsz = data.Where(x => x.BirthDate < szford);
            foreach ( var item in multsz ) { Console.WriteLine($"\t{item.Name} ({item.BirthDate:yyyy. MM. dd.})"); }
            Console.WriteLine($"6. feladat: {data.Where(r=>r.Number >0).OrderBy(x => x.Number).Select(y=>y.Nationality).First()}");
            var statisztika = data.GroupBy(x => x.Number).Select(n => new { Number = n.Key, db = n.Count() });
            Console.Write($"7. feladat: ");
            List<int> polenumbers = new List<int>();
            foreach ( var item in statisztika) 
            { 
                if (item.db > 1 && item.Number !=0) polenumbers.Add(item.Number);
            }
            for ( int i = 0; i < polenumbers.Count-1; i++ )
            {
                Console.Write($"{polenumbers[i]}, ");
            }
            Console.Write($"{polenumbers[polenumbers.Count-1]}");








            Console.ReadKey();
        }
    }
}
