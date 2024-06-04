using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;

namespace Morze
{
    
    internal class Program
    {
        //2. feladat a MorzeABC osztállyal együtt
        
        static List<MorzeABC> abc=MorzeABC.LoadFromTxt("morzeabc.txt", Encoding.Default).ToList();

        //5. feladat a MorzeText osztállyal együtt

        static List<MorzeText> text = MorzeText.LoadFromTxt("morze.txt", Encoding.Default).ToList();
        static void Main(string[] args)
        {
            //3. feladat

            Console.WriteLine($"3. feladat: A morze abc {abc.Count} db karaktert tartalmaz.");

            //4. feladat
            Console.Write($"4. feladat: kérek egy karaktert: ");
            bool isThere = false;
            string inputLetter = Console.ReadLine().ToUpper();
            foreach( var item in abc ) 
            {
                if (item.Letter == inputLetter) Console.WriteLine($"\tA(z) {item.Letter} karakter morze kódja: {item.Code}");
                isThere = true;
            }
            if ( !isThere ) Console.WriteLine("\tNem található a kódtárban ilyen karakter!");

            //4. feladat Linq-kel

            if (abc.Exists(x =>x.Letter == inputLetter)) Console.WriteLine($"\tA(z) {inputLetter} karakter morze kódja: {abc.Where(x => x.Letter == inputLetter).Select(x => x.Code).FirstOrDefault()}");
            else Console.WriteLine("\tNem található a kódtárban ilyen karakter!");


            // ha feltöltöm előtte az egészet egy listába, akkor a 7. feladattól könnyebb a dolgunk --> lásd alább
            List<MorzeText> decriptedText = new List<MorzeText>();
            foreach (var item in text)
            {
                decriptedText.Add(new MorzeText(Morze2Szoveg(item.Author) + ";" + Morze2Szoveg(item.Quote)));
            }
            //7. feladat - ha nem töltjük fel egy listába a fordítást

            Console.Write($"7. feladat: Az első idézet szerzője: {Morze2Szoveg(text[0].Author)}\n");
            
            

            //7. feladat - lefordított szövegből

            Console.WriteLine($"7. feladat: Az első idézet szerzője: {decriptedText.Select(x=>x.Author).First()}\n");

            //8. feladat

            var longest = decriptedText.OrderByDescending(x => x.Quote.Length).First();
            Console.WriteLine($"8. feladat: A leghosszabb idézet szerzője és az idézet {longest.Author}: {longest.Quote}\n");

            //9. feladat

            foreach (var item in decriptedText)
            {
                Console.WriteLine($"{item.Author}: {item.Quote}");
            }

            StreamWriter sw= new StreamWriter("forditas.txt", false, Encoding.UTF8);
            foreach (var item in decriptedText) 
            {
                sw.WriteLine($"{item.Author.Trim()}: {item.Quote}");
            }
            sw.Close();




            Console.ReadKey();
        }

        //6. feladat a Morze2Szöveg függvénnyel
        public static string Morze2Szoveg(string inputText)
        {
            string decryptedText = "";


            inputText = inputText.Replace("       ","#");
            inputText = inputText.Replace("   ", "^");
            string[] inputWords = inputText.Split('#');

            foreach (var item in inputWords)
            {
                List<string> inputWordsLetters = new List<string>();
                inputWordsLetters = item.TrimEnd().Split('^').ToList();
                foreach (var letter in inputWordsLetters)
                {
                    decryptedText += abc.Where(x => x.Code == letter).Select(x => x.Letter).FirstOrDefault();
                }

                decryptedText += " ";


            }

            return decryptedText;


        }
    }
}
