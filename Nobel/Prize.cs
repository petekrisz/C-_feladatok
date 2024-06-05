using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nobel
{
    public class Prize
    {
        public int Year;
        public string Type;
        public string FirstName;
        public string LastName;

        public Prize (string line)
        {
            var temp = line.Split(';');
            Year = int.Parse(temp[0]);
            Type = temp[1];
            FirstName = temp[2];
            LastName = temp[3];
        }

        public static IEnumerable<Prize>LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1)) 
            { 
                yield return new Prize (item);
            }
        }

    }
}
