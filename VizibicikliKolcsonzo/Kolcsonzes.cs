using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VizibicikliKolcsonzo
{
    internal class Kolcsonzes
    {
        public string Nev;
        public string JAzon;
        public int EOra;
        public int EPerc;
        public int VOra;
        public int VPerc;

        public Kolcsonzes(string line)
        {
            var temp = line.Split(';');
            Nev = temp[0];
            JAzon = temp[1];
            EOra = int.Parse(temp[2]);
            EPerc = int.Parse(temp[3]);
            VOra = int.Parse(temp[4]);
            VPerc = int.Parse(temp[5]);

        }

        public int Epercben
        {
            get 
            { 
                return EOra*60+EPerc;
            }
        }
        public int Vpercben
        {
            get
            {
                return VOra * 60 + VPerc;
            }
        }

        public static IEnumerable<Kolcsonzes> LoadFromTxt(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1))
            {
                yield return new Kolcsonzes(item);
            }
        }
    }
}
