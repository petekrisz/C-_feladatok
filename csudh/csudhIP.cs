using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace csudh
{
    public class csudhIP
    {
        public string domain;
        public string ip;

        public csudhIP(string line)
        {
            var hashed = line.Split(';');
            this.domain = hashed[0];
            this.ip = hashed[1];
        }

        public string[] LevelsOfAddress
        {
            get
            {
                string[] levelQuery = new string[5];
                for (int i = 0; i < levelQuery.Length; i++)
                {
                    levelQuery[i] = "nincs";
                }
                if (domain.Contains("www")) domain = domain.Substring(4);
                var temp = domain.Split('.');
                Array.Reverse(temp);
                int num = 0;
                foreach (var e in temp)
                {
                    levelQuery[num] = e;
                    num++;
                }
                return levelQuery;
            }
            
        }


        public static IEnumerable<csudhIP> LoadFromTxt(string filename, Encoding e)
        {
            foreach (var item in File.ReadAllLines(filename, e).ToList().Skip(1)) yield return new csudhIP(item);
        }
    }
}
