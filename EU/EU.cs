using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EU
{
    public class EU
    {
        public string State;
        public DateTime Join;

        public EU(string line) 
        {
            string[] splitted = line.Split(';');
            this.State = splitted[0];
            this.Join = Convert.ToDateTime(splitted[1]);
        }

        public static IEnumerable<EU> LoadFromTxt(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList())
            {
                yield return new EU(item);
            }
        }
    }
}
