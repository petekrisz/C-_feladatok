using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Jackie
{
    internal class Program
    {
        static List<Jackie> data = Jackie.LoadFromTxt("jackie.txt", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {
            Console.WriteLine($"3. feladat: {data.Count}");

            Console.WriteLine($"4. feladat: {data.OrderByDescending(x => x.Races).First().Year}");

            Console.WriteLine($"5. feladat:\n\t70-es évek: {data.Where(x => x.Year >= 1970 && x.Year < 1980).Sum(y => y.Wins)} megnyert verseny\n\t60-as évek: {data.Where(x => x.Year >= 1960 && x.Year < 1970).Sum(y => y.Wins)} megnyert verseny");

            Console.WriteLine("6. feladat: jackie.txt");
            WriteHtml("jackie.html");






            Console.ReadKey();
        }

        private static void WriteHtml(string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
            sw.WriteLine("<!DOCTYPE html>\n<html lang = \"en\">\n<head>\n\t<meta charset = \"UTF-8\">\n\t<meta name = \"viewport\" content = \"width=device-width, initial-scale=1.0\">\n\t<title > Jackie Eredményei </title>\n</head>\n<style>td {border:1px solid black;}</style>");
            sw.WriteLine("<body>");
            sw.WriteLine("<h1>Jackie Stewart</h1>");
            sw.WriteLine("<table>");
            foreach (var item in data)
            {
                sw.WriteLine($"<tr><td>{item.Year}</td><td>{item.Races}</td><td>{item.Wins}</td></tr>");
            }
            sw.WriteLine("</table>\n</body>\n</html>");
            sw.Flush();
            sw.Close();







            Console.ReadKey();
        }





    }
}