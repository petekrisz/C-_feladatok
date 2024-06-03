using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hianyzasok
{
    public class Absence
    {

        public string Name;
        public string Class;
        public int FirstDay;
        public int LastDay;
        public int MissedClasses;

        public Absence (string line)
        {
            var temp = line.Split(';');
            this.Name = temp[0];
            this.Class = temp[1];
            this.FirstDay = int.Parse(temp[2]);
            this.LastDay = int.Parse(temp[3]);
            this.MissedClasses = int.Parse(temp[4]);
        }
        public static IEnumerable<Absence>LoadFromCsv(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1)) {yield return new Absence(item); }
        }

    }
}
