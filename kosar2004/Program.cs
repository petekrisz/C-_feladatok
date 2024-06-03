using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004
{
    internal class Program
    {
        static List<ACB_Liga> data = ACB_Liga.LoadFromCsv("eredmenyek.csv", Encoding.Default).ToList();

        static void Main(string[] args)
        {
            //3. feladat

            // with method realmadrid();

            int hdb = 0, idb = 0;
            foreach (var item in data)
            {
                if(item.hazai == "Real Madrid")
                {
                    hdb++;
                }
                else if (item.idegen == "Real Madrid")
                {
                    idb++;
                }
            }

            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {hdb} Idegen: {idb}");

            //4. feladat


            bool draw=false;    
            foreach (var item in data)
            {
                if (item.hazai_pont == item.idegen_pont)
                {
                    draw=true;
                    break;
                }
            }

            if (draw) { Console.WriteLine($"4. feladat: Volt döntetlen? igen"); }
            else { Console.WriteLine($"4. feladat: Volt döntetlen? nem"); }

            /*fügvénnyel
            
            string valasz = voltdontetlen() ? "4. feladat: Volt döntetlen? igen" : "4. feladat: Volt döntetlen? nem";
            Console.WriteLine(valasz);*/

            //5. feladat
            string Barca = "";
            foreach (var item in data)
            {
                if (item.hazai.Contains("Barcelona"))
                {
                    Barca= item.hazai;
                    break;
                }
            }
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {Barca}");

            /* függvénnyel

            Console.WriteLine($"5. feladat: barcelonai csapat neve: {barcaTeljesNeve()}"); ;*/

            //6. feladat

            Console.WriteLine("6. feladat");

         
            foreach (var item in data)
            {
                if(item.idopont == "2004-11-21")
                {
                    Console.WriteLine($"\t{item.hazai} - {item.idegen} ({item.hazai_pont}:{item.idegen_pont})");
                }
            }

            //7. feladat


            Console.WriteLine("7. feladat");
            statistic();





            Console.ReadKey();
        }

        /*private static string barcaTeljesNeve()
        {
            string nev = "";
            foreach (var item in data)
            {
                if (item.hazai.Contains("Barcelona"))
                {
                    nev = item.hazai;
                    break;
                }
            }
            return nev;
        }*/

        /*private static bool voltdontetlen()
        {
            bool dontetlen = false;
            foreach (var item in data)
            {
                if (item.hazai_pont == item.idegen_pont)
                {
                    dontetlen = true;
                    
                }
            }
            return dontetlen;
        }*/

        private static void statistic()
        {
            Dictionary<string, int> stadion = new Dictionary<string, int>();
            foreach (var item in data)
            {
                if (!stadion.ContainsKey(item.helyszin))
                {
                    stadion.Add(item.helyszin, 1);
                }
                else
                {
                    stadion[item.helyszin]++;
                }
            }
            foreach (var item in stadion)
            {
                if (item.Value > 20)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Value}");
                }               
            }
        }

        /*private static void realmadrid()
        {
            int hdb = 0, idb = 0;
            foreach (var item in data)
            {
                if (item.hazai == "Real Madrid")
                {
                    hdb++;
                }
                else if (item.idegen == "Real Madrid")
                {
                    idb++;
                }
            }

            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {hdb} Idegen: {idb}");
        }*/



    }
}

