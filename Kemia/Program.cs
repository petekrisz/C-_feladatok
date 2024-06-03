using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Kemia
{
    internal class Program
    {
        static List<Elemek> data = Elemek.LoadFromCsv("felfedezesek3.csv", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {

            //3. feladat
            Console.WriteLine($"3. feladat: Elemek száma: {data.Count}");

            //4. feladat

            Console.WriteLine($"4. feladat: Felfedezések száma az ókorban: {data.Count(x => x.Year == "Ókor")}");

            //5. fealdat

            char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            bool ok = false;
            string query;

            do
            {
                Console.Write("5. feladat: Kérek egy vegyjelet: ");
                query = Console.ReadLine();
                string temp = query.ToUpper();
                if (temp.Length == 1 && abc.Contains(temp[0])) { ok = true; }
                else if (temp.Length == 2 && abc.Contains(temp[0]) && abc.Contains(temp[1])) { ok = true; }
            }
            while (!ok);


            //Linq-kel

            var elem = (from sor in data where sor.Symbol.ToUpper() == query.ToUpper() select sor);
            Console.WriteLine($"6. feladat: Keresés");
            if (elem.Any())
            {
                var x = elem.First();
                Console.WriteLine($"\tAz elem vegyjele: {x.Symbol}\n\tAz elem neve: {x.Name}\n\tRendszáma: {x.AtomicNum}\n\tFelfedezés éve: {x.Year}\n\tFelfedező: {x.Discoverer}");
            }
            else { Console.WriteLine($"\tNincs ilyen elem az adatforrásban!"); }

            //Foreach-csel

            ok = false;
            Console.WriteLine($"6. feladat: Keresés - foreach-csel");
            foreach (var item in data)
            {
                if (item.Symbol.ToUpper() == query.ToUpper())
                {
                    Console.WriteLine($"\tAz elem vegyjele: {item.Symbol}\n\tAz elem neve: {item.Name}\n\tRendszáma: {item.AtomicNum}\n\tFelfedezés éve: {item.Year}\n\tFelfedező: {item.Discoverer}");
                    ok = true;
                    break;

                }
            }
            if (!ok) { Console.WriteLine($"\tNincs ilyen elem az adatforrásban!"); }

            //7. feladat

            List<Elemek> dataOrdered = data.OrderBy(x => x.YearOfDisc).ToList();
            dataOrdered.RemoveAll(x => x.YearOfDisc == 0);

            int difference = 0;
            for (int i = 1; i < dataOrdered.Count - 1; i++)
            {
                if (dataOrdered[i].YearOfDisc - dataOrdered[i - 1].YearOfDisc > difference) { difference = dataOrdered[i].YearOfDisc - dataOrdered[i - 1].YearOfDisc; }
            }

            Console.WriteLine($"7. feladat: {difference} év solt a leghosszabb időszak két elem felfedezése között.");

            //8. feladat

            Console.WriteLine($"8. feladat: Statisztika - GroupBy");
            var statisztika = dataOrdered.GroupBy(x => x.Year).Select(n => new { év = n.Key, db = n.Count() });
            foreach (var e in statisztika)
            {
                if (e.db > 3) { Console.WriteLine($"\t{e.év} - {e.db} db"); }
            }

            Console.WriteLine($"8. feladat: Statisztika - Dictionary");

            Dictionary<int, int> Years = new Dictionary<int, int>();
            foreach (var item in dataOrdered)
            {
                if (!Years.ContainsKey(item.YearOfDisc)) { Years.Add(item.YearOfDisc, 1); }
                else { Years[item.YearOfDisc]++; }
            }

            foreach (var item in Years) 
            { 
                if (item.Value > 3) { Console.WriteLine($"\t{item.Key} - {item.Value} db"); }
            }



            Console.ReadKey();
        }

        
    }
}
