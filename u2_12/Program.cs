//IFD-5/1_Undzėnas_Ernestas_U2-12
//U2-12. Kepyklėlė
//UŽDUOTIS: Kepyklėlėje kepamų pyragaičių duomenys yra faile: pavadinimas,
//dešimčiai vienetų pagaminti reikalingų kiaušinių kiekis, miltų kiekis
//ir kitų priedų kiekis. Pirmoje eilutėje yra kepyklėlės pavadinimas.
//Sukurkite klasę Pyragas pyragaičio duomenims saugoti. Raskite, kuriai
//pyragaičių rūšiai iškepti reikia mažiausiai kiaušinių ir kurios rūšies
//pyragaičiai sunkiausi (miltų ir kitų priedų kiekis). Jei yra kelios,
//spausdinkite visas.
//• Papildykite programą veiksmais su dviejų kepyklėlių pyragaičių rinkiniais.
//Kiekvienos kepyklėlės pyragaičių duomenys saugomi atskiruose failuose.
//Kuriame sąraše yra pyragaitis, kuriam iškepti reikia daugiausia kiaušinių?
//Jei abiejuose, spausdinkite abu. Surašykite į atskirą rinkinį visus abiejų
//sąrašų pyragaičius, kurie yra vidutinio svorio (miltų ir kitų priedų kiekis),
//duomenis. Vidutinis pyragaičio svoris tas, kurio svoris skiriasi nuo visų
//kepinių aritmetinio vidurkio ne daugiau, kaip 10 proc.


using System;
//---------------------------------------------------------
using System.IO; // reikalinga skaitymui iš failo (StreamReader)

namespace u2_12
{
    /// <summary>
    /// Klasė pyragų duomenims aprašyti
    /// </summary>
    class Pyragas
    {
        string pavadinimas; //pyrago pavadinimas
        int kiausiniai, miltai, kitiPried; //pyrago ingredientai

        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="pavadinimas">Pavadinimas</param>
        /// <param name="kiausiniai">Kiausiniu kiekis</param>
        /// <param name="miltai">Miltu kiekis</param>
        /// <param name="kitiPried">Kitu priedu kiekis</param>
        public Pyragas(string pavadinimas,
            int kiausiniai,
            int miltai,
            int kitiPried)
        {
            this.pavadinimas = pavadinimas;
            this.kiausiniai = kiausiniai;
            this.miltai = miltai;
            this.kitiPried = kitiPried;
        }

        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public Pyragas()
        {
            pavadinimas = "Pyragaitis";
            kiausiniai = 10;
            miltai = 1000;
            kitiPried = 500;
        }

        /// <summary>
        /// Grąžina pyrago pavadinimą
        /// </summary>
        /// <returns>Pavadinimą</returns>
        public string ImtiPavadinimas()
        {
            return pavadinimas;
        }

        /// <summary>
        /// Grąžina kiaušinių kiekį
        /// </summary>
        /// <returns>Kiaušinių kiekį</returns>
        public int ImtiKiausiniai()
        {
            return kiausiniai;
        }

        /// <summary>
        /// Grąžina miltų kiekį
        /// </summary>
        /// <returns>Miltų kiekis</returns>
        public int ImtiMiltai()
        {
            return miltai;
        }

        /// <summary>
        /// Grąžina kitų priedų kiekį
        /// </summary>
        /// <returns>Kiti priedai</returns>
        public int ImtiKitiPried()
        {
            return kitiPried;
        }
    }

    /// <summary>
    /// Klasė užduotyje nurodytiems skaičiavimas atlikti
    /// </summary>
    internal class Program
    {
        const int CD = 100; //maksimalus pyragų kiekis rinkinyje

        const string
            CFd1 = "..\\..\\Duomenys1.txt"; //1-os kepyklos duomenų failo vardas

        const string
            CFd2 = "..\\..\\Duomenys2.txt"; //2-os kepyklos duomenų failo vardas

        const string CFrez = "..\\..\\Rezultatai.txt"; //rezultatų failo vardas


        static void Main(string[] args)
        {
            Pyragas[]
                pyragaitis1 = new Pyragas[CD]; //1-os kepyklos duomenų masyvas
            int pyragaiciuKiekisFaile1; //1-os kepyklos pyragų skaičius
            string kepyklelesPavadinimas1; //1-os kepyklos pavadinimas

            Pyragas[]
                pyragaitis2 = new Pyragas[CD]; //2-os kepyklos duomenų masyvas
            int pyragaiciuKiekisFaile2; //2-os kepyklos pyragų skaičius
            string kepyklelesPavadinimas2; //2-os kepyklos pavadinimas



            //Rezultatų failo išvalymas
            if (File.Exists(CFrez))
                File.Delete(CFrez);

            // --- Veiksmai su 1 ir 2 kepyklomis
            Skaityti(CFd1, pyragaitis1, out pyragaiciuKiekisFaile1,
                out kepyklelesPavadinimas1);
            Skaityti(CFd2, pyragaitis2, out pyragaiciuKiekisFaile2,
                out kepyklelesPavadinimas2);

            if (pyragaiciuKiekisFaile1 <= 0)
            {
                Console.WriteLine("Objektų rinkinys - {0} neturi duomenų!!!", kepyklelesPavadinimas1);
                return;
            } else if (pyragaiciuKiekisFaile2 <= 0)
            {
                Console.WriteLine("Objektų rinkinys - {0} neturi duomenų!!!", kepyklelesPavadinimas2);
                return;
            }

             Spausdinti(CFrez, pyragaitis1, pyragaiciuKiekisFaile1,
                    kepyklelesPavadinimas1);
            Spausdinti(CFrez, pyragaitis2, pyragaiciuKiekisFaile2,
                kepyklelesPavadinimas2);

            //---- Naujo rinkinio (sunkiausių pyragaičių) formavimas
            Pyragas[] sunkiausiPyragaiciai = new Pyragas[CD];
            int sKiekis = 0;

            //---- Naujo rinkinio (mažiausiai kiaušinių turinčiu pyragaičių) formavimas
            Pyragas[] mazKiausiniuPyragaitis = new Pyragas[CD];
            int mKiekis = 0;

            //---- Naujo rinkinio (vidutinio svorio pyragaičių) formavimas
            Pyragas[] vidutinioSvorioPyragaiciai = new Pyragas[CD];
            int vKiekis = 0;


            //---- Rinkinio (mažiausiai kiaušinių turinčiu pyragaičių) papildymas
            int maziausiaiKiausiniu1 =
                RastiMazKiausiniu(pyragaitis1, pyragaiciuKiekisFaile1);
            //int maziausiaiKiausiniu2 =
            //    RastiMazKiausiniu(pyragaitis2, pyragaiciuKiekisFaile2);

            MaziausiaiKiausiniu(pyragaitis1, pyragaiciuKiekisFaile1,
                mazKiausiniuPyragaitis, ref mKiekis, maziausiaiKiausiniu1);
            Spausdinti(CFrez, mazKiausiniuPyragaitis, mKiekis,
                "Maziausiai kiausiniu - 1 kepykleles");
            //MaziausiaiKiausiniu(pyragaitis2, pyragaiciuKiekisFaile2,
            //    mazKiausiniuPyragaitis, ref mKiekis, maziausiaiKiausiniu2);
            //Spausdinti(CFrez, mazKiausiniuPyragaitis, mKiekis,
            //    "Maziausiai kiausiniu - 2 kepykleles");

            //---- Rinkinio (sunkiausių pyragaičių) papildymas
            int didSvoris1 =
                RastiSunkiausia(pyragaitis1, pyragaiciuKiekisFaile1);
            //int didSvoris2 =
            //    RastiSunkiausia(pyragaitis2, pyragaiciuKiekisFaile2);

            SunkiausiaRusis(pyragaitis1, pyragaiciuKiekisFaile1,
                sunkiausiPyragaiciai, ref sKiekis, didSvoris1);
            Spausdinti(CFrez, sunkiausiPyragaiciai, sKiekis,
                "Sunkiausias(i) - 1 kepykleles");
            //SunkiausiaRusis(pyragaitis2, pyragaiciuKiekisFaile2,
            //    sunkiausiPyragaiciai, ref sKiekis, didSvoris2);
            //Spausdinti(CFrez, sunkiausiPyragaiciai, sKiekis,
            //    "Sunkiausias(i) - 2 kepykleles");

            //---- Patikrinimo kuri kepykla turi pyragaitį su daugiausia kiaušinių
            int daugiausiaiKiausiniu1 = DaugiausiaiKiausiniu(pyragaitis1,
                pyragaiciuKiekisFaile1);
            int daugiausiaiKiausiniu2 = DaugiausiaiKiausiniu(pyragaitis2,
                pyragaiciuKiekisFaile2);
            using (var fr = File.AppendText(CFrez))
            {
                if (pyragaitis1[daugiausiaiKiausiniu1].ImtiKiausiniai() >
                    pyragaitis2[daugiausiaiKiausiniu2].ImtiKiausiniai())
                    fr.WriteLine(
                        "\n{0} turi daugiausiai kiausiniu sudetyje turinti pyragaiti - "
                        +
                        "\n{1} - {2} kiausiniu",
                        kepyklelesPavadinimas1,
                        pyragaitis1[daugiausiaiKiausiniu1].ImtiPavadinimas(),
                        pyragaitis1[daugiausiaiKiausiniu1].ImtiKiausiniai()
                    );
                else if (pyragaitis2[daugiausiaiKiausiniu2].ImtiKiausiniai() >
                         pyragaitis1[daugiausiaiKiausiniu1].ImtiKiausiniai())
                    fr.WriteLine(
                        "\n{0} turi daugiausiai kiausiniu sudetyje turinti pyragaiti - "
                        +
                        "\n{1} - {2} kiausiniu",
                        kepyklelesPavadinimas2,
                        pyragaitis2[daugiausiaiKiausiniu2].ImtiPavadinimas(),
                        pyragaitis2[daugiausiaiKiausiniu2].ImtiKiausiniai()
                    );
                else
                    fr.WriteLine(
                        "\nAbiejuose kepyklelese yra pyragaiciai su daugiausiai "
                        +
                        "kiausiniu\n" +
                        "{0} - {1} - {2} kiausiniai\n{3} - {4} - {5} kiausiniai",
                        kepyklelesPavadinimas1,
                        pyragaitis1[daugiausiaiKiausiniu1].ImtiPavadinimas(),
                        pyragaitis1[daugiausiaiKiausiniu1].ImtiKiausiniai(),
                        kepyklelesPavadinimas2,
                        pyragaitis2[daugiausiaiKiausiniu2].ImtiPavadinimas(),
                        pyragaitis2[daugiausiaiKiausiniu2].ImtiKiausiniai());
            }


            //---- Rinkinio (vidutinio svorio pyragaičių) papildymas
            double vidurkis1 = Math.Round(Svoris(pyragaitis1, pyragaiciuKiekisFaile1), 0);
            double vidurkis2 = Math.Round(Svoris(pyragaitis2, pyragaiciuKiekisFaile2), 0);
            double bendrasVidurkis = Math.Round((vidurkis1 + vidurkis2) / 2, 0);

            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine(
                    "\n{0}g yra pyragaiciu svorio aritmetinis vidurkis\n" +
                    "Pyragaiciai kuriu bendras svoris yra nuo {1}g - {2}g yra " +
                    "vidutinio svorio",
                    bendrasVidurkis, Math.Round((bendrasVidurkis * 0.9), 0),
                    Math.Round((bendrasVidurkis * 1.1), 0));
            }


            VidutinisSvoris(pyragaitis1, pyragaiciuKiekisFaile1,
                vidutinioSvorioPyragaiciai, ref vKiekis, bendrasVidurkis);
            VidutinisSvoris(pyragaitis2, pyragaiciuKiekisFaile2,
                vidutinioSvorioPyragaiciai, ref vKiekis, bendrasVidurkis);
            Spausdinti(CFrez, vidutinioSvorioPyragaiciai, vKiekis,
                "Pyragaiciai kurie vidutinio svorio abiejuose");

            //---- Patikrinimas, jeigu rezultatų failas egzistuoja, tai
            //atspausdinamas tekstas
            if (File.Exists(CFrez))
                Console.WriteLine(
                    "Rezultatai atspausdinti i faila - rezultatai.txt");
            Console.WriteLine("\nPrograma baige darba!");
        }

        /// <summary>
        /// Skaito duomenis iš failo
        /// </summary>
        /// <param name="failoPavadinimas">Duomenų failo pavadinimas</param>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <param name="kepyklelesPavadinimas">Kepyklos pavadinimas rinkinyje</param>
        static void Skaityti(string failoPavadinimas,
            Pyragas[] pyragaitis,
            out int pyragaiciuKiekis,
            out string kepyklelesPavadinimas)
        {
            using (StreamReader reader = new StreamReader(failoPavadinimas))
            {
                string pyragaicioPavadinimas;
                int kiausiniuKiekis, miltuKiekis, kituPrieduKiekis;
                string line; //duomenų failo eilutė
                line = reader.ReadLine();
                string[] parts;
                kepyklelesPavadinimas = line;
                //line = reader.ReadLine();
                //pyragaiciuKiekis = int.Parse(line);
                int i = 0;
                int Cn = 100;
                while ((line = reader.ReadLine()) != null && (i < Cn))
                {
                    parts = line.Split(';');
                    pyragaicioPavadinimas = parts[0];
                    kiausiniuKiekis = int.Parse(parts[1]);
                    miltuKiekis = int.Parse(parts[2]);
                    kituPrieduKiekis = int.Parse(parts[3]);
                    pyragaitis[i] = new Pyragas(pyragaicioPavadinimas,
                        kiausiniuKiekis, miltuKiekis, kituPrieduKiekis);
                    i++;
                }
                pyragaiciuKiekis = i;
            }
        }

        /// <summary>
        /// Spausdina pyragų rinkinio duomenis lentele faile
        /// </summary>
        /// <param name="failoPavadinimas">Rezultatų failo vardas</param>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <param name="kepyklelesPavadinimas">Kepyklos pavadinimas rinkinyje</param>
        static void Spausdinti(string failoPavadinimas,
            Pyragas[] pyragaitis,
            int pyragaiciuKiekis,
            string kepyklelesPavadinimas)

        {
            const string virsus =
                "|---------------------------------------------" +
                "--------------------------------|\n" +
                "|Eil. nr.| Pavadinimas | Kiausiniai " +
                "| Miltai(g) | Kitu priedai(g) | Svogis(g) |\n" +
                "|---------------------------------------------" +
                "--------------------------------|";

            const string apacia =
                "|---------------------------------------------" +
                "--------------------------------|";

            using (var fr = File.AppendText(failoPavadinimas))
            {
                fr.WriteLine("\n{0}", kepyklelesPavadinimas);
                fr.WriteLine(virsus);
                for (int i = 0; i < pyragaiciuKiekis; i++)
                {
                    fr.WriteLine(
                        "|{0, 8}|{1,13}|{2, 12}|{3, 11}|{4, 17}|{5, 11}|",
                        i + 1,
                        pyragaitis[i].ImtiPavadinimas(),
                        pyragaitis[i].ImtiKiausiniai(),
                        pyragaitis[i].ImtiMiltai(),
                        pyragaitis[i].ImtiKitiPried(),
                        pyragaitis[i].ImtiMiltai() +
                        pyragaitis[i].ImtiKitiPried());
                }

                fr.WriteLine(apacia);
            }
        }


        /// <summary>
        /// Suskaičiuoja kuris pyragaitis rinkinyje turi daugiausiai kiaušinių
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <returns>Pyragą(us) su daugiausiai kiaušinių</returns>
        static int DaugiausiaiKiausiniu(Pyragas[] pyragaitis,
            int pyragaiciuKiekis)
        {
            int k = 0;
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                if (pyragaitis[i].ImtiKiausiniai() >
                    pyragaitis[k].ImtiKiausiniai())
                {
                    k = i;
                }
            }

            return k;
        }

        /// <summary>
        /// Suskaičiuoja kuris pyragaitis rinkinyje turi mažiausiai kiaušinių
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <returns>Pyragą(us) su mažiausiai kiaušinių</returns>
        static int RastiMazKiausiniu(Pyragas[] pyragaitis,
            int pyragaiciuKiekis)
        {
            int minKiausiniai = pyragaitis[0].ImtiKiausiniai();
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                int kiausiniai = pyragaitis[i].ImtiKiausiniai();
                if (kiausiniai < minKiausiniai)
                {
                    minKiausiniai = kiausiniai;
                }
            }

            return minKiausiniai;
        }

        /// <summary>
        /// Suformuoja naują rinkinį pagal mažiausiai kiaušinių
        /// turinčius kepyklos pyragaičius
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <param name="maziausiaiKiausiniu">Objektų rinkinys su mažiausiai
        /// kiaušinių turintys pyragačiai</param>
        /// <param name="n">Naujojo rinkinio maksimalus pyragų kiekis</param>
        /// <param name="minKiausiniai">Skaičius kiek turi esamas mažiausiai
        /// kiaušinių turintis pyragaitis</param>
        static void MaziausiaiKiausiniu(Pyragas[] pyragaitis,
            int pyragaiciuKiekis,
            Pyragas[] maziausiaiKiausiniu,
            ref int n,
            int minKiausiniai)

        {
            n = 0;
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                int kiausiniai = pyragaitis[i].ImtiKiausiniai();
                if (kiausiniai == minKiausiniai)
                {
                    maziausiaiKiausiniu[n] = pyragaitis[i];
                    n++;
                }
            }
        }


        /// <summary>
        /// Suskaičiuoja kuris pyragaitis rinkinyje yra sunkiausias
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <returns>Pyragaičio svorį gramais</returns>
        static int RastiSunkiausia(Pyragas[] pyragaitis,
            int pyragaiciuKiekis)
        {
            int maxSvoris = 0;
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                int svoris = pyragaitis[i].ImtiMiltai() +
                             pyragaitis[i].ImtiKitiPried();
                if (svoris > maxSvoris)
                {
                    maxSvoris = svoris;
                }
            }

            return maxSvoris;
        }

        /// <summary>
        /// Suformuoja naują rinkinį pagal sunkiausia masę iš miltų/kitų
        /// priedų turinčių pyragaičių
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <param name="sunkiausi">Objektų rinkinys su sunkiausiais pyragaičiais</param>
        /// <param name="n">Naujojo rinkinio maksimalus pyragų kiekis</param>
        /// <param name="maxSvoris">Skaičius kiek sveria sunkiausias pyragaitis</param>
        static void SunkiausiaRusis(Pyragas[] pyragaitis,
            int pyragaiciuKiekis,
            Pyragas[] sunkiausi,
            ref int n,
            int maxSvoris)
        {
            n = 0;
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                int svoris = pyragaitis[i].ImtiMiltai() +
                             pyragaitis[i].ImtiKitiPried();
                if ((svoris == maxSvoris))
                {
                    sunkiausi[n] = pyragaitis[i];
                    n++;
                }
            }
        }

        /// <summary>
        /// Suskaičiuoja pasirinktos kepyklos objektų rinkinio vidutinį aritmetinį
        /// svorio vidurkį gramais
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <returns>Aritmetinį svorio vidurkį gramais</returns>
        static double Svoris(Pyragas[] pyragaitis,
            int pyragaiciuKiekis)
        {
            double visuVidurkis = 0;
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                int suma = (pyragaitis[i].ImtiMiltai() +
                            pyragaitis[i].ImtiKitiPried());
                visuVidurkis += suma;
            }

            return visuVidurkis /=  pyragaiciuKiekis;
        }

        /// <summary>
        /// Patikrina ar egzistuoja jau sukurtas pyragaitis objektų rinkinyje
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <param name="pav">Pyragaičio pavadinimas</param>
        /// <returns>Gražina teigiama reikšme jeigu pyragaitis egzisuotuoja</returns>
        static int YraPyragaitis(Pyragas[] pyragaitis,
            int pyragaiciuKiekis,
            string pav)
        {
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                if (pyragaitis[i].ImtiPavadinimas() == pav)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Suformuoja naują rinkinį pyragaičiams kurie telpa į vidutinio svorio
        /// intervalo režes (10% daugiau/mažiau - nei vidutinis svoris) 
        /// </summary>
        /// <param name="pyragaitis">Objektų rinkinys pyragams saugoti</param>
        /// <param name="pyragaiciuKiekis">Pyragų skaičius rinkinyje</param>
        /// <param name="vidutinioSvorio">Rinkinys su vid. svorio pyragaičiais</param>
        /// <param name="n">Naujojo rinkinio maksimalus pyragų kiekis</param>
        /// <param name="bendrasVidurkis">Aritmetinio svorio vidurkio skaičius</param>
        static void VidutinisSvoris(Pyragas[] pyragaitis,
            int pyragaiciuKiekis,
            Pyragas[] vidutinioSvorio,
            ref int n,
            double bendrasVidurkis)
        {
            int k;
            for (int i = 0; i < pyragaiciuKiekis; i++)
            {
                double suma = pyragaitis[i].ImtiMiltai() +
                              pyragaitis[i].ImtiKitiPried();
                if (suma >= bendrasVidurkis * 0.9 &&
                    suma <= bendrasVidurkis * 1.1)
                {
                    k = YraPyragaitis(vidutinioSvorio, n,
                        pyragaitis[i].ImtiPavadinimas());
                    if (k < 0)
                    {
                        vidutinioSvorio[n] = pyragaitis[i];
                        n++;
                    }
                }
            }
        }
    }
}