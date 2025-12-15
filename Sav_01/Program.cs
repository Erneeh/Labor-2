using System;
using System.IO;

class Dviratis
{
    private int kiek;
    private string pav;
    private int metai;
    private double kaina;

    public Dviratis(string pav, int kiek, int metai, double kaina)
    {
        this.pav = pav;
        this.kiek = kiek;
        this.metai = metai;
        this.kaina = kaina;
    }

    public string ImtiPavadinimą() { return pav; }
    public int ImtiKiekj() { return kiek; }
    public int ImtiMetus() { return metai; }
    public double ImtiKainą() { return kaina; }
    public void PapildytiKiekj(int k) { kiek = kiek + k; }
}

class Program
{
    const int Cn = 100;
    const string CFd1 = "..\\..\\Nuoma1.txt";
    const string CFd2 = "..\\..\\Nuoma2.txt";
    const string CFrez = "..\\..\\Rezultatai.txt";

    static void Main(string[] args)
    {
        Dviratis[] D1 = new Dviratis[Cn];
        int n1;
        string pav1;

        Dviratis[] D2 = new Dviratis[Cn];
        int n2;
        string pav2;

        Skaityti(CFd1, D1, out n1, out pav1);
        Skaityti(CFd2, D2, out n2, out pav2);

        if (File.Exists(CFrez))
            File.Delete(CFrez);

        int indBrang1 = Brangiausias(D1, n1);
        int indBrang2 = Brangiausias(D2, n2);
        SpausdintiDuomenis(CFrez, D1, n1, pav1);
        using (var fr = File.AppendText(CFrez))
        {
            fr.WriteLine("Brangiausias dviratis šiame punkte:");
            fr.WriteLine("Modelis: {0}, Kaina: {1:F2} eurų",
                D1[indBrang1].ImtiPavadinimą(), D1[indBrang1].ImtiKainą());
            fr.WriteLine();
        }
        SpausdintiDuomenis(CFrez, D2, n2, pav2);
        using (var fr = File.AppendText(CFrez))
        {
            fr.WriteLine("Brangiausias dviratis šiame punkte:");
            fr.WriteLine("Modelis: {0}, Kaina: {1:F2} eurų",
                D2[indBrang2].ImtiPavadinimą(), D2[indBrang2].ImtiKainą());
            fr.WriteLine();
        }

        



        using (var fr = File.AppendText(CFrez))
        {
            fr.WriteLine("BRANGIAUSIŲ DVIRAČIŲ PAIEŠKA:");
            fr.WriteLine();
            if (D1[indBrang1].ImtiKainą() > D2[indBrang2].ImtiKainą())
            {
                fr.WriteLine("Brangiausias dviratis yra nuomos punkte: {0}", pav1);
                fr.WriteLine("Modelis: {0}", D1[indBrang1].ImtiPavadinimą());
                fr.WriteLine("Pagaminimo metai: {0}", D1[indBrang1].ImtiMetus());
                fr.WriteLine("Kaina: {0:F2} eurų", D1[indBrang1].ImtiKainą());
            }
            else if (D1[indBrang1].ImtiKainą() < D2[indBrang2].ImtiKainą())
            {
                fr.WriteLine("Brangiausias dviratis yra nuomos punkte: {0}", pav2);
                fr.WriteLine("Modelis: {0}", D2[indBrang2].ImtiPavadinimą());
                fr.WriteLine("Pagaminimo metai: {0}", D2[indBrang2].ImtiMetus());
                fr.WriteLine("Kaina: {0:F2} eurų", D2[indBrang2].ImtiKainą());
            }
            else
            {
                fr.WriteLine("Brangiausi dviračiai yra abiejuose punktuose:");
                fr.WriteLine("Punkte {0}: {1}, kaina {2:F2} eurų",
                    pav1, D1[indBrang1].ImtiPavadinimą(), D1[indBrang1].ImtiKainą());
                fr.WriteLine("Punkte {0}: {1}, kaina {2:F2} eurų",
                    pav2, D2[indBrang2].ImtiPavadinimą(), D2[indBrang2].ImtiKainą());
            }
        }

        Console.WriteLine("Programa baigė darbą!");
        Console.WriteLine("Rezultatai išsaugoti faile: {0}", CFrez);
    }

    static void Skaityti(string Fd, Dviratis[] D, out int n, out string pav)
    {
        using (StreamReader reader = new StreamReader(Fd))
        {
            string eil; int kiekn; int metain; double kainan;
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
                kiekn = int.Parse(parts[1]);
                metain = int.Parse(parts[2]);
                kainan = double.Parse(parts[3]);
                D[i] = new Dviratis(eil, kiekn, metain, kainan);
            }
        }
    }

    static void SpausdintiDuomenis(string fv, Dviratis[] D, int nkiek, string pav)
    {

        using (var fr = File.AppendText(fv))
        {
            fr.WriteLine("Nuomos firma: {0}", pav);
            fr.WriteLine("|------------------|--------|--------------|----------|");
            fr.WriteLine("| Pavadinimas      | Kiekis | Pagaminimo   | Kaina    |");
            fr.WriteLine("|                  |        | metai        | (eurų)   |");
            fr.WriteLine("|------------------|--------|--------------|----------|");
            Dviratis tarp;
            for (int i = 0; i < nkiek; i++)
            {
                fr.WriteLine("| {0,-16} | {1,6} | {2,12} | {3,8:F2} |",
                    D[i].ImtiPavadinimą(),
                    D[i].ImtiKiekj(),
                    D[i].ImtiMetus(),
                    D[i].ImtiKainą());
            }
            fr.WriteLine("|------------------|--------|--------------|----------|");
            fr.WriteLine();
        }
    }

   

    static int Brangiausias(Dviratis[] D, int n)
    {
        int k = 0;
        for (int i = 0; i < n; i++)
            if (D[i].ImtiKainą() > D[k].ImtiKainą())
                k = i;
        return k;
    }

    
}