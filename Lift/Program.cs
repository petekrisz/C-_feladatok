using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Program
    {

        static List<Lift> data = Lift.LoadFromTxt("lift.txt", Encoding.Default).ToList();

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("hu", false);

            //3. feladat
            Console.WriteLine($"3. feladat: Összes lifthasználat: {data.Count}");

            //4. feladat
            Console.WriteLine($"4. feladat: Időszak: {data.Min(x=>x.Day): yyyy.MM.dd} - {data.Max(x => x.Day): yyyy.MM.dd}");

            //5. feladat
            Console.WriteLine($"5. feladat: Célszint max: {data.Max(x => x.End)}");

            //6. feladat
            int card;
            int level;
            Console.Write("6. feladat\n\tKártya száma: ");
            try { card = int.Parse(Console.ReadLine()); }
            catch (FormatException) { card = 5; }
            Console.Write("\tCélszint száma: ");
            try { level = int.Parse(Console.ReadLine()); }
            catch (FormatException) { level = 5; }

            //7. feladat
            if (data.Exists(x => x.ID == card && x.End == level)) Console.WriteLine($"A(z) {card}. kártyával utaztak a(z) {level}. emeletre!");
            else Console.WriteLine($"A(z) {card}. kártyával nem utaztak a(z) {level}. emeletre!");

            //8. feladat
            var statisztika = data.GroupBy(x => x.Day).Select(n => new { Day = n.Key, db = n.Count() });
            Console.WriteLine("8. feladat: Statisztika: ");
            foreach (var item in statisztika) Console.WriteLine($"\t{item.Day: yyyy.MM.dd} - {item.db}x");


            Console.ReadKey();
        }
    }
}
