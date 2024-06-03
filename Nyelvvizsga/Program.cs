using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyelvvizsga
{
    class Vizsga
    {
        public string lang;
        public List<int> success, unsuccess, total;

        public Vizsga(string line1, string line2)
        {
            var temp1 = line1.Split(';');
            var temp2 = line2.Split(';');
            lang = temp1[0];
            success = new List<int>(); unsuccess = new List<int>(); total = new List<int>();
            for (int i = 1; i < temp1.Length; i++)
            {
                success.Add(int.Parse(temp1[i]));
                unsuccess.Add(int.Parse(temp2[i]));
                total.Add(success[i - 1] + unsuccess[i - 1]);
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vizsga> data = new List<Vizsga>();
            var line1 = File.ReadAllLines("sikeres.csv", Encoding.Default);
            var line2 = File.ReadAllLines("sikertelen.csv", Encoding.Default);
            for (int i = 1; i<line1.Length; i++) { data.Add(new Vizsga(line1[i], line2[i])); }  


            //2. feladat

            List<Vizsga> dataOrd = new List<Vizsga>(data.OrderByDescending(x => x.total.Sum()).ToList().Take(3));
            Console.WriteLine($"2. feladat: A legnépszerűbb nyelvek:");
            foreach (var item in dataOrd)
            {
                Console.WriteLine($"\t{item.lang}");
            }
            //3. feladat

            Console.WriteLine("3. feladat:");
            int year = 0;
            do
            {
                Console.Write("\tVizsgáladó év: ");
                year = int.Parse(Console.ReadLine());
            } while (year < 2009 || year > 2017);

            //4. feladat    

            //Dictionary-vel
            
            Dictionary<string, double> langUnsuccess = new Dictionary<string, double>();
            foreach (var item in data)
            {
                if (item.total[year - 2009] != 0) { langUnsuccess.Add(item.lang, (double)item.unsuccess[year - 2009] * 100 / (double)item.total[year - 2009]); }
            }
            foreach (var item in langUnsuccess)
            {
                if (item.Value == langUnsuccess.Values.Max()) { Console.WriteLine($"4. feladat:\n\t{year}-ben {item.Key} nyelvből a sikertelen vizsgázók aránya {item.Value: .##} % "); }
            }

            
            //Linq-kel

            Vizsga mostUnsuccess = data.Where(x => x.total[year - 2009] != 0).ToList().OrderByDescending(x => (double)x.unsuccess[year - 2009] / x.total[year - 2009]).ToList().First();
            Console.WriteLine($"4. feladat:\n\t{year}-ben {mostUnsuccess.lang} nyelvből a sikertelen vizsgázók aránya {(double)mostUnsuccess.unsuccess[year - 2009]*100 / mostUnsuccess.total[year - 2009]: .##} % ");

            //5. feladat

            Console.WriteLine("5. feladat");

            foreach (var item in data) 
            {
                if (item.total[year-2009] == 0) { Console.WriteLine($"{item.lang}"); }
            }

            //6. feladat

            StreamWriter sw = new StreamWriter ("osszesites.csv", false, Encoding.UTF8);
            foreach (var item in data) 
            { 
                sw.WriteLine($"{item.lang};{item.total.Sum()};{(double)item.success.Sum()*100/(double)item.total.Sum():.##}%");
            }
            sw.Close ();







            Console.ReadKey();
        }
    }
}
