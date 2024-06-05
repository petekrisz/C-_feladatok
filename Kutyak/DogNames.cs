using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    public class DogNames
    {
        public int NameId;
        public string Name;

        public DogNames(string line) 
        {
            var temp = line.Split(';');
            this.NameId = int.Parse(temp[0]);
            this.Name = temp[1];
        }

        public static IEnumerable<DogNames> LoadFromCsv(string fileName, Encoding e) 
        { 
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1)) 
            { 
                yield return new DogNames(item); 
            }
            
        }
    }
}
