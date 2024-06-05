using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    public class Demands
    {
        public string ID;
        public string Start;
        public string End;
        public int Places;
        public string Message;


        public Demands (string line)
        {
            var temp = line.Split(';');
            ID = temp[0];
            Start = temp[1];
            End = temp[2];
            Places = int.Parse(temp[3]);
        }

        public static IEnumerable<Demands> LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1))
            {
                yield return new Demands(item);
            }
        }


    }
}
