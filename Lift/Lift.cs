using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Lift
{
    public class Lift
    {
        public DateTime Day;
        public int ID;
        public int Start;
        public int End;

        public Lift (string line)
        {
            var temp = line.Split(' ');
            this.Day = Convert.ToDateTime(temp[0]);
            this.ID= Convert.ToInt32(temp[1]);
            this.Start = Convert.ToInt32(temp[2]);
            this.End = Convert.ToInt32(temp[3]);
        }

        public static IEnumerable<Lift>LoadFromTxt(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList())
            {
                yield return new Lift(item);
            }
        }


    }
}
