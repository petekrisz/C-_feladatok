using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Operatorok
{
    internal class Program
    {
        static List<Operatorok> data = Operatorok.LoadFromTxt("kifejezesek.txt", Encoding.UTF8).ToList();

        static void Main(string[] args)
        {

            //2. feladat
            Console.WriteLine($"2. feladat: A kifejezése száma: {data.Count}");

            //3.feladat
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {data.Where(x=>x.muv == "mod").Count()}");

            //4. feladat
            if (data.Exists(x => x.op1 % 10 == 0 && x.op2 % 10 == 0)) Console.WriteLine($"4. feladat: Van ilyen kifejezés");
            else Console.WriteLine($"4. feladat: Nincs ilyen kifejezés");

            //5. feladat

            var statistic = data.GroupBy(x => x.muv).Select(n => new { muv = n.Key, db = n.Count() });
            Console.WriteLine("5. feladat: Statisztika:");
            foreach (var item in statistic)
            {
                if (item.muv == "div" || item.muv == "mod" || item.muv == "+" || item.muv == "-" || item.muv == "*" || item.muv == "/") Console.WriteLine($"\t{item.muv} -> {item.db} db");
            }

            //7. feladat
            
            Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
            string input = Console.ReadLine();
            while (input != "vége")
            {           
                Console.WriteLine($"\t{Result(input)}");
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                input = Console.ReadLine();
            } 
            
            //8. feladat
            StreamWriter sw=new StreamWriter("eredmenyek.txt", false, Encoding.UTF8);
            foreach (var item in data) 
            { 
                string output = item.op1.ToString()+" "+item.muv+" "+ item.op2.ToString();
                sw.WriteLine($"{Result(output)}");
            }
            sw.Flush();
            sw.Close();


           

            Console.ReadKey(); 
        }
        
        //6. feladat + 7.
        
        public static string Result(string input)
        {
            string[] muvelet = input.Split(' ');
            int op1 = int.Parse(muvelet[0]);
            string muv = muvelet[1];
            int op2 = int.Parse(muvelet[2]);
            string eredmeny = "";
            try
            {
                switch (muv)
                {
                    case "div":
                        eredmeny = Convert.ToString(op1/op2);
                        break;
                    case "%":
                        eredmeny = Convert.ToString(op1 % op2);
                        break;
                    case "/":
                        eredmeny = Convert.ToString((double)op1 / op2);
                        break;
                    case "*":
                        eredmeny = Convert.ToString(op1 * op2);
                        break;
                    case "+":
                        eredmeny = Convert.ToString(op1 + op2);
                        break;
                    case "-":
                        eredmeny = Convert.ToString(op1 - op2);
                        break;
                    default:
                        eredmeny = ("Hibás operátor!");
                        break;
                }
            }
            catch (Exception)
            {
                eredmeny = ("Egyéb hiba!");
            }
            return input + " = " + eredmeny;
        }

    }
}
