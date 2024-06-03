using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace AutoVerseny
{
    class AV
    {
        public string Team;
        public string Racer;
        public int Age;
        public string Circuit;
        public string LapTime;
        public int Laps;

        public AV(string line)
        {
            var temp = line.Split(';');
            Team = temp[0];
            Racer = temp[1];
            Age = int.Parse(temp[2]);
            Circuit = temp[3];
            LapTime = temp[4];
            Laps = int.Parse(temp[5]);
        }

        public int Time
        { 
            get
            {
                int hour = int.Parse(LapTime.Substring(0, 2));
                int min = int.Parse(LapTime.Substring(3, 2));
                int sec = int.Parse(LapTime.Substring(6, 2));
                return hour * 3600 + min * 60 + sec;
            }
            
        }
    }
    

    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            List<AV> data = new List<AV>();
            foreach (var item in File.ReadAllLines("autoverseny.csv", Encoding.Default).Skip(1))
            {
                data.Add(new AV(item));
            }

            //3. feladat
            Console.WriteLine($"3. feladat: {data.Count}");

            //4. feladat
            
            foreach (var item in data)
            {
                if (item.Racer == "Fürge Ferenc" && item.Circuit == "Gran Prix Circuit" && item.Laps == 3)
                {
                    Console.WriteLine($"4. feladat: {item.Time} másodperc");
                }
            }
            

            //5. feladat
            Console.WriteLine("5. feladat:\nKérem adjon meg egy nevet:");
            string name=Console.ReadLine();

            //6. feladat

            int fastest=50000;
            bool isThere=false;
            foreach (var item in data)
            {
                if (item.Racer == name)
                {
                    if (item.Time < fastest) fastest = item.Time;
                }
            }
            foreach (var item in data)
            {
                if(item.Racer == name && item.Time == fastest)
                {
                    Console.WriteLine($"6. feladat: {item.Circuit}, {item.LapTime}");
                    isThere = true;
                    break;
                }
            }
            if (!isThere) Console.WriteLine($"6. feladat: Nincs ilyen versenyző az állományban");


            //6. feladat - Linq
            if (data.Exists(x => x.Racer == name))
            {
                AV fastestTime = data.Where(x => x.Racer == name).OrderBy(x => x.Time).First();
                Console.WriteLine($"6. feladat: {fastestTime.Circuit}, {fastestTime.LapTime}");
            }
            else Console.WriteLine($"6. feladat: Nincs ilyen versenyző az állományban");

            
            
            
            
            Console.ReadKey();
        }
    }
}
