using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA230906
{
    class Program
    {
        static void Main(string[] args)
        {
            var kategoriak = new List<Katergoria>();
            var sr = new StreamReader(
                path: @"..\..\..\src\titanic.txt",
                encoding: Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                //string sor = sr.ReadLine();
                //var kat = new Katergoria(sor);
                //kategoriak.Add(kat);

                kategoriak.Add(new Katergoria(sr.ReadLine()));

            }

            Console.WriteLine($"2. feladat: {kategoriak.Count} db");

            //int ossz = kategoriak.Sum(k => k.UtasokSzama);
            int ossz = 0;
            foreach (var k in kategoriak)
            {
                ossz += k.UtasokSzama;
            }
            Console.WriteLine($"3. feladat: {ossz} fő");


            Console.Write("4. feladat: Kulcsszó: ");
            string kulcsszo = Console.ReadLine();

            int i = 0;

            while (
                i < kategoriak.Count
                && !kategoriak[i].KategoriaNev.Contains(kulcsszo))
            {
                i++;
            }

            if (i < kategoriak.Count)
            {
                Console.WriteLine("\tVan találat!");
                Console.WriteLine("5. feladat:");
                foreach (var k in kategoriak)
                {
                    if (k.KategoriaNev.Contains(kulcsszo))
                    {
                        Console.WriteLine($"\t{k.KategoriaNev} {k.UtasokSzama}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\tNincs találat!");
            }

            //bool van = kategoriak.Any(k => k.KategoriaNev.Contains(kulcsszo));
            //Console.WriteLine($"\t {(van ? "van" : "nincs")} találat");
            //if (van)
            //{
            //    Console.WriteLine("5. feladat: ");
            //    var lst = kategoriak
            //        .Where(k => k.KategoriaNev.Contains(kulcsszo));
            //    foreach (var e in lst)
            //    {
            //        Console.WriteLine($"\t{e.KategoriaNev} {e.UtasokSzama} fő");

            //    }
            //}

            var meghaladta = new List<string>();
            foreach (var k in kategoriak)
            {
                if (k.UtasokSzama * .6 < k.EltuntekSzama)
                {
                    meghaladta.Add(k.KategoriaNev);
                }
            }

            Console.WriteLine("6. feladat: ");
            foreach (var kn in meghaladta)
            {
                Console.WriteLine($"\t{kn}");
            }


            //var meghaladta2 = kategoriak.Where(k => k.UtasokSzama * .6 < k.EltuntekSzama)
            //    .Select(k => k.KategoriaNev);
            //Console.WriteLine("6. feladat: ");
            //foreach (var kn in meghaladta2)
            //{
            //    Console.WriteLine($"\t{kn}");
            //}


            int maxi = 0;

            for (int j = 1; j < kategoriak.Count; j++)
            {
                if (kategoriak[j].TulelokSzama > kategoriak[maxi].TulelokSzama)
                {
                    maxi = j;
                }
            }
            Console.WriteLine($"7. feladat: {kategoriak[maxi].KategoriaNev}");
        }
    }
}
