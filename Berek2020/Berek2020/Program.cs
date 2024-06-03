using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Berek2020
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<berek> data = berek.LoadFromTxt ("berek2020.txt", Encoding.UTF8).ToList(); //Encoding.UTF8 ill. Encoding.Default

            //3. feladat
            Console.WriteLine($"3. feladat: A dolgozók száma: {data.Count} fő");

            //4. feladat
            double sumSalary = 0;
            foreach (var item in data)
            {
                sumSalary += item.Salary;    
            }

            Console.WriteLine($"4. feladat: A Bérek átlaga: {(sumSalary/data.Count)/1000: .#} eFt");

            //5. feladat
            
            Console.Write("5. feladat: Kérem egy részleg nevét: ");
            string div = Console.ReadLine();

            //6. feladat

            int divSalary = 0, divindex = 0;  
            
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].Division == div)
                {
                    if (data[i].Salary > divSalary)
                    {
                        divindex = i;
                        divSalary = data[i].Salary;
                    }


                }
            }
            if (divindex == 0) { Console.WriteLine("6. feladat: A megadott részleg nem létezik a cégnél!"); }
            else
            {
                Console.WriteLine("6. feladat: A legtöbbet kereső dolgozó a megadott részlegen");
                Console.WriteLine($"\tNév: {data[divindex].Name}\n\tNeme: {data[divindex].Gender}\n\tBelépés: {data[divindex].EnterYear}\n\tBér: {data[divindex].Salary: ### ### ###} Forint");
            }

            //7. feladat

            Dictionary<string, int> statistic = new Dictionary<string, int>();
            Console.WriteLine("7. feladat: Statisztika");
            foreach (var item in data)
            {
                if (!statistic.ContainsKey(item.Division))
                {
                    statistic.Add(item.Division, 1);
                }
                else
                {
                    statistic[item.Division]++;
                }
            }

            foreach (var item in statistic)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value} fő");
            }




            Console.ReadKey();
        }
    }
}
