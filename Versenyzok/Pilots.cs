using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Versenyzok
{
    public class Pilots
    {
        public string Name;
        public DateTime BirthDate;
        public string Nationality;
        public int Number;

        public Pilots(string line) 
        { 
            if (line.EndsWith(";"))
            {
                line.Substring(0, line.Length - 1);
                var temp = line.Split(';');
                this.Name = temp[0];
                this.BirthDate = DateTime.ParseExact(temp[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
                this.Nationality = temp[2];
            }
            else 
            {
                var temp = line.Split(';');
                this.Name = temp[0];
                this.BirthDate = DateTime.ParseExact(temp[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
                this.Nationality = temp[2];
                this.Number = int.Parse(temp[3]);
            }
        }

        public static IEnumerable<Pilots>LoadFromCsv(string fileName,Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName,e).ToList().Skip(1))
            {
                yield return new Pilots(item);
            }
        }


    }
}
