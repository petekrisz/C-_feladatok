using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csudh
{
    internal class Program
    {
        static List<csudhIP> data = csudhIP.LoadFromTxt("csudh.txt", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {

            //3. feladat
            Console.WriteLine($"3. feladat: Domainek száma: {data.Count}");

            //4. feladat
            string IP = data.First().ip;
            Console.WriteLine("5. feladat: Az első domain felépítése: - függvénnyel");
            for (int i = 1;i<6;i++) { Console.WriteLine($"\t {i}. szint: {Level(IP, i)}"); }

            //4. feladat propertyvel
            Console.WriteLine("5. feladat: Az első domain felépítése: - property-vel");
            foreach (var item in data) 
            { 
                if (IP == item.ip)
                {
                    for (int i = 0; i < 5; i++) { Console.WriteLine($"\t {i+1}. szint: {item.LevelsOfAddress[i]}"); }
                }
            }

            //5. feladat

            string ths = "<th style = 'text-align: left'>";
            string thc = "</th>";
            string tds = "<td>";
            string tdc = "</td>";
            string trs = "<tr>";
            string trc = "</tr>";
            string[] header = { "Ssz", "Host domain neve", "Host IP címe","1. szint","2. szint", "3. szint", "4. szint","5. szint" };


            StreamWriter sw = new StreamWriter("table.html", false, Encoding.UTF8);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html lang = \"en\">");
            sw.WriteLine("<head>");
            sw.WriteLine("    <meta charset = \"UTF-8\">");
            sw.WriteLine("    <meta name = \"viewport\" content = \"width=device-width, initial-scale=1.0\">");
            sw.WriteLine("    <title > CSUDH Domains & IPs </title>");
            sw.WriteLine("    <link rel = \"stylesheet\" href = \"alap.css\">");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<table>");
            sw.WriteLine(trs);
            foreach (var item in header)
            {
                sw.WriteLine(ths+item+thc);
            }
            sw.WriteLine(trc);
            int trdb = 1;
            foreach (var item in data)
            {
                sw.WriteLine(trs);
                sw.WriteLine($"{ths}{trdb}.{thc}");
                sw.WriteLine($"{tds}{item.domain}{tdc}");
                sw.WriteLine($"{tds}{item.ip}{tdc}");
                foreach (var e in item.LevelsOfAddress)
                {
                    sw.WriteLine($"{tds}{e}{tdc}");
                }
                sw.WriteLine(trc);
                trdb++;
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");

            sw.Flush();
            sw.Close(); 







            Console.ReadKey();
        }

        private static string Level(string IP, int n)
        {
            string[] levelQuery = new string[5];
            string exemined;
            for (int i = 0; i < levelQuery.Length; i++)
            {
                levelQuery[i] = "nincs";
            }

            foreach (var item in data)
            {
                if (item.ip == IP) 
                {
                    exemined = item.domain;
                    if (exemined.Contains("www")) exemined=exemined.Substring(4);
                    var temp = exemined.Split('.');
                    Array.Reverse(temp);
                    int num = 0;
                    foreach (var e in temp)
                    {
                        levelQuery[num]=e;
                        num++;
                    }  
                }
            }
            return levelQuery[n - 1];
  
        }

    }
}