using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolni22052025_AleksejJuzin_II3
{
    internal class Program
    {

        // made by @yxzhin with <3
        // grupa A

        // 1. osnovna karakteristika vrednosnih tipova je to da cuvaju neposrednu vrednost a ne referensu na nju.
        // 2. u struct-u se koriste vrednosni tipovi, a u class-u referentni.
        // 3. kada dodeljujemo jednu struct promenljivu drugoj kopira se cela neposredna vrednost a ne referensa.
        // 4. da, struktura moze podrazumevati konstruktor.
        // 5. atributi strukture su promenljive koje sadrze podatke te strukture.

        public static Int16 greska(Int16 type_)
        {

            switch (type_)
            {

                case -1: Console.WriteLine("unesite validne vrednosti"); break;
                case -2: Console.WriteLine("index ne postoji"); break;

            }

            return type_;

        }

        public struct Artikal
        {

            public string sifra;
            public string naziv;
            public double cena;
            public int kolicina_na_stanju;
            public bool na_akciji;

            public Artikal(string sifra, string naziv, double cena, int kolicina_na_stanju, bool na_akciji)
            {

                this.sifra = sifra;
                this.naziv = naziv;
                this.cena = cena;
                this.kolicina_na_stanju = kolicina_na_stanju;
                this.na_akciji = na_akciji;

            }

            public double izracunajVrednostZaliha()
            {

                double vrednost_zaliha = this.kolicina_na_stanju * this.cena;

                return vrednost_zaliha;

            }

            public Int16 prikaziInformacije()
            {

                string na_akciji = this.na_akciji ? "da" : "ne";

                Console.WriteLine($"sifra: {this.sifra}");
                Console.WriteLine($"naziv: {this.naziv}");
                Console.WriteLine($"cena: {this.cena:n}");
                Console.WriteLine($"kolicina na stanju: {this.kolicina_na_stanju:n0}");
                Console.WriteLine($"na_akciji: {na_akciji}");

                return 1;

            }

            public bool daLiJeNaAkciji()
            {

                return this.na_akciji;

            }

            public Int16 dodajKolicinu(int dodatak)
            {

                if(dodatak <= 0)
                {

                    greska(type_:-1);
                    return -1;

                }

                this.kolicina_na_stanju += dodatak;

                return 1;

            }

        }

        public static int unesiBrojArtikala()
        {

            while (true)
            {

                Console.WriteLine("unesite kolicinu artikala:");

                if (!int.TryParse(Console.ReadLine(), out int result))
                {

                    greska(type_: -1);
                    continue;

                }

                return result;

            }

        }

        public static void Main(string[] args)
        {

            int kolicina_artikala = unesiBrojArtikala();
            Artikal[] artikli = new Artikal[kolicina_artikala];

            for (int x = 0; x < kolicina_artikala; ++x)
            {

                Console.WriteLine($"\nunesite informaciju za artikal #{x}:\n");

                Console.WriteLine("unesite sifru:");
                string sifra = Console.ReadLine();

                Console.WriteLine("unesite naziv:");
                string naziv = Console.ReadLine();

                double cena;

                while (true)
                {

                    Console.WriteLine("unesite cenu:");

                    if (!double.TryParse(Console.ReadLine(), out double result))
                    {

                        greska(type_: -1);
                        continue;

                    }

                    cena = result;
                    break;

                }

                int kolicina_na_stanju;

                while (true)
                {

                    Console.WriteLine("unesite kolicinu na stanju:");

                    if (!int.TryParse(Console.ReadLine(), out int result))
                    {

                        greska(type_: -1);
                        continue;

                    }

                    kolicina_na_stanju = result;
                    break;

                }

                Console.WriteLine("unesite da li je na akciji? da/ne");
                bool na_akciji = (Console.ReadLine().ToLower() == "da") ? true : false;

                Artikal artikal = new Artikal(sifra, naziv, cena, kolicina_na_stanju, na_akciji);
                artikli[x] = artikal;

            }

            int y = 0;

            foreach(Artikal artikal in artikli)
            {

                ++y;
                Console.WriteLine($"\ninformacije o artiklu #{y}:");
                artikal.prikaziInformacije();

            }

            foreach(Artikal artikal in artikli)
            {

                if (artikal.na_akciji)
                {

                    Console.WriteLine($"artikal {artikal.naziv} je na akciji.");

                }

            }

            int index;

            while (true)
            {

                Console.WriteLine("unesite index artikla da dodate dodatnu kolicinu na stanje:");

                if (!int.TryParse(Console.ReadLine(), out int result))
                {

                    greska(type_: -1);
                    continue;

                }

                if (result > artikli.Length || result < 0)
                {

                    greska(type_: -2);
                    continue;

                }

                index = result;
                break;

            }

            int dodatak;

            while (true)
            {

                Console.WriteLine("unesite dodatak:");

                if (!int.TryParse(Console.ReadLine(), out int result))
                {

                    greska(type_: -1);
                    continue;

                }

                dodatak = result;
                break;

            }

            artikli[index].dodajKolicinu(dodatak);

        }
    }
}
