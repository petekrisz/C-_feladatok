using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace HegyekMo
{
    internal class Program
    {
        static List<Hegyek> data = Hegyek.LoadFromTxt("hegyekMo.txt", Encoding.Default).ToList();

        static void Main(string[] args)
        {
            //3. feladat
            Console.WriteLine($"3. feladat: Hegycsúcsok száma {data.Count} db");

            //4. feladat
            Console.WriteLine($"4. feladat: Hegycsúcsok átlagos magassága: {(double)data.Average(x => x.Height): .##} db");

            //5. feladat
            var heighest = data.OrderByDescending(x=>x.Height).First();
            Console.WriteLine($"6. feladat: A legmagasabb hegycsúcs adatai:\n\tNév: {heighest.Peak}\n\tHegység: {heighest.Mountain}\n\tMagasság: {heighest.Height} m");

            //6.feladat
            Console.Write("6. feladat: Kérek egy magasságot: ");
            int mag = int.Parse(Console.ReadLine());

            if (data.Exists(x => x.Mountain == "Börzsöny" && x.Height > mag)) Console.WriteLine($"\tVan {mag}m-nél magasabb hegycsúcs a Börzsönyben!");
            else Console.WriteLine($"\tNincs {mag}m-nél magasabb hegycsúcs a Börzsönyben!");

            //7. feladat
            Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {data.Count(x=>x.HeightFeet>3000)}");

            //8. feladat

            var statisztika = data.GroupBy(x => x.Mountain).Select(n => new { Mountain = n.Key, db = n.Count() });
            Console.WriteLine("8. feladat: Hegység statisztika:");
            foreach (var item in statisztika)
            {
                Console.WriteLine($"\t{item.Mountain} - {item.db} db");
            }
            //9. feladat

            Console.WriteLine("9. feladat: bukk-videk.txt");

            StreamWriter sw = new StreamWriter("bukk-videk.txt");
            sw.WriteLine("Hegycsúcs neve; Magasság láb");
            foreach (var item in data)
            {
                sw.WriteLine($"{item.Peak}; {Math.Round(item.HeightFeet,1).ToString().Replace(",",".")}");
            }
            sw.Close();
            

            Console.ReadKey();    
        }
    }
}
