using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    public class Program
    {
        static List<DogNames> names=DogNames.LoadFromCsv("KutyaNevek.csv", Encoding.Default).ToList();
        static List<DogSpec> species = DogSpec.LoadFromCsv("KutyaFajtak.csv", Encoding.Default).ToList();
        static List<Examinations> examination = Examinations.LoadFromCsv("Kutyak.csv", Encoding.Default).ToList();

        static void Main(string[] args)
        {
            //3. feladat
            Console.WriteLine($"3. feladat: Kutyanevek száma: {names.Count}");

            //6. feladat
            Console.WriteLine($"6. feladat: Kutyák átlag életkora: {examination.Average(x=>x.Age): .##}");

            //7. feladat
            var oldest = examination.OrderByDescending(x => x.Age).First();
            Console.WriteLine($"7. feladat: A legidősebb kutya neve és fajtája: {names.Where(x=>x.NameId == oldest.NameId).Select(x=>x.Name).First()}, {species.Where(x => x.SpecId == oldest.SpecId).Select(x => x.Name).First()}");

            //8. feladat
            var examStat = examination.Where(x=>x.LastExam == "2018.01.10").GroupBy(x => x.SpecId).Select(n => new {fajta_id = n.Key, db =n.Count() });
            Console.WriteLine("8. feladat: Január 10.-án vizsgált kutyafajták:");
            foreach(var item in examStat) { Console.WriteLine($"\t{species.Where(x=>x.SpecId == item.fajta_id).Select(x=>x.Name).First()}: {item.db} kutya"  ); }

            //9. feladat
            var loadStat = examination.GroupBy(x => x.LastExam).Select(n => new { date = n.Key, db = n.Count() });
            Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {loadStat.OrderByDescending(x=>x.db).Select(x=>x.date).FirstOrDefault()}.: {loadStat.OrderByDescending(x => x.db).Select(x => x.db).FirstOrDefault()} kutya");

            //10. feladat
            Console.WriteLine("10. feladat: Nevstatisztika.txt");
            var nameStat = examination.GroupBy(x => x.NameId).Select(n => new { name = n.Key, db = n.Count() });
            StreamWriter sw = new StreamWriter("Nevstatisztika.txt", false, Encoding.UTF8);
            foreach (var item in nameStat.OrderByDescending(x => x.db)) sw.WriteLine($"{names.Where(x=>x.NameId == item.name).Select(x=>x.Name).FirstOrDefault()}; {item.db}");
            sw.Close();








            Console.ReadKey();
        }
    }
}
