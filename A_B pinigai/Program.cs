using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_B_pinigai
{

    class Pinigai
    {
        private int doleriai, centai;
        private double kursas;

        public Pinigai(int doleriai, int centai, double kursas)
        {
            this.doleriai = doleriai;
            this.centai = centai;
            this.kursas = kursas;
        }

        public int ImtiDolerius() { return doleriai; }
        public int ImtiCentus() { return centai; }
        public double ImtiKursa() { return kursas; }


        internal class Program
        {
            const int CN = 100;
            const string CFd1 = "..\\..\\A.txt";
            const string CFd2 = "..\\..\\B.txt";
            static void Main(string[] args)
            {
                Pinigai[] P1 = new Pinigai[CN];
                int n1;
                string vard1;

                Pinigai[] P2 = new Pinigai[CN];
                int n2;
                string vard2;

                Skaityti(CFd1, P1, out n1, out vard1);
                Skaityti(CFd2, P2, out n2, out vard2);



                SpausdintiDuomenis(CFd1, P1, n1, vard1);
                SpausdintiDuomenis(CFd2, P2, n2, vard2);

                double sumaA = Pervertimas(CFd1, P1, n1);
                double sumaB = Pervertimas(CFd2 , P2, n2);

                Console.WriteLine("Bendra {0} suma eurais: {1}", vard1 ,sumaA);
                Console.WriteLine("Bendra {0} suma eurais: {1}", vard2, sumaB);

                double sumaBendra = sumaA + sumaB;
                Console.WriteLine("\nBendra suma eurais: {0}", sumaBendra);

            }
            //fp - failo pavadinimas
            static void Skaityti(string fp, Pinigai[] P, out int n, out string vard)
            {
                double kursas;
                int doleriai, centai;
                using (StreamReader reader = new StreamReader(fp))
                {
                    string line;
                    line = reader.ReadLine();
                    string[] parts;
                    vard = line;
                    line = reader.ReadLine();
                    n = int.Parse(line);
                    for (int i = 0; i < n; i++)
                    {
                        line = reader.ReadLine();
                        parts = line.Split(';');
                        doleriai = int.Parse(parts[0]);
                        centai = int.Parse(parts[1]);
                        kursas = double.Parse(parts[2]);
                        P[i] = new Pinigai(doleriai, centai, kursas);

                    }


                }

            }

            static void SpausdintiDuomenis(string fp, Pinigai[] P, int kiekis, string vard)
            {

                Console.WriteLine("\n{0}", vard);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("|  Doleriai  |  Centai  | Kursas  |");
                Console.WriteLine("-----------------------------------");
                for (int i = 0; i < kiekis; i++)
                {
                    Console.WriteLine("|{0,12}|{1, 10}|{2, 9}|", P[i].ImtiDolerius(), P[i].ImtiCentus(), P[i].ImtiKursa());
                }

                Console.WriteLine("-----------------------------------");

            }

            static double Pervertimas(string fp, Pinigai[] P, int kiekis)
            {
                double suma;
                suma = 0.0;
                for (int i = 0; i < kiekis; i++)
                {
                    suma = suma + (P[i].ImtiDolerius() + ((double)P[i].ImtiCentus() / 100)) * P[i].ImtiKursa();
                    
                }
                return suma;
            }

            
        }
    }
}
