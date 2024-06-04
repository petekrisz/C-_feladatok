using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Morze
{
    
    public class MorzeText
    {
        public string Author;
        public string Quote;

        public MorzeText(string line)
        {
            var temp = line.Split(';');
            Author = temp[0];
            Quote = temp[1];
        }

        public static IEnumerable<MorzeText> LoadFromTxt(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList())
            {
                yield return new MorzeText(item);
            }
        }


    }




}
