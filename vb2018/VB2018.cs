using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vb2018
{
    internal class VB2018
    {
        public string City;
        public string Stadion;
        public string Alias;
        public int Capacity;
        public VB2018(string line)
        {
            var temp = line.Split(';');
            this.City = temp[0];
            this.Stadion = temp[1];
            this.Alias = temp[2];
            this.Capacity = int.Parse(temp[3]);
        }

        public static IEnumerable<VB2018>LoadFromTxt(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1))
            {
                yield return new VB2018(item);
            }
            
        }
    }
}
