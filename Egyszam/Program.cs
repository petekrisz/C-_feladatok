using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Egyszam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> jatekosok = new List<string>();
            List<List<int>> tippek =new List<List<int>>();
            foreach (var item in File.ReadAllLines("egyszamjatek.txt", Encoding.UTF8))
            {
                List<int> list = new List<int>();
                int idx = item.LastIndexOf(' ');
                string player = item.Substring(idx);
                jatekosok.Add(player);
                string trunkLine = item.Remove(idx);
                foreach (var e in trunkLine.Split(' '))
                {
                    list.Add(int.Parse(e));
                }
                tippek.Add(list);
                
            }
            //3. feladat
            Console.WriteLine($"3. feladat: A játékosok száma: {jatekosok.Count}");


            //3. feladat
            Console.WriteLine($"4. feladat: Fordulók száma: {tippek[0].Count}");
             
            //4. feladat

            bool isThere1 = false;
            foreach (var item in tippek) 
            {
                if (item[0] == 1)
                {
                    isThere1 = true;
                    
                }
            }
            if (isThere1) { Console.WriteLine("5. feladat: Az első fordulóban volt egyes tipp!"); }
            else {Console.WriteLine("5. feladat: Az első fordulóban nem volt egyes tipp!"); }

            //6. feladat

            int max = 0;
            foreach (var item in tippek)
            {
                foreach (var e in item)
                {
                    if (e>max)
                    {
                        max = e;
                    }
                }
            }

            Console.WriteLine($"6. feladat: A legnagyobb tipp a fordulók során: {max}");

            //7. feladat

            Console.Write("7. feladat: Kérem a forduló sorszámát [1-10]: ");
            int turn = -1;
            try
            {
                turn = int.Parse(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                turn = 0;
            }          
            if (turn < 0 || turn >9) { turn = 0; }



            //8. feladat

            int[] fordulo = new int[9];
            for (int i = 0; i < fordulo.Length; i++)
            {
                fordulo[i]= tippek[i][turn];
            }

            fordulo = fordulo.OrderBy(x => x).ToArray();


            int winner = 0;  
            bool isThereWinner = false;
            for (var i=1;i<fordulo.Length-1;i++) 
            { 
                if ((fordulo[i] != fordulo[i-1]) && (fordulo[i] != fordulo[i + 1]))
                {
                    
                    isThereWinner = true;
                    winner = fordulo[i];
                    break;
                   
                }

            }
            if (!isThereWinner) { Console.WriteLine("8. feladat: Nem volt egyedi tipp a megadott fordulóban!"); }
            else { Console.WriteLine($"8. feladat: A nyertes tipp a megadott fordulóban: {winner}"); }


            //9. feladat

           int playerIdx = -1;

            for (var i = 0; i < tippek.Count; i++)
            {
                if (tippek[i][turn] == winner) { playerIdx = i; break; }
            }  

            if (isThereWinner) { Console.WriteLine($"9. feladat: A megadott forduló nyertese: {jatekosok[playerIdx]}"); }
            else { Console.WriteLine("9. feladat: Nem volt nyertes a megadott fordulóban!"); }

            //10. feladat

            var write = new StreamWriter("nyertes.txt", false, Encoding.UTF8);
            
            write.WriteLine($"Forduló sorszáma: {turn+1}");
            write.WriteLine($"Nyertes tipp: {winner}");
            write.WriteLine($"Nyertes játékos: {jatekosok[playerIdx]}");


            write.Close();





            Console.ReadKey();
        }
    }
}
