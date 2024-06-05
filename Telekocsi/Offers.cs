using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    public class Offers
    {
        public string Start;
        public string End;
        public string LPlate;
        public string Phone;
        public int Places;


        public Offers(string line) 
        {
            var temp = line.Split(';');
            Start = temp[0];
            End = temp[1];
            LPlate = temp[2];
            Phone = temp[3];
            Places = int.Parse(temp[4]);
        }

        public static IEnumerable<Offers> LoadFromCsv(string fileName, Encoding e) 
        {
            foreach (var item in File.ReadAllLines(fileName,e).ToList().Skip(1))
            {
                yield return new Offers(item);
            }
        }

    }
}
