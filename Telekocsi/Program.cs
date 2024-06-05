using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Telekocsi
{
    public class Program
    {
        static List<Offers> cars= Offers.LoadFromCsv("autok.csv", Encoding.Default).ToList();
        static List<Demands> travels = Demands.LoadFromCsv("igenyek.csv", Encoding.Default).ToList();

        static void Main(string[] args)
        {
            //2. feladat
            Console.WriteLine($"2. feladat\n\t{cars.Count} autós hirdet fuvart.");


            //3. feladat
            Console.WriteLine($"3. feladat\n\tÖsszesen {cars.Where(x => x.Start == "Budapest" && x.End == "Miskolc").Select(x => x.Places).Sum()} férőhelyet hirdettek az autósok Budapestről Miskolcra.");

            //4. feladat - Linq
            var mostOffers = cars.GroupBy(x => new { x.Start, x.End }).Select(r => new { route = r.Key, TPlaces = r.Sum(x => x.Places) }).OrderByDescending(r => r.TPlaces).First();
            Console.WriteLine($"4. feladat\n\t A legtöbb helyet ({mostOffers.TPlaces}-t) a(z) {mostOffers.route.Start}-{mostOffers.route.End} útvonalon ajánlották fel a hirdetők");

            //4. feladat - for ciklussal

            int maxPlaces = 0;
            string start = "";
            string end = "";
            for (int i = 0; i < cars.Count; i++)
            {
                int temp = cars[i].Places;
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[j].Start == cars[i].Start && cars[j].End == cars[i].End) temp += cars[j].Places;
                }
                if (temp > maxPlaces)
                {
                    maxPlaces = temp;
                    start = cars[i].Start;
                    end = cars[i].End;
                }
            }
            Console.WriteLine($"4. feladat\n\t A legtöbb helyet ({maxPlaces}-t) a(z) {start}-{end} útvonalon ajánlották fel a hirdetők");


            //5. feladat + (6. első fele)
            Console.WriteLine("5. feladat");

            List<Demands> Wtravels = new List<Demands>();
            foreach (var t in travels) {Wtravels.Add(t); }
            List<Offers> Wcars = new List<Offers>();
            foreach (var c in cars) { Wcars.Add(c); }

            foreach (var t in Wtravels)
            {
                bool done=false;
                foreach (var c in Wcars)
                {
                    if (c.Start == t.Start && c.End == t.End && !done) 
                    {
                        if (c.Places > t.Places)
                        {
                            c.Places -= t.Places;
                            t.Message = $"{t.ID}: Rendszám: {c.LPlate}, Telefonszám: {c.Phone}";
                            done = true;
                            Console.WriteLine($"\t{t.ID} => {c.LPlate}");
                        }
                        
                    }
                }
                if (!done) t.Message = $"{t.ID}: Sajnos nem sikerült autót találni";
            }

            //6. feladat

            StreamWriter sw = new StreamWriter("utasuzenetek.txt", false, Encoding.UTF8);
            foreach (var t in Wtravels) sw.WriteLine(t.Message);
            sw.Close(); 



            Console.ReadKey();
        }
    }
}
