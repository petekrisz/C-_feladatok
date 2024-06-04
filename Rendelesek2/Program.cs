using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Rendelesek2.RendelesData;

namespace Rendelesek2
{
        public class Storage
    {
        public string PCode;
        public string PName;
        public int PPrice;
        public int PQuantity;
        public int PNeed;



        public Storage(string lineS)
        {
            var temp = lineS.Split(';');
            this.PCode = temp[0];
            this.PName = temp[1];
            this.PPrice = int.Parse(temp[2]);
            this.PQuantity = int.Parse(temp[3]);

        }

    }
        public class RendelesData
    {
        public DateTime OTime;
        public int ONumber;
        public string OEmail;
        public int OTotalValue;
        public bool OSatisfiable;





        public RendelesData(string lineD)
        {
            var temp = lineD.Split(';');
            this.OTime = DateTime.Parse(temp[1]);
            this.ONumber = int.Parse(temp[2]);
            this.OEmail = temp[3];
            this.OSatisfiable=true;
            


        }

        public class RendelesContent
        {
            public int ONumber;
            public string OCode;
            public int OQuantity;
            public int OValue;




            public RendelesContent(string lineT)
            {
                var temp = lineT.Split(';');
                this.ONumber = int.Parse(temp[1]);
                this.OCode = temp[2];
                this.OQuantity = int.Parse(temp[3]);


            }


        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Storage> keszlet = new List<Storage>();
            foreach (var item in File.ReadAllLines("raktar.csv", Encoding.Default)) 
            { 
                keszlet.Add(new Storage(item));
            }

            List<RendelesData> rendeles = new List<RendelesData>();
            foreach (var item in File.ReadAllLines("rendeles.csv", Encoding.Default))
            {
                if(item.Substring(0, 1) == "M") rendeles.Add(new RendelesData(item));
            }

            List<RendelesContent> tetelek = new List<RendelesContent>();
            foreach (var item in File.ReadAllLines("rendeles.csv", Encoding.Default))
            {
                if (item.Substring(0, 1) == "T") tetelek.Add(new RendelesContent(item));
            }

            foreach (var item in tetelek)
            {
                item.OValue = keszlet.Where(x => x.PCode == item.OCode).Select(x => x.PPrice).FirstOrDefault() * item.OQuantity;
                
            }
            foreach (var item in rendeles) 
            {
                item.OTotalValue = tetelek.Where(x => x.ONumber == item.ONumber).Select(x => x.OValue).Sum();
            }


            Masodik(keszlet, rendeles, tetelek);

            //3. feladat
            
            StreamWriter sw = new StreamWriter("levelek.csv", false, Encoding.UTF8);
            foreach (var item in rendeles)
            {
                if (item.OSatisfiable) sw.WriteLine($"{item.OEmail}; A rendelését két napon belül szállítjuk. A rendelés értéke: {item.OTotalValue} Ft");
                else sw.WriteLine($"{item.OEmail}; A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.");
            }
            sw.Close();

            
            //4.feladat
            
            StreamWriter swbesz = new StreamWriter("beszerzes.csv", false, Encoding.UTF8);
            foreach (var item in keszlet)
            {
                int beszerzendo =  item.PQuantity-item.PNeed; //mivel egy megrendelés egyetlen tétel miatt is teljesíthetetlen lehet, előfordulhat, hogy fedezi a készletünk a szükséges mennyiségeket, ezért a különbséggel kell számolni
                if (beszerzendo < 0) swbesz.WriteLine($"{item.PCode};{beszerzendo*-1}"); //ha a különbség negatív, akkor -1 szeresét írjuk be
            }
            swbesz.Close();









            Console.ReadKey();
        }

        private static void Masodik(List<Storage> keszlet, List<RendelesData> rendeles, List<RendelesContent> tetelek)
        {


            foreach (RendelesData r in rendeles)
            {
                Dictionary<string, int> RendelTetelek = new Dictionary<string, int>(); //Kell valami, ahogy a komplett megrendelést tárolhatjuk, ugyanis csak akkor vonhatjuk le a készletből, ha minden tétel teljesíthető
                foreach (RendelesContent tetel in tetelek)
                {

                    if (r.ONumber == tetel.ONumber) //rendelés és a tétel egymáshoz rendelése
                    {

                        foreach (Storage s in keszlet)
                        {

                            if (tetel.OCode == s.PCode) // készletben megkeresése a mennyiségnek a kód megfeleltetésével
                            {

                                if (tetel.OQuantity > s.PQuantity) //ha többet akarnak rendelni, mint amennyi van ebből a termékből --> a megrendelés teljesíthetetlen lesz
                                {
                                    r.OSatisfiable = false;
                                }

                                if (!RendelTetelek.ContainsKey(tetel.OCode)) //a szótár feltöltése a rendelés vizsgálathoz
                                {
                                    RendelTetelek.Add(tetel.OCode, tetel.OQuantity);
                                }
                                else
                                {
                                    RendelTetelek[tetel.OCode] += tetel.OQuantity; //mert van olyan rendelés, ahol több tételben szerepel ugyanaz a dolog
                                }


                            }
                        }
                    }
                }
                if (r.OSatisfiable) //ha teljesíthető
                {
                    foreach (var i in RendelTetelek)
                    {
                        foreach (Storage s in keszlet)
                        {
                            if (i.Key == s.PCode) s.PQuantity -= i.Value; // a szótár kulcsainak megfelelő termékekből levonunk annyit, amennyi a kulcs értéke
                        }
                    }
                }
                else //ha nem teljesíthető, akkor minden tételt a kódnak megfelelő PNeed-be írunk
                {
                    foreach (var i in RendelTetelek)
                    {
                        foreach (Storage s in keszlet)
                        {
                            if (i.Key == s.PCode) s.PNeed += i.Value;
                        }
                    }
                }

                RendelTetelek.Clear(); // kiürítjük a szótárt a következő rendelés feldolgozásához
            }

        }


    }
}
