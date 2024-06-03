using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Schumacher
{
    public class SchRaces
    {
        public string Date;
        public string Grandprix;
        public int Position;
        public int Laps;
        public int Points;
        public string Team;
        public string Status;

        public SchRaces(string line) 
        {
            var hashed = line.Split(';');
            this.Date = hashed[0];
            this.Grandprix = hashed[1];
            this.Position = int.Parse(hashed[2]);
            this.Laps = int.Parse(hashed[3]);
            this.Points = int.Parse(hashed[4]);
            this.Team = hashed[5];
            this.Status = hashed[6];
        }  
        
        public static IEnumerable<SchRaces> LoadFromCsv(string fileName, Encoding e)
        {
            foreach (var item in File.ReadAllLines(fileName, e).ToList().Skip(1))
            {
                yield return new SchRaces(item);    
            }
        }




    }
}
