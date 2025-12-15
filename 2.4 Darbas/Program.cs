using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Darbas
{

    class Auto
    {
        private string pav, degalai;
        private double sanaudos;

        public Auto(string pav, string degalai, double sanaudos)
        {
            this.pav = pav;
            this.degalai = degalai;
            this.sanaudos = sanaudos;
        }

        public string ImtiPav() { return pav; }
        public string ImtiDegalus() { return degalai; }
        public double ImtiSanaudos() { return sanaudos; }

        internal class Program
        {

            const int CN = 100;//maksimalus objekto kiekis
            const string CFd = "..\\..\\Duomenys.txt";
            const string CFrez = "..\\..\\Rezultatai.txt";

            static void Main(string[] args)
            {

                Auto[] A = new Auto[CN];      //auto duomenys
                int na;                      //auto kiekis

                if (File.Exists(CFrez))
                    File.Delete(CFrez);

                Skaityti(CFd, A, out na);
                Spausdinti(CFrez, A, na);


                string benz = "benzinas";
                string dyzel = "dyzelinas";

                using(var fr = File.AppendText(CFrez))
                {
                    fr.WriteLine("Vidutines degalu sanaudos: {0,7:f2} litro/100 km", VidSanaudos(A, na));
                    fr.WriteLine("{0} - variklius turinciu automobiliu kiekis:" +
                        " {1}", dyzel ,DyzelinoVarikliai(A, na, dyzel));
                    fr.WriteLine("{0} - variklius turinciu automobiliu kiekis:" +
                        " {1}\n\n", benz, DyzelinoVarikliai(A, na, benz));
                    fr.WriteLine("{0} - variklius turinciu automobiliu vid. sanaudos:" +
                        " {1} litro/100 km", dyzel, VidSanaudos(A, na, dyzel));
                    fr.WriteLine("{0} - variklius turinciu automobiliu vid. sanaudos:" +
                        " {1} litro/100 km", benz, VidSanaudos(A, na, benz));
                }




                Console.WriteLine("Programa baigė darbą!");

                
            }
            //fd - duomenu failo vardas
            static void Skaityti(string Fd, Auto[] A, out int kiek)
            {
                using (StreamReader reader = new StreamReader(Fd))
                {
                    string pav, degalai; double sanaudos;
                    string line;
                    line = reader.ReadLine();
                    string[] parts;
                    kiek = int.Parse(line);
                    for (int i = 0; i < kiek; i++)
                    {
                        line = reader.ReadLine();
                        parts = line.Split(';');
                        pav = parts[0];
                        degalai = parts[1];
                        sanaudos = double.Parse(parts[2]);
                        A[i] = new Auto(pav, degalai, sanaudos);  
                    }

                }

            }
            //fv - rez failo vardas
            //a - auto objekto rinkinys
            //kiek - auto kiekis rinkinyje
            static void Spausdinti(string fv, Auto[] A, int kiek)
            {
                const string virsus =
                        "|---------|---------------------|---------------------|---------------------|\r\n"
                        + "|         |                     |                     |                     |\r\n"
                        + "| Eil nr. | Pavadinimas         | Degalai             | Sąnaudos (l/100 km) |\r\n"
                        + "|         |                     |                     |                     |\r\n"
                        + "|---------|---------------------|---------------------|---------------------|";
                using (var fr = File.AppendText(fv))
                {
                    fr.WriteLine("Automobiliu kiekis {0}", kiek);
                    fr.WriteLine("Automobiliu sarasas:");
                    fr.WriteLine(virsus);
                    Auto a;
                    for (int i = 0; i < kiek; i++)
                    {
                        a = A[i];
                        fr.WriteLine("| {0, 7} | {1,-19} | {2,-19} | {3,19:f2} |",
                            i+1, a.ImtiPav(), a.ImtiDegalus(), a.ImtiSanaudos()
                            );
                    }
                    fr.WriteLine("-----------------------------------------------------------------------------");
                }
            }

            static double VidSanaudos(Auto[] A, int kiek, string kuras = null)
            {
              
                double sum = 0;
                int nkiekis = 0;
                for (int i =0; i<kiek; i++)
                {
                    if (kuras == null || A[i].ImtiDegalus() == kuras)
                    {
                       sum = sum + A[i].ImtiSanaudos();
                        nkiekis++;
                    }
                }
               
                
                return sum / nkiekis;
            }

            static int DyzelinoVarikliai(Auto[] A, int kiek, string kuras)
            {
                int sum = 0;
                string variklis = kuras;
                for (int i =0; i < kiek;i++)
                {
                    if (A[i].ImtiDegalus() == variklis)
                    {
                        sum++;
                    }
                }
                return sum;

            }


        }
    }
}
