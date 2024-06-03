using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    public class ACB_Liga
    {
        public string hazai;
        public string idegen;
        public int hazai_pont;
        public int idegen_pont;
        public string helyszin;
        public string idopont;

        public ACB_Liga(string line)
        {
            string[] hashed = line.Split(';');
            this.hazai = hashed[0];
            this.idegen = hashed[1];
            this.hazai_pont = Convert.ToInt32(hashed[2]);
            this.idegen_pont = Convert.ToInt32(hashed[3]);
            this.helyszin = hashed[4];
            this.idopont = hashed[5];
        }

        public static IEnumerable<ACB_Liga>LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName,e).ToList().Skip(1))
            {
                yield return new ACB_Liga(item);
            }
        }

    }
}
