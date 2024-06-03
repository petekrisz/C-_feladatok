using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vasmegye
{
    
    class PersonalID
    {
        public string gender;
        public int year;
        public int month;
        public int day; 

        public PersonalID (string line)
        {
            gender = line[0].ToString();
            if (int.Parse(line.Substring(2, 2)) > 90) { year = int.Parse(line.Substring(2, 2)) + 1900; } else { year = int.Parse(line.Substring(2, 2)) + 2000; }
            month = int.Parse(line.Substring(4, 2));
            day = int.Parse(line.Substring(6, 2));
        }
    }
    
    internal class Program
    {
        
        public static bool CdvEll(string id)
        {
            /*var temp = id.Split('-');
            id = temp[0] + temp[1] + temp[2];*/

            id = id.Replace("-", "");
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (10 - i) * int.Parse(id[i].ToString());
            }
            if (sum % 11 == int.Parse(id[10].ToString())) { return true; } else { return false; }
            
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("2. feladat: Adatok beolvasása, tárolása.");
            Console.WriteLine("4. feladat: Ellenőrzés");
            List<PersonalID> data = new List<PersonalID>();
            foreach (string line in File.ReadAllLines("vas.txt"))
            {                
                if (CdvEll(line)) {data.Add(new PersonalID(line));} else {Console.WriteLine($"\tHibás a {line} személyi azonosító!");}
            }

            // 5. feladat

            Console.WriteLine($"5. feladat: Vas megyében a vizsgált évek alatt {data.Count} csecsemő született.");

            //6. feladat

            int fiuk = 0;
            foreach (PersonalID item in data)
            {
                if (item.gender == "1" || item.gender == "3")
                {
                    fiuk++;
                }
            }
            Console.WriteLine($"6. feladat: Fiúk száma: {fiuk}");

            //Linq-kel
            Console.WriteLine($"6. feladat: Fiúk száma: {data.Count(x=>x.gender == "1" || x.gender == "3")}");

            //7. feladat

            Console.WriteLine($"7. feladat: Vizsgált időszak {data.Min(x => x.year)} - {data.Max(x => x.year)}");

            //8.feladat

            bool isThere = false; 
            foreach (var item in data)
            {
                if(item.year % 4 == 0 && item.month == 2 && item.day == 24)
                {
                    isThere = true;
                    break;
                }

            }
            if (isThere) { Console.WriteLine($"8. feladat: Szökőnapon született baba!"); } else { Console.WriteLine($"8. feladat: Szökőnapon nem született baba!"); }
                      
            //linq-kel

            if(data.Count(x => x.year%4 == 0 && x.month == 2 && x.day == 24)>0) { Console.WriteLine($"8. feladat: Szökőnapon született baba!"); } else { Console.WriteLine($"8. feladat: Szökőnapon nem született baba!"); }

            //9. feladat

            //linq-kel

            var statisztika = data.GroupBy(x => x.year).Select(n => new { year = n.Key, db = n.Count()});

            Console.WriteLine($"9. feladat: Statisztika");
            foreach (var item in statisztika)
            {
                Console.WriteLine($"\t{item.year} - {item.db} fő");
            }
            
            
            // dictionary-vel
            
            Dictionary<int, int> statistic = new Dictionary<int, int>();
            foreach (var item in data)
            {
                if (!statistic.ContainsKey(item.year))
                {
                    statistic.Add(item.year, 1);
                }
                else
                {
                    statistic[item.year]++;
                }
            }

            Console.WriteLine($"9. feladat: Statisztika - 2. módszer");
            foreach (var item in statistic)
            {
                if (item.Value > 20)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value} fő");
                }
            }

            List<int> evek = new List<int>();
            for (int i=data.Min(x=>x.year); i<=data.Max(x=>x.year); i++)
            {
                evek.Add(i);
            }

            Console.WriteLine($"9. feladat: Statisztika - 3. módszer");
            foreach (var item in evek)
            {
                Console.WriteLine($"\t{item} - {data.Count(x=>x.year == item)} fő");
            }






            Console.ReadKey();
        }

        
    }
}
