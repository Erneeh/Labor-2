using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dviratis
{
    class Dviratis
    {
        private int metai; // pagaminimo metai
        private double kaina; // piniginė vertė
                              //
        /** Dviračio duomenys
        @param metai - nauja metų reikšmė
        @param kaina - nauja kainos reikšmė */
        //
        public Dviratis(int metai, double kaina)
        {
            this.metai = metai;
            this.kaina = kaina;
        }
        /** grąžina metus */
        public int ImtiMetus() { return metai; }
        /** grąžina dviračio reikšmę */
        public double ImtiKainą() { return kaina; }
    }

    class Program
    {
        static void Skaityti(string fv, Dviratis[] D, out int n, out int m, out string pav)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    metai = int.Parse(parts[0]);
                    kaina = double.Parse(parts[1]);
                    D[i] = new Dviratis(metai, kaina);
                }
            }
        }

    


        const int Cn = 100;
        const string CFd1 = "..\\..\\Duom1.txt";
        const string CFd2 = "..\\..\\Duom2.txt";
        static void Main(string[] args)
        {
            // Pirmojo dviračių nuomos punkto
            Dviratis[] D1 = new Dviratis[Cn]; // dviračių duomenys
            int n1; // dviračių skaičius
            int am1; // dviračio tinkamumo naudoti kritinis amžius
            string pav1; // nuomos punkto pavadinimas
            int kiekTinka1, kiekNetinka1;
            double sumaTinka1, sumaNetinka1;
            // Antrojo dviračių nuomos punkto
            Dviratis[] D2 = new Dviratis[Cn]; // dviračių duomenys
            int n2; // dviračių skaičius
            int am2; // dviračio tinkamumo naudoti kritinis amžius
            string pav2; // nuomos punkto pavadinimas
            int kiekTinka2, kiekNetinka2;
            double sumaTinka2, sumaNetinka2;

            Skaityti(CFd1, D1, out n1, out am1, out pav1);

            Skaityti(CFd2, D2, out n2, out am2, out pav2);
            //
            // I nuomos punktas, kontrolinis spausdinimas
            Console.WriteLine("Pirmas nuomos punktas: {0}", pav1);
            Console.WriteLine("Dviračių kiekis {0}\n", n1);
            Console.WriteLine("Pavadinimas Kiekis Pagaminimo metai Kaina");
            for (int i = 0; i < n1; i++)
                Console.WriteLine("{0,-12} {1,4:d} {2,3:d} {3, 7:f2}",
                D1[i].ImtiPavadinimą(), D1[i].ImtiKiekj(),
                D1[i].ImtiMetus(), D1[i].ImtiKainą());
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }

    }
}
