using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace helsinki1952
{
    public class Results
    {
        public int Rank;
        public int Competitors;
        public string Sport;
        public string Event;

        public Results(string line)
        {
            var temp = line.Split();
            Rank = int.Parse(temp[0]);
            Competitors = int.Parse(temp[1]);   
            Sport = temp[2]; 
            Event = temp[3];
        }

        public int OlimpicPoints 
        {
            get
            {
                if (Rank == 1) return 7;
                else if (Rank == 2) return 5;
                else if (Rank == 3) return 4;
                else if (Rank == 4) return 3;
                else if (Rank == 5) return 2;
                else return 1;
            }
        }


    }
    
    
    public class Program
    {
        static void Main(string[] args)
        {
            List<Results> HelsinkiResults = new List<Results>();
            foreach (var item in File.ReadAllLines("helsinki.txt", Encoding.Default))
            {
                HelsinkiResults.Add(new Results(item));
            }

            //3. feladat

            Console.WriteLine($"3. feladat:\nPontszerző helyek száma: {HelsinkiResults.Count()}");

            //4. feladat

            Console.WriteLine($"4. feladat:\nArany: {HelsinkiResults.Count(x => x.Rank == 1)}\nEzüst: {HelsinkiResults.Count(x => x.Rank == 2)}\nBronz: {HelsinkiResults.Count(x => x.Rank == 3)}");

            //5. feladat

            Console.WriteLine($"5. feladat:\nOlimpiai pontok száma: {HelsinkiResults.Sum(x => x.OlimpicPoints)}");

            //6. feladat

            int uszas = HelsinkiResults.Count(x => x.Sport == "úszás" && x.Rank < 4);
            int torna = HelsinkiResults.Count(x => x.Sport == "torna" && x.Rank < 4);

            if (uszas > torna)
            {
                Console.WriteLine($"6. feladat: \nÚszás sportágban szereztek több érmet.");
            }
            else if (torna > uszas)
            {
                Console.WriteLine($"6. feladat: \nTorna sportágban szereztek több érmet.");
            }
            else
            {
                Console.WriteLine($"6. feladat: \nEgyenlő volt az érmek száma.");
            }

            //7. feladat

            var write = new StreamWriter("helsinki2.txt", false, Encoding.UTF8);

            foreach (var item in HelsinkiResults)
            {
                if (item.Sport == "kajakkenu")
                {
                    write.WriteLine($"{item.Rank} {item.Competitors} {item.OlimpicPoints} {"kajak-kenu"} {item.Event}");
                }
                else
                {
                    write.WriteLine($"{item.Rank} {item.Competitors} {item.OlimpicPoints} {item.Sport} {item.Event}");
                }
            }

            write.Close();

            //8. feladat

            var most = HelsinkiResults.OrderByDescending(x=>x.Competitors).First();

            Console.WriteLine($"8. feladat:\nHelyezés: {most.Rank}\nSportág: {most.Sport}\nVersenyszám: {most.Event}\nSportolók száma:{most.Competitors}");



            Console.ReadKey();
        }
    }
}
