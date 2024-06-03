using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berek2020
{
    public class berek
    {
        public string Name;
        public string Gender;
        public string Division;
        public int EnterYear;
        public int Salary;

        public berek(string sor)
        {
            string[] splitted = sor.Split(';');
            this.Name = splitted[0];
            this.Gender = splitted[1];
            this.Division = splitted[2];
            this.EnterYear = Convert.ToInt32(splitted[3]);
            this.Salary = Convert.ToInt32(splitted[4]);
        }

        public static IEnumerable<berek> LoadFromTxt(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1))
            {
                yield return new berek(item);
            }
        }


    }
}
