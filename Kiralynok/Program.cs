using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kiralynok
{

    class Tabla
    {
        private char[,] T;
        private char UresCella;

        public Tabla (char c)
        {
            T = new char[8, 8];
            UresCella = c;
            for (int s = 0; s < 8; s++)
            {
                for (int o = 0; o < 8; o++)
                {
                    T[s, o] = c;
                }   
            }
        }

        //.4, feladat metódus
        public void Megjelenit()
        {
            for (int s = 0; s < 8; s++)
            {
                Console.Write("\n\t");
                for (int o = 0; o < 8; o++)
                {
                    Console.Write(T[s,o]);
                }
            }
        }

        //5. feladat metódus

        public void Elhelyez (int N)
        {
            Random random = new Random();
            int row;
            int column;
            for (int i = 0; i < N; i++)
            {
                do
                {
                    row = random.Next(8);
                    column = random.Next(8);
                } while (T[row, column] == 'K');
                T[row, column] = 'K';
            }
        }

       public bool UresOszlop (int o)
        {
            bool isThere=true;
            for (int i=0;i<8;i++) 
            {
                if (T[i,o] == 'K') {  isThere = false; break; }
            }
            return isThere;
        }


        public bool UresSor(int s)
        {
            bool isThere = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[s, i] == 'K') { isThere = false; break; }
            }
            return isThere;
        }

        public int UresSorokSzama 
        {
            get
            {
                int num = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (UresSor(i)) num++;
                }
                return num;
            }
        }

        public int UresOszlopokSzama
        {
            get
            {
                int num = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (UresOszlop(i)) num++;
                }
                return num;
            }
        }

        public void Kiir(StreamWriter sw)
        {
            for (int s = 0; s < 8; s++)
            {
                sw.Write("\n\t");
                for (int o = 0; o < 8; o++)
                {
                    sw.Write(T[s, o]);
                }
            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //4. feladat meghívás

            Console.WriteLine("\n4. feladat: Az üres tábla:");
            Tabla JatekTer = new Tabla('#');
            JatekTer.Megjelenit();

            //6. feladat meghívás

            Console.WriteLine("\n\n6. feladat: A feltöltött tábla:");
            JatekTer.Elhelyez(8);
            JatekTer.Megjelenit();

            //9. feladat

            Console.WriteLine($"\n\n9. feladat: Üres oszlopok és sorok száma:\n\tOszlopok: {JatekTer.UresOszlopokSzama}\n\tSorok:{JatekTer.UresSorokSzama}");

            //10. feladat

            if (File.Exists("tablak64.txt")) File.Delete("tablak64.txt");

            StreamWriter sw = new StreamWriter("tablak64.txt");
            for (int i = 1; i < 65; i++)
            {
                Tabla JatekTerToltes = new Tabla('*');
                JatekTerToltes.Elhelyez(i);
                JatekTerToltes.Kiir(sw);
                sw.WriteLine();

            }    



            sw.Flush();sw.Close();



            Console.ReadKey();
        }
    }
}
