using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace S_01
{
    /* 
     Klasė dviračio duomenims saugotis
    @class Dviratis 
    */ 

    class Dviratis
    {
        private int metai;  //pagaminimo metai
        private double kaina; //piniginė vertė
        private int kiek;
        private string pav;
        

        public Dviratis(string pav, int kiek, int metai, double kaina)
        {
            this.metai = metai; 
            this.kaina = kaina;
            this.kiek = kiek;
            this.pav = pav;
        }

        public void PapildytiKiek(int k) { kiek = kiek + k; }

        public int ImtiMetus() { return metai; }
        public double ImtiKaina() { return kaina; }
        public int ImtiKiek() { return kiek; }
        public string ImtiPav() { return pav; }



    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd1 = "..\\..\\Nuoma1.txt";
        const string CFd2 = "..\\..\\Nuoma2.txt";
        const string CFrez = "..\\..\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Dviratis[] D1 = new Dviratis[Cn];
            int n1;   // lygus n  - dviraciu kiekis, antra eilute is failo
            //int am1;  // lygus m kuris yra lygus pirmai eilutei is failo - kritinis dviraciu naudojimo amzius
            string pav1;
            //int kiekTinka1, kiekNetinka1;
            //double sumaTinka1, sumaNetinka1;

            Dviratis[] D2 = new Dviratis[Cn];
            int n2;
            //int am2;
            string pav2;
            //int kiekTinka2, kiekNetinka2; // tinkamu dviraciu kiekis - bus lygus paimtam skaiciui is intervalo
            //double sumaTinka2, sumaNetinka2;  // tinkamu dviraciu suma   - bus lygus sumai is intervalo
            Skaityti(CFd1, D1, out n1, out pav1);
            Skaityti(CFd2, D2, out n2, out pav2);
            //SpausdintiLentele(CFd1, D1, n1, am1, pav1);
            //SpausdintiLentele(CFd2, D2, n2, am2, pav2);

            Console.WriteLine("Pirmas nuomos punktas: {0}", pav1);
            Console.WriteLine("Dviračių kiekis {0}\n", n1);
            Console.WriteLine("Pavadinimas Kiekis Pagaminimo metai Kaina");
            for (int i = 0; i < n1; i++)
                Console.WriteLine("{0,-12} {1,4:d} {2,3:d} {3, 7:f2}",
                D1[i].ImtiPav(), D1[i].ImtiKiek(),
                D1[i].ImtiMetus(), D1[i].ImtiKaina());
            Console.WriteLine();

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            SpausdintiDuomenis(CFrez, D1, n1, pav1);
            SpausdintiDuomenis(CFrez, D2, n2, pav2);


            int ind1 = Seniausias(D1, n1);
            int ind2 = Seniausias(D2, n2);
            using (var fr = File.AppendText(CFrez))
            {
                if (D1[ind1].ImtiMetus() < D2[ind2].ImtiMetus())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0} ", pav1);
                else if (D1[ind1].ImtiMetus() > D2[ind2].ImtiMetus())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0} ", pav2);
                else fr.WriteLine("Seniausias dviratis yra abiejuose punktuose");
            }

            Dviratis[] Dr = new Dviratis[Cn];
            int nr;
            nr = 0;
            Formuoti(D1, n1, Dr, ref nr);
            Formuoti(D2, n2, Dr, ref nr);
            SpausdintiDuomenis(CFrez, Dr, nr, "Modelių sąrašas");


            int indBrangiausias1 = Brangiausias(D1, n1);
            int indBrangiausias2 = Brangiausias(D2, n2);

            using (var fr = File.AppendText(CFrez))
            {
                if (D1[indBrangiausias1].ImtiKaina() < D2[indBrangiausias2].ImtiKaina())
                    fr.WriteLine("Brangiausias dviratis yra nuomos punkte {0}\nDviracio kaina {1}", pav2, D2[indBrangiausias2].ImtiKaina());
                else if (D1[indBrangiausias1].ImtiKaina() > D2[indBrangiausias2].ImtiKaina())
                    fr.WriteLine("Brangiausias Dviratis yra nuomos punkte {0}\nDviracio kaina {1}", pav1, D1[indBrangiausias1].ImtiKaina());
                else fr.WriteLine("Brangiausi dviraciai abiejuose punktuose kainuoja vienodai");
            }    
            

            //Pinigai(D1, n1, 0, am1, 2025, out kiekTinka1, out sumaTinka1);  //pasaukia metoda su // 0 - amziaus pradzia , am (15) kritinio amziaus pabaiga, dabartiniais metais
            //Pinigai(D2, n2, 0, am2, 2025, out kiekTinka2, out sumaTinka2);
            //int bendrasKiekTinka = kiekTinka1 + kiekTinka2; 
            //double bendraSumaTinka = sumaTinka1 + sumaTinka2;
            //Console.WriteLine("Tinkami naudoti: {0, 3:d}\nDviraciu verte: {1,7:f2}\n", bendrasKiekTinka, bendraSumaTinka);


            //Pinigai(D1, n1, am1 + 1, 1000, 2025, out kiekNetinka1, out sumaNetinka1);
            //Pinigai(D2, n2, am2 + 1, 1000, 2025, out kiekNetinka2, out sumaNetinka2);
            //int bendraKiekNetinka = kiekNetinka1 + kiekNetinka2;
            //double bendraSumaNetinka = sumaNetinka1 + sumaNetinka2;
            //Console.WriteLine("Netinkami naudoti: {0, 3:d}\nDviraciu verte: {1,7:f2}\n", bendraKiekNetinka, bendraSumaNetinka);


            //double vidurkisTinka1 = Vidurkis(D1, n1, 2025, 0, am1);
            //double vidurkisTinka2 = Vidurkis(D2, n2, 2025, 0, am2);
            //double bendrasTinkaVidurkis = vidurkisTinka1 + vidurkisTinka2;
            //if (vidurkisTinka1 != 0 && vidurkisTinka2 != 0)
            //{
            //    bendrasTinkaVidurkis = bendrasTinkaVidurkis / 2;
            //}
            //if (bendrasTinkaVidurkis > 0)
            //    Console.WriteLine("Tinkamų naudoti dviračių vidutinis amžius: {0,7:f2}",
            //            bendrasTinkaVidurkis);
            //else Console.WriteLine("Tinkamų naudoti dviračių nėra");



            //double vidurkisNetinka1 = Vidurkis(D1, n1, 2025, am1 + 1, 1000);
            //double vidurkisNetinka2 = Vidurkis(D2, n2, 2025, am2 + 1, 1000);
            //double bendrasVidurkisNetinka = vidurkisNetinka1 + vidurkisNetinka2;
            //if (vidurkisNetinka1 != 0 && vidurkisNetinka2 != 0)
            //{
            //    bendrasVidurkisNetinka = bendrasVidurkisNetinka / 2;
            //}

            //if (bendrasVidurkisNetinka > 0)
            //    Console.WriteLine("Netinkamų naudoti dviračių " +
            //            "vidutinis amžius: {0,7:f2}\n", bendrasVidurkisNetinka);
            //else Console.WriteLine("Netinkamų naudoti dviračių nėra\n");

            //if (kiekTinka1 > kiekTinka2)
            //{
            //    Console.WriteLine("Daugiau tinkamu yra 1 punkte - {0} dviraciai", kiekTinka1);
            //}
            //else Console.WriteLine("Daugiau tinkamu yra 2 punkte - {0} dviraciai", kiekTinka2);

            //double suma1 = sumaTinka1 + sumaNetinka1;
            //double suma2 = sumaTinka2 + sumaNetinka2;

            //if (suma1 > suma2)
            //{
            //    Console.WriteLine("Didesnė piniginė vertė yra 1 punkte - {0} eurai", suma1);
            //}
            //else Console.WriteLine("Didesnė piniginė vertė yra 2 punkte - {0} eurai", suma2);

            //double visiSuma;
            //int visiKiekis;
            //double visiAmziausVidurkis = Vidurkis(D1, n1, 2025, 0, am1);
            //Pinigai(D1, n1, 0, am1, 2025, out visiKiekis, out visiSuma);

            //Console.WriteLine("Visų dviračių vidutinis amžius ir piniginė suma: " +
            //    "{0, 3:f2} {1,7:f2}\n", visiAmziausVidurkis, visiSuma);

            //int pagalMetus = 2008;
            //double pagalMetusSuma;
            //int pagalMetusKiekis;
            //double pagalMetusAmzius = Vidurkis(D, n, 2025, 2025 - pagalMetus, 2025 - pagalMetus);

            //Pinigai(D, n, 2025 - pagalMetus, 2025 - pagalMetus, 2025, out pagalMetusKiekis, out pagalMetusSuma);

            //Console.WriteLine("Dviraciu pagamintu {0, 2:d} piniginė vertė ir vidutinis amžius: " +
            //    "{1, 2:f2} {2, 2:f2}",pagalMetus, pagalMetusSuma, pagalMetusAmzius);


            //int hipotetiniaiMetai = 1000;
            //double hipotetiniuSuma;
            //int hipotetiniuKiekis;
            //double hipotetiniuAmzius = Vidurkis(D, n, 2025, 2025 - hipotetiniaiMetai, 2025 - hipotetiniaiMetai);

            //Pinigai(D, n, 2025 - hipotetiniaiMetai, 2025 - hipotetiniaiMetai, 2025, out hipotetiniuKiekis, out hipotetiniuSuma);
            //if (hipotetiniuKiekis > 0)
            //{
            //    Console.WriteLine("Dviraciu pagamintu {0, 2:d} metais piniginė vertė ir vidutinis amžius: " +
            //   "{1, 2:f2} {2, 2:f2}", hipotetiniaiMetai, hipotetiniuSuma, hipotetiniuAmzius);
            //}
            //else Console.WriteLine("Dviračių pagamintų {0, 2:d} metais nėra\n", hipotetiniaiMetai);




            Console.WriteLine("Programa baigė darba!");
        }
        //static void SpausdintiLentele(string fv , Dviratis[] D, int n,  int m, string pav)
        //{
        //    Console.WriteLine("|  {0}  ", pav);
        //    Console.WriteLine("|--------------------------|");
        //    Console.WriteLine("|Pagaminimo metai |  Kaina |");
        //    Console.WriteLine("|--------------------------|");
        //    for (int i = 0; i < n; i++)
        //        Console.WriteLine("|{0}             | {1, 7:f2}|",
        //       D[i].ImtiMetus(), D[i].ImtiKaina());
        //    Console.WriteLine("|--------------------------|");
        //    Console.WriteLine();
        //}


        //static double Vidurkis(Dviratis[] D, int n, int metai, int amPr, int amPb)
        //{
        //    int kiek = 0, suma = 0;      // suma - suma metais
        //    int amzius;
        //    for(int i = 0; i < n; i++)
        //    {
        //        amzius = metai - D[i].ImtiMetus();
        //        if ((amPr <= amzius) && (amzius <= amPb))  //jeigu amzius didesnis uz amziaus intervalo pradzia,
        //                                                   //ir jeigu amzius mazesnis uz amziaus intervalo pabaiga
        //        {
        //            suma = suma + amzius; // suma 
        //            kiek++;
        //        }
        //    }
        //    if (kiek > 0) return (double) suma / kiek;
        //    return 0.0;
        //}


        //static void Pinigai(Dviratis[] D, int n, int amPr, int amPb, int metai, out int kiek, out double suma)
        //{
        //    kiek = 0;
        //    suma = 0.0;
        //    int amzius;
        //    for (int i = 0; i < n; i++)
        //    {
        //        amzius = metai - D[i].ImtiMetus();
        //        if ((amPr <= amzius) && (amzius <= amPb))
        //        {
        //            suma = suma + D[i].ImtiKaina();
        //            kiek++;
        //        }
        //    }
        //}

        static void SpausdintiDuomenis(string fv, Dviratis[] D, int nkiek, string pav)
        {
            const string virsus =
                        "----------------------------------------------------------\r\n"
                        + "| Pavadinimas | Kiekis | Pagaminimo metai | Kaina "
                        + "(eurų) |";

            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\nNuomos firma: {0}", pav);
                fr.WriteLine(virsus);
                Dviratis tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = D[i];
                    fr.WriteLine("| {0,-12}| {1,6} | {2,16:d} | {3,12:F2} |",
                    tarp.ImtiPav(), tarp.ImtiKiek(),
                    tarp.ImtiMetus(), tarp.ImtiKaina());
                }
                fr.WriteLine("----------------------------------------------------------\n");
            }

        }
        static void Skaityti(string fv, Dviratis[] D, out int n, out string pav)
        {

            using (StreamReader reader = new StreamReader(fv))
            {
                int metai; double kaina; string eil; int kiek;
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    eil = parts[0];
                    kiek = int.Parse(parts[1]);
                    metai = int.Parse(parts[2]);
                    kaina = double.Parse(parts[3]);
                    D[i] = new Dviratis(eil, kiek, metai, kaina);

                }
            }
            
        }


        static int Seniausias(Dviratis[] D, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                if (D[i].ImtiMetus() < D[k].ImtiMetus())
                    k = i;
            return k;
        }
        static int Brangiausias(Dviratis[] D, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                if (D[i].ImtiKaina() > D[k].ImtiKaina())
                    k = i;
            return k;
        }

        static int YraModelis(Dviratis[] D, int n, string pav, int metai)
        {
            for (int i = 0; i < n; i++)
                if (D[i].ImtiPav() == pav && D[i].ImtiMetus() == metai) return i;  //paduoda tam tikra modeli is rinkinio (pasirinkto) ir patikrina, jeigu pirmas sutampa su pirmu, grazina kelintas modelis tai yra . jeigu yra 4 modeliai tai grazina 0,1,2,3
            return -1;

        }

        static void Formuoti(Dviratis[] D, int n, Dviratis[] Dr, ref int nr)  // dr yra naujas rinkinys (bendras) nr - objektu skaicius (dviraciu skaicius) dr rinkinyje 
        {
            int k;
            for (int i = 0; i < n; ++i)  //loopina per kiekviena pasirinkto masyvo modeli pvz D1 
            {   // k yra lygus naujo masyvo Dr ir jo modeliu sk. , ir tikrinama, ar pasirinkto masyvo D loopinant nuo modelio 0 iki x jau egzistuoja Dr masyve,
                k = YraModelis(Dr, nr, D[i].ImtiPav(), D[i].ImtiMetus());   //nusiunciamas pats pirmas indeksinis is masyvo D1 / D2, o tikrinama ar yra masyve Dr(praloopina per kiekviena Dr modeli)
                if (k >= 0)
                    Dr[k].PapildytiKiek(D[i].ImtiKiek());  //papildo jeigu Dr jau turi ta modeli- padidina kieki jeigu metai ir modelis sutampa

                else //prideda nauja modeli jeigu Dr masyvas neturi tokios reiksmes     -- pvz si else bus naudojama pirmam masyvui jeigu reiksmes keisis
                // o antram masyvui gali buti naudojama if , nes ji jau gali tureti sias naujas reiksmes
                //
                {
                    Dr[nr] = D[i];
                    nr++;
                }
            }
        }




    }
}
