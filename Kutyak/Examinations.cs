using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    public class Examinations
    {
        public int examId;
        public int SpecId;
        public int NameId;
        public int Age;
        public string LastExam;

        public Examinations(string line) 
        {
            var temp = line.Split(';');
            this.examId = int.Parse(temp[0]);
            this.SpecId = int.Parse(temp[1]);
            this.NameId = int.Parse(temp[2]);
            this.Age = int.Parse(temp[3]);
            this.LastExam = temp[4];
        }

        
        
        
        
        public static IEnumerable<Examinations> LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1))
            {
                yield return new Examinations(item);
            }

        }

    }
}
