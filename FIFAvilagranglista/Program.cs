using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FIFAvilagranglista
{

    class FIFA
    {
        public string Team;
        public int Rank;
        public int Change;
        public int Points;

        public FIFA(string line)
        {
            var temp = line.Split(';');
            Team = temp[0];
            Rank = int.Parse(temp[1]);
            Change = int.Parse(temp[2]);
            Points = int.Parse(temp[3]);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FIFA> data = new List<FIFA>();
            var sr = new StreamReader("fifa.txt", Encoding.Default);
            string elso = sr.ReadLine();
            while (!sr.EndOfStream) { data.Add(new FIFA(sr.ReadLine())); }
            sr.Close();

            Console.WriteLine($"3. feladat: A világranglistán {data.Count} csapat szerepel");
            
            
            //4. feladat - Linq
            Console.WriteLine($"4. feladat: A csapatok átlagos pontszáma: {(double)data.Average(x=>x.Points):.##} pont");

            //4. feladat - foreach

            double sum = 0;
            foreach (var item in data)
            {
                sum += item.Points;
            }
            Console.WriteLine($"4. feladat: A csapatok átlagos pontszáma: {sum/(double)data.Count:.##} pont");

            //5. feladat - Linq
            FIFA mostImproved = data.First(x=>x.Change == Math.Abs(data.Max(y=>y.Change)));
            Console.WriteLine($"5. feladat: A legtöbbet javító csapat:\n\tHelyezes: {mostImproved.Rank}\n\tCsapat: {mostImproved.Team}\n\tPontszám: {mostImproved.Points}");

            //5. feladat - foreach

            int max = 0;
            foreach (var item in data)
            {
                if (Math.Abs(item.Change) > max) { max = item.Change; }
            }
            foreach (var item in data)
            {
                if (item.Change == max) { Console.WriteLine($"5. feladat: A legtöbbet javító csapat:\n\tHelyezes: {item.Rank}\n\tCsapat: {item.Team}\n\tPontszám: {item.Points}"); }
            }

            
            //6. feladat - foreach
            bool isThere = false;
            foreach (var item in data)
            {
                if (item.Team == "Magyarorszag") 
                { 
                    isThere=true;
                    break;
                }
            }
            if ( isThere ) { Console.WriteLine("6. feladat: A csapatok között van Magyarország."); }
            else { Console.WriteLine("6. feladat: A csapatok között nincs Magyarország."); }

            
            //6. feladat - Linq
            if (data.Exists(x=>x.Team == "Magyarország")) { Console.WriteLine("6. feladat: A csapatok között van Magyarország."); }
            else { Console.WriteLine("6. feladat: A csapatok között nincs Magyarország."); }


            //7. feladat - Linq

            var statisztika = data.GroupBy(x => x.Change).Select(n => new { Change = n.Key, db = n.Count() });

            Console.WriteLine($"7. feladat: Statisztika");
            foreach (var item in statisztika)
            {
                if (item.db > 1)
                {
                    Console.WriteLine($"\t{item.Change,3} helyet változtatott: {item.db} cscapat");
                }
                
            }


            // 7. feladat - Dictionary

            Dictionary<int, int> statistic = new Dictionary<int, int>();
            foreach (var item in data)
            {
                if (!statistic.ContainsKey(item.Change))
                {
                    statistic.Add(item.Change, 1);
                }
                else
                {
                    statistic[item.Change]++;
                }
            }

            Console.WriteLine($"9. feladat: Statisztika - 2. módszer");
            foreach (var item in statistic)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine($"\t{item.Key,3} helyet változtatott: {item.Value} csapat");
                }
            }

           










            Console.ReadKey();
        }
    }
}
