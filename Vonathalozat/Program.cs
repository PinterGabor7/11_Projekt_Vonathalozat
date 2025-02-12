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
                        30, 
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
                                "S1122",
                                150
                            ),
                            new Vonat(
                                "Ex6243",
                                200
                            ),
                        }
                    ),
                    new Allomas(
                        "Budapest-Kelenföld",
                        30,
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
                        12,
                        3,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                "Ex2204",
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
                        10,
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
                        "Miskolc Tiszai pályaudvar",
                        7,
                        3,
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
                        "Pécs vasútállomás",
                        5,
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
                        "Szeged vasútállomás",
                        6,
                        3,
                        VarakozoVonatok: new List<Vonat>()
                        {
                            new Vonat(
                                ""
                            )
                        }

                    )
                },
                Vonatok: new List<Vonat>(){

                },
                CelAllomasok: new Dictionary<string, string>(){

                },
                Tavolsagok: new Dictionary<Pair, int>(){

                }
            );
            /*char choice = ' ';
            while (choice != '0')
            {
                Console.WriteLine("Jelenleg a(z) {} állomáson van.");
                Console.WriteLine("Továbbmehet a következő állomásokra: ");
                foreach (Allomas a in Allomasok)
                {

                }
            }*/
        }
    }
}
