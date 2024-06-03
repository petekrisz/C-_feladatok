using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vb2018
{
    public class Program
    {
        static List<VB2018> data = VB2018.LoadFromTxt("vb2018.txt", Encoding.Default).ToList();
        static void Main(string[] args)
        {
            //3. fealadat
            Console.WriteLine($"3. feladat: Stadionok száma: {data.Count}");

            //4. feladat
            var smallest = data.OrderBy(x => x.Capacity).First();
            Console.WriteLine($"4. feladat: A legkevesebb férőhely:\n\tVáros: {smallest.City}\n\tStadion neve: {smallest.Stadion}\n\tFérőhely: {smallest.Capacity}");

            //5. feladat
            Console.WriteLine($"5. feladat: Átlagos férőhelyszám: {data.Average(x=>x.Capacity): .#}");

            //6. feladat
            Console.WriteLine($"6. feladat: A két néven is ismert stadionok száma: {data.Where(x => x.Alias != "n.a.").Count()}");

            //7. feladat
            string cityQuery = "";
            do
            {
                Console.Write("7. feladat: Kérem a város nevét: ");
                cityQuery = Console.ReadLine().ToLower();
            } while (cityQuery.Length < 3);

            //8. feladat
            if (data.Exists(x => x.City.ToLower() == cityQuery)) Console.WriteLine("8. feladat: A megadott város VB helyszín.");
            else Console.WriteLine("8. feladat: A megadott város nem VB helyszín.");

            //9. feladat
            Console.WriteLine($"9. feladat: {data.GroupBy(x => x.City).Count()} különböző városban voltak mérkőzések.");


            Console.ReadKey();
        }
    }
}
