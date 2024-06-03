using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;

namespace Kemia
{
    internal class Elemek
    {
        public string Year;
        public string Name;
        public string Symbol;
        public int AtomicNum;
        public string Discoverer;

        public Elemek(string line)
        {
            string[] hashed = line.Split(';');
            this.Year = hashed[0];
            this.Name = hashed[1]; 
            this.Symbol = hashed[2];
            this.AtomicNum = int.Parse(hashed[3]);
            this.Discoverer = hashed[4];
        }

        public static IEnumerable<Elemek>LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName,e).ToList().Skip(1))
            {
                yield return new Elemek(item);
            }
        }

        public int YearOfDisc
        {
            get
            {
                if (Year != "Ókor") return int.Parse(Year);
                else return 0;
            }
        }
    }
}
