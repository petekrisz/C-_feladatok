using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Morze
{
    public class MorzeABC
    {
        public string Letter;
        public string Code;

        public MorzeABC(string line) 
        { 
            var temp = line.Split('\t');
            Letter = temp[0];
            Code = temp[1];
        } 
        
        public static IEnumerable<MorzeABC>LoadFromTxt(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1)) 
            { 
                yield return new MorzeABC(item);
            }
        }
        
    }

   




}
