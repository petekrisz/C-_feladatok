using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace balkezesek
{
    public class Balkezesek
    {
        public string Name;
        public DateTime FirstDay;
        public DateTime LastDay;
        public int WeightPound;
        public int HeightInch;

        public Balkezesek(string line) 
        { 
            var temp = line.Split(';');
            Name = temp[0];
            FirstDay = DateTime.Parse(temp[1]);
            LastDay = DateTime.Parse(temp[2]);
            WeightPound = int.Parse(temp[3]);
            HeightInch = int.Parse(temp[4]);
        }

        public static IEnumerable<Balkezesek>LoadFromCsv(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1))
            {
                yield return new Balkezesek(item);
            }
        }


    }
}
