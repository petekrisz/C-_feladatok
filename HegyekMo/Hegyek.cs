using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HegyekMo
{
    public class Hegyek
    {
        public string Peak;
        public string Mountain;
        public int Height;

        public Hegyek(string line)
        {
            string[] temp = line.Split(';');
            this.Peak = temp[0];
            this.Mountain = temp[1];
            this.Height = int.Parse(temp[2]);
        }

        public double HeightFeet 
        {
            get 
            {  return (double)Height*3.280839895; }
        }


        public static IEnumerable<Hegyek>LoadFromTxt(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1))
            {
                yield return new Hegyek(item);
            }
        }




    }
}
