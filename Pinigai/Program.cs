
using System;
using System.IO;

namespace ind1
{
    class Valiuta
    {
        private int eurai;
        private int centai;
        private double kursas;

        public Valiuta()
        {
        }

        public Valiuta(int eurai, int centai, double kursas)
        {
            this.eurai = eurai;
            this.centai = centai;
            this.kursas = kursas;
        }

        public int ImtiEurus()
        {
            return eurai;
        }

        public int ImtiCentus()
        {
            return centai;
        }

        public double ImtiKursą()
        {
            return kursas;
        }
    }

    internal class Program
    {
        const string FAILASA = "../../A.txt";
        const string FAILASB = "../../B.txt";
        const int ILGIS = 100;

        static void Main(string[] args)
        {
            Valiuta[] barbora = new Valiuta[ILGIS];
            SkaitytiFailą(FAILASB, barbora, out int masyvoDydis);

            SpausdintiLentelę("Barbora", barbora, masyvoDydis);
            double barborosSuma = SkaičiuotiPinigus(barbora, masyvoDydis);

            Valiuta[] anupras = new Valiuta[ILGIS];
            SkaitytiFailą(FAILASA, anupras, out masyvoDydis);

            SpausdintiLentelę("Anupras", anupras, masyvoDydis);
            double anuproSuma = SkaičiuotiPinigus(anupras, masyvoDydis);

            Console.WriteLine();
            Console.WriteLine("Barboros pinigai: {0,6:f2} eurų", barborosSuma);
            Console.WriteLine("Anupro pinigai: {0,6:f2} eurų", anuproSuma);
            Console.WriteLine("Viso pinigų: {0,6:f2} eurų", barborosSuma + anuproSuma);
        }

        static void SkaitytiFailą(string failoKelias, Valiuta[] masyvas, out int eilučių)
        {
            using (StreamReader srautas = new StreamReader(failoKelias))
            {
                eilučių = int.Parse(srautas.ReadLine());

                string eilutė;
                for (int i = 0; i < eilučių; i++)
                {
                    eilutė = srautas.ReadLine();
                    string[] dalys = eilutė.Split();

                    int eurai = int.Parse(dalys[0]);
                    int centai = int.Parse(dalys[1]);
                    double kursas = double.Parse(dalys[2]);

                    masyvas[i] = new Valiuta(eurai, centai, kursas);
                }
            }
        }

        static double SkaičiuotiPinigus(Valiuta[] masyvas, int masyvoDydis)
        {
            double suma = 0;

            for (int i = 0; i < masyvoDydis; i++)
            {
                suma += (masyvas[i].ImtiEurus() + masyvas[i].ImtiCentus() / 100.0) * masyvas[i].ImtiKursą();
            }
            return suma;
        }

        static void SpausdintiLentelę(string vardas, Valiuta[] masyvas, int masyvoDydis)
        {
            Console.WriteLine();
            Console.WriteLine(vardas);
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Eurai | Centai | Kursas   |");
            Console.WriteLine("------------------------------");
            for (int i = 0; i < masyvoDydis; i++)
            {
                int eurai = masyvas[i].ImtiEurus();
                int centai = masyvas[i].ImtiCentus();
                double kursas = masyvas[i].ImtiKursą();

                Console.WriteLine("| {0,5} | {1,6} | {2,8:f} |", eurai, centai, kursas);
            }
            Console.WriteLine("------------------------------");
        }
    }
}