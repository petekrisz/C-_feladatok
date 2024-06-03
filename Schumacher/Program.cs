using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Schumacher
{
    internal class Program
    {
        static List<SchRaces> data = SchRaces.LoadFromCsv("schumacher.csv", Encoding.Default).ToList();

        static void Main(string[] args)
        {
            //3. feladat
            Console.WriteLine($"3. feladat: {data.Count}");

            //4. feladat
                //Linq
            Console.WriteLine($"4. feladat: Magyar Nagydíj helyezései - Linq");
            var hungary = data.Where(x => x.Grandprix == "Hungarian Grand Prix" && (x.Position >0));
            foreach (var item in hungary) { Console.WriteLine($"\t{item.Date}: {item.Position,4}. hely"); }

                //foreach
            Console.WriteLine($"4. feladat: Magyar Nagydíj helyezései - foreach");
            foreach (var item in data)
            {
                if (item.Grandprix == "Hungarian Grand Prix" && (item.Position > 0)) Console.WriteLine($"\t{item.Date}: {item.Position,4}. hely");
            }



            //5. feladat

                //Linq-kel
            var statisztika = data.Where(x=>x.Status != "Finished" && !x.Status.Contains("Lap") && x.Position == 0).GroupBy(x=>x.Status).Select(n => new { stat = n.Key, db = n.Count() });

            Console.WriteLine($"5. feladat: Hibastatisztika - Linq"); 
            foreach (var item in statisztika) 
            { 
                if (item.db >2) Console.WriteLine($"\t{item.stat}: {item.db}"); 
            }
                
                //Dictionary-vel
            Dictionary<string, int> statistic = new Dictionary<string, int>();
            foreach (var item in data)
            {
                if ((item.Status != "Finished" && !item.Status.Contains("Lap") && item.Position == 0))
                {
                    if (!statistic.ContainsKey(item.Status)) statistic.Add(item.Status, 1);                
                    else statistic[item.Status]++;
                }
            }
           
            Console.WriteLine($"5. feladat: Hibastatisztika - Dictionary");
            foreach (var item in statistic)
            {
                if (item.Value > 2) Console.WriteLine($"\t{item.Key}: {item.Value}");
            }



            Console.ReadKey();
        }
    }
}
