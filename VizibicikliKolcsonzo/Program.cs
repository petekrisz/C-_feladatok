using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizibicikliKolcsonzo
{
    internal class Program
    {
        static List<Kolcsonzes> data = Kolcsonzes.LoadFromTxt("kolcsonzesek.txt", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {

            //5. feladat
            Console.WriteLine($"5. feladat: Napi kölcsönzesek száma: {data.Count}");

            //6. feladat
            Console.Write($"6. feladat: Kérek egy nevet: ");
            string queryName = Console.ReadLine();
            if (data.Exists(x => x.Nev == queryName))
            {
                Console.WriteLine($"\t{queryName} kölcsönzései:");
                foreach (Kolcsonzes item in data)
                {
                    if (item.Nev == queryName) Console.WriteLine($"\t{item.EOra:00}:{item.EPerc:00} - {item.VOra:00}:{item.VPerc:00}");
                }
            }
            else Console.WriteLine($"\t Nem volt ilyen nevű kölcsönző");

            //7. feladat

            Console.Write("7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            var time = Console.ReadLine().Split(':');
            int percben = int.Parse(time[0]) *60 + int.Parse(time[1]);
            Console.WriteLine($"\tA vízen lévő járművek {int.Parse(time[0])}:{int.Parse(time[1]):00}-kor:");
            foreach (var item in data)
            {
                if ( percben >= item.Epercben && percben <= item.Vpercben)
                {
                    Console.WriteLine(  $"\t{item.EOra:00}:{item.EPerc:00}-{item.VOra:00}:{item.VPerc:00} : {item.Nev}");
                }
            }

            //8. feladat
            int bevetel = 0;
            foreach (var item in data) 
            {
                int kezdet = item.Epercben;
                while (kezdet < item.Vpercben) 
                { 
                    bevetel +=2400;
                    kezdet += 30;
                }
            }

            Console.WriteLine($"8. feladat: A napi bevétel: {bevetel} Ft");

            //9. feladat
            StreamWriter sw = new StreamWriter("F.txt", false, Encoding.UTF8);
            var Fsuspect = data.Where(x => x.JAzon == "F");
            foreach (var item in Fsuspect) { sw.WriteLine($"{item.EOra:00}:{item.EPerc:00}-{item.VOra:00}:{item.VPerc:00} : {item.Nev}" ); }           
            sw.Close();

            //10.feladat

            var statisztika = data.GroupBy(x => x.JAzon).Select(n => new { JAzon = n.Key, db = n.Count() }).OrderBy(x => x.JAzon);
            Console.WriteLine("10. feladat: Statisztika: ");
            foreach (var item in statisztika) { Console.WriteLine($"\t{item.JAzon} - {item.db}"); }

            Console.ReadKey();
        }
    }
}
