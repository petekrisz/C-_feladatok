using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jackie
{
    public class Jackie
    {
        public int Year;
        public int Races;
        public int Wins;
        public int Podiums;
        public int Poles;
        public int Fastests;

        public Jackie(string line) 
        {
            var temp = line.Split('\t');
            Year = int.Parse(temp[0]);
            Races = int.Parse(temp[1]);
            Wins = int.Parse(temp[2]);
            Podiums = int.Parse(temp[3]);
            Poles = int.Parse(temp[4]);
            Fastests = int.Parse(temp[5]);
        }
        
        public static IEnumerable<Jackie>LoadFromTxt(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1))
            {
                yield return new Jackie(item);
            }
        }
    }
}
