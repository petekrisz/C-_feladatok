using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EU
{
    internal class Program
    {
        
        static List<EU> data = EU.LoadFromTxt("EUcsatlakozas.txt", Encoding.Default).ToList();




        static void Main(string[] args)
        {

            

            //3. feladat

            Console.WriteLine($"3. feladat: Az EU tagállamainak száma: {data.Count} db");

            //4. feladat

            int join2007 = 0;
            foreach (EU e in data)
            {
                if (e.Join.Year == 2007)
                {
                    join2007++;
                }
            }

            Console.WriteLine($"4. feladat: 2007-ben {join2007} ország csatlakozott.");

            //4. feladat eljárással

            Joined2007();

            //4. feladat függvénnyel

            Console.WriteLine($"4. feladat: 2007-ben {StatesJoined2007()} ország csatlakozott.");

            //5. feladat

            foreach (EU e in data)
            {
                if (e.State == "Magyarország")
                {
                    Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma {e.Join: yyyy.MM.dd}");
                    
                }
            }

            //5. feladat eljárással

            HungaryJoinDate();


            //6. feladat

            mayJoined();

            //7. feladat

            lastJoined();

            var last = data.OrderByDescending(item => item.Join).First();


            Console.WriteLine($"7.feladat: Az utoljára csatlakozott ország: {last.State}.");


            //8. feladat
            Console.WriteLine("8. feladat: Statisztika");
            statistic();


            Console.ReadKey();
        }

        private static void statistic()
        {
            Dictionary<int, int> yearOfJoining = new Dictionary<int, int>();
            foreach (var item in data)
            {
                if (!yearOfJoining.ContainsKey(item.Join.Year))
                {
                    yearOfJoining.Add(item.Join.Year, 1);
                }
                else
                {
                    yearOfJoining[item.Join.Year]++;
                }
            }
            foreach (var item in yearOfJoining)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }

        private static void lastJoined()
        {
            for (int i = 0; i < data.Count-1; i++)
            {
                for (int j = i; j < data.Count; j++)
                {
                    if (data[i].Join > data[j].Join)
                    {
                        EU temp = data[i];
                        data[i] = data[j]; 
                        data[j] = temp; 
                    }
                }
            }
            Console.WriteLine($"7. feladat: Az utoljára csatlakozott ország: {data.Last().State}.");
        }

        private static void mayJoined()
        {
            bool isJoined = false;
            foreach(EU e in data)
            {
                if (e.Join.Month == 5)
                {
                    Console.WriteLine($"6. feladat: Volt májusban csatlakozás.");
                    isJoined = true;
                    break;
                }
                
            }
            if (!isJoined) Console.WriteLine($"6. feladat: Nem volt májusban csatlakozás.");
        }

        private static void HungaryJoinDate()
        {
            foreach (EU e in data)
            {
                if (e.State == "Magyarország")
                {
                    Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma {e.Join: yyyy.MM.dd}");

                }
            }
        }

        // Method készítése a MAIN-en kívül, de a CLASS-on belül

        static void Joined2007()
        {
            int counter = 0;
            foreach (var item in data)
            {
                if (item.Join.Year == 2007)
                {
                    counter++;
                }
            }
            Console.WriteLine($"4. feladat: 2007-ben {counter} ország csatlakozott.");

        }

        //Függvénnyel

        static int StatesJoined2007()
        {
            int counter = 0;
            foreach (var item in data)
            {
                if (item.Join.Year == 2007)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
