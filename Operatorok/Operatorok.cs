using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace Operatorok
{
    internal class Operatorok
    {
        public int op1;
        public string muv;
        public int op2;


        public Operatorok(string line) 
        {
            var temp = line.Split(' ');
            op1 = int.Parse(temp[0]);
            muv = temp[1];
            op2 = int.Parse(temp[2]);
        }

        


        public static IEnumerable<Operatorok> LoadFromTxt(string filename, Encoding e) 
        {
            foreach (var item in File.ReadAllLines(filename,e).ToList())
            {
                yield return new Operatorok(item);
            }
        }

    }
}
