using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    public class DogSpec
    {
        public int SpecId;
        public string Name;
        public string OriginalName;

        public DogSpec(string line)
        {
            var temp = line.Split(';');
            this.SpecId = int.Parse(temp[0]);
            this.Name = temp[1];
            this.OriginalName = temp[2];
        }

        public static IEnumerable<DogSpec> LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1))
            {
                yield return new DogSpec(item);
            }

        }
        

    }
}
