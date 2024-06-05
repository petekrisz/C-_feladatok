using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Globalization;

namespace Helsink2017
{
    public class Korcsolya
    {
        public string Name;
        public string Country;
        public double Technical;
        public double Component;
        public int Minus;


        public Korcsolya(string line)
        { 
            var temp = line.Split(';');
            Name = temp[0];
            Country = temp[1];
            Technical = double.Parse(temp[2], CultureInfo.InvariantCulture);
            Component = double.Parse(temp[3], CultureInfo.InvariantCulture);
            Minus = int.Parse(temp[4]);
        }

        public static IEnumerable<Korcsolya> LoadFromCsv(string fileName, Encoding e) 
        { 
            foreach (var item in File.ReadAllLines(fileName,e).ToList().Skip(1)) yield return new Korcsolya(item);
        }

    }
}
