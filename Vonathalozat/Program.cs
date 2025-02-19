using System.Net.Http.Headers;

namespace Vonathalozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menetrend menetrend = new Menetrend(
                Allomasok: new List<Allomas>(){
                    new Allomas(
                        "Budapest-Keleti", 
                        40, 
                        5, 
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "IC1604",
                                300
                            ),
                            new Vonat(
                                "G3406",
                                250
                            ),
                            new Vonat(
                                "EC174",
                                400
                            ),
                            new Vonat(
                                "EX6243",
                                200
                            ),
                        }
                    ),
                    new Allomas(
                        "Budapest-Kelenföld",
                        35,
                        5,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "IC5401",
                                300
                            ),
                            new Vonat(
                                "G8812",
                                250
                            ),
                            new Vonat(
                                "S1746",
                                150
                            ),
                        }
                    ),
                    new Allomas(
                        "Debrecen Vasútállomás",
                        20,
                        3,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "EX2204",
                                200
                            ),
                            new Vonat(
                                "IC5619",
                                300
                            )
                        }
                    ),
                    new Allomas(
                        "Szolnok Vasútállomás",
                        15,
                        2,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "M4535",
                                120
                            )
                        }
                    ),
                    new Allomas(
                        "Miskolc Vasútállomás",
                        30,
                        4,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "IC9201",
                                300
                            ),
                            new Vonat(
                                "RE1001",
                                150
                            )
                        }
                    ),
                    new Allomas(
                        "Pécs Vasútállomás",
                        20,
                        2,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "S401",
                                150
                            )
                        }
                    ),
                    new Allomas(
                        "Szeged Vasútállomás",
                        12,
                        3,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "IC810",
                                300
                            ),
                            new Vonat(
                                "S2450",
                                120
                            )
                        }
                    ),
                    new Allomas(
                        "Kecskemét Vasútállomás",
                        4,
                        2,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "S1122",
                                150
                            )
                        }
                    ),
                    new Allomas(
                        "Székesfehérvár Vasútállomás",
                        6,
                        3,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "IC1042",
                                300
                            )
                        }
                    ),
                    new Allomas(
                        "Nyíregyháza Vasútállomás",
                        20,
                        2,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "S9110",
                                100
                            )
                        }
                    ),
                    new Allomas(
                        "Győr Vasútállomás",
                        40,
                        3,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "S4043",
                                150
                            ),
                            new Vonat(
                                "IC714",
                                350
                            )
                        }
                    )
                },
                CelAllomasok: new Dictionary<string, string>(){
                    {"IC1604", "Debrecen Vasútállomás" },
                    {"G3406", "Győr Vasútállomás" },
                    {"EC174", "Pécs Vasútállomás" },
                    {"EX6243", "Székesfehérvár Vasútállomás" },
                    {"IC5401", "Pécs Vasútállomás" },
                    {"G8812", "Miskolc Vasútállomás"},
                    {"S1746", "Szolnok Vasútállomás"},
                    {"EX2204", "Győr Vasútállomás" },
                    {"IC5619", "Pécs Vasútállomás"},
                    {"M4535", "Miskolc Vasútállomás"},
                    {"IC9201", "Nyíregyháza Vasútállomás"},
                    {"RE1001", "Szeged Vasútállomás"},
                    {"S401", "Budapest-Keleti"},
                    {"IC810", "Budapest-Kelenföld"},
                    {"S2450", "Kecskemét Vasútállomás"},
                    {"S1122", "Budapest-Keleti"},
                    {"IC1042", "Budapest-Kelenföld"},
                    {"S9110", "Székesfehérvár Vasútállomás"},
                    {"S4043", "Budapest-Keleti"},
                    {"IC714", "Debrecen Vasútállomás"}
                },
                Tavolsagok: new Dictionary<Pair, int>(){
                    {new Pair("Győr Vasútállomás", "Budapest-Keleti"), 100},
                    {new Pair("Győr Vasútállomás", "Pécs Vasútállomás"), 180},
                    {new Pair("Budapest-Keleti", "Miskolc Vasútállomás"), 150},
                    {new Pair("Budapest-Keleti", "Budapest-Kelenföld"), 15},
                    {new Pair("Budapest-Keleti", "Debrecen Vasútállomás"), 150},
                    {new Pair("Budapest-Keleti", "Nyíregyháza Vasútállomás"), 210},
                    {new Pair("Budapest-Kelenföld", "Pécs Vasútállomás"), 150},
                    {new Pair("Budapest-Kelenföld", "Szeged Vasútállomás"), 150},
                    {new Pair("Budapest-Kelenföld", "Kecskemét Vasútállomás"), 90},
                    {new Pair("Debrecen Vasútállomás", "Miskolc Vasútállomás"), 90},
                    {new Pair("Debrecen Vasútállomás", "Szolnok Vasútállomás"), 120},
                    {new Pair("Szolnok Vasútállomás", "Szeged Vasútállomás"), 210},
                    {new Pair("Szolnok Vasútállomás", "Pécs Vasútállomás"), 270},
                    {new Pair("Szolnok Vasútállomás", "Kecskemét Vasútállomás"), 60},
                    {new Pair("Miskolc Vasútállomás", "Nyíregyháza Vasútállomás"), 90},
                    {new Pair("Miskolc Vasútállomás", "Szeged Vasútállomás"), 200},
                    {new Pair("Pécs Vasútállomás", "Székesfehérvár Vasútállomás"), 240},
                    {new Pair("Szeged Vasútállomás", "Nyíregyháza Vasútállomás"), 240},


                }
            );


            char choice = ' ';
            while (choice != '0')
            {
                Console.Clear();
                Console.WriteLine("1.: Állomások állapotai");
                Console.WriteLine("2.: Egy vonat állapota");
                Console.WriteLine("3.: Idő léptetése 10 perccel");
                Console.WriteLine("0.: Kilépés");
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        Console.Clear();
                        foreach (Allomas a in menetrend.Allomasok)
                        {
                            Console.WriteLine(a.allomas_nev + ": ");
                            Console.WriteLine("Várakozó vonatok: ");
                            foreach(Vonat v in a.VarakozoVonatok)
                            {
                                Console.WriteLine($"\t{v.jaratszam}");
                            }

                            Console.WriteLine($"Várakozó utasok: {a.varakozo_utasok} fő");
                            Console.WriteLine();

                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Adja meg a vonat járatszámát: ");
                        string vonat = Console.ReadLine()!;

                        Vonat keresett = null;

                        foreach(Vonat v in menetrend.Vonatok)
                        {
                            if(vonat == v.jaratszam)
                            {
                                keresett = v;
                                break;
                            }
                        }



                        if( keresett == null)
                        {
                            Console.WriteLine("A keresett vonat nem szerepel a vonatok között.");
                        }
                        else
                        {
                            Console.WriteLine($"A vonaton utazók száma {keresett.utasok}");
                            Console.WriteLine($"A vonat célállomása: {menetrend.CelAllomasok[keresett.jaratszam]}");
                            
                        }
                        break;
                    case '3':
                        menetrend.Leptetes(10);
                        break;
                }
                Console.ReadKey(true);
            }
        }
    }
}
