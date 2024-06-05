using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;

namespace Helsink2017
{
    public class Program
    {
        static List<Korcsolya> shortProgram = Korcsolya.LoadFromCsv("rovidprogram.csv", Encoding.UTF8).ToList();
        static List<Korcsolya> final = Korcsolya.LoadFromCsv("donto.csv", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {



            //2. feladat
            Console.WriteLine($"2. feladat\n\tA rövidprogramban {shortProgram.Count} induló volt.");

            //3. feladat
            if (final.Exists(x=>x.Country == "HUN")) Console.WriteLine("3. feladat\n\tA magyar versenyző bejutott a kűrbe.");
            else Console.WriteLine("3. feladat\n\tA magyar versenyző nem jutott be a kűrbe.");

            //5. feladat
            Console.Write("5. feladat\n\tKérem a versenyző nevét: "  );
            string nev = Console.ReadLine();
            //6. feladat
            if (shortProgram.Exists(x=>x.Name == nev)) Console.WriteLine($"6. feladat\n\tA versenyző összpontszáma: {TotalPoints(nev)}");
            else Console.WriteLine("\tIlyen nevű induló nem volt!");

            //7. feladat
            var statistic = final.GroupBy(x => x.Country).Select(n => new { country = n.Key, db = n.Count() });
            Console.WriteLine("7. feladat");
            foreach (var item in statistic.Where(x=>x.db>1))
            {
                Console.WriteLine($"\t{item.country}: {item.db} versenyző");
            }

            //8. feladat
            int rank = 1;
            StreamWriter sw=new StreamWriter("vegeredmeny.csv", false, Encoding.UTF8);
            foreach(var item in shortProgram.OrderByDescending(x => TotalPoints(x.Name))) 
            {
                sw.WriteLine($"{rank}; {item.Name}; {item.Country}; {TotalPoints(item.Name)}");
                rank++;
            }
            sw.Close();





            Console.ReadKey();
        }

        private static double TotalPoints(string name)
        {
            double total = 0;
            Korcsolya person = shortProgram.Where(x => x.Name == name).FirstOrDefault();
            if (final.Exists(x => x.Name == person.Name)) total += final.Where(x => x.Name == person.Name).Select(x => x.Technical+x.Component-x.Minus).Sum();
            total += person.Technical + person.Component - person.Minus;
            return total;

        }
    }
}
