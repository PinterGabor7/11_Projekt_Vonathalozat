using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Menetrend
    {
        public int ido = 0;
        public Dictionary<Pair, bool> Van_kozte = new Dictionary<Pair, bool>();
        public List<Allomas> Allomasok = new List<Allomas>();
        public List<Vonat> Vonatok = new List<Vonat>();                                                 //az i.-ik vonat
        //public List<int> Kesesek = new List<int>();                                                   //az i.-ik vonat késése       TODO
        public Dictionary<string, string> Kovetkezo_Allomas = new Dictionary<string, string>();         //a vonatok következő állomása
        public Dictionary<string, string> CelAllomasok = new Dictionary<string, string>();              //a vonatok célállomásai, key a vonat, value a célállomás
        public Dictionary<Pair, int> Tavolsagok = new Dictionary<Pair, int>();                          //két állomás közti távolság
        public Dictionary<Pair, List<Allomas>> Utvonalak = new Dictionary<Pair, List<Allomas>>();       //két állomás közti útvonal
        public Menetrend(List<Allomas> Allomasok, Dictionary<string, string> CelAllomasok, Dictionary<Pair, int> Tavolsagok)
        {
            this.Allomasok = Allomasok;
            this.CelAllomasok = CelAllomasok;
            this.Tavolsagok = Tavolsagok;

            foreach(Pair p in Tavolsagok.Keys)
            {
                Van_kozte[p] = true;
                Van_kozte[new Pair(p.Allomas2, p.Allomas1)] = true;
            }





            foreach (Allomas allomas1 in Allomasok)
            {
                foreach (Allomas allomas2 in Allomasok)
                {
                    if (!Van_kozte.ContainsKey(new Pair(allomas1.allomas_nev, allomas2.allomas_nev))) Van_kozte[new Pair(allomas1.allomas_nev, allomas2.allomas_nev)] = false;
                    if(Tavolsagok.ContainsKey(new Pair(allomas2.allomas_nev, allomas1.allomas_nev)) && !Tavolsagok.ContainsKey(new Pair(allomas1.allomas_nev, allomas2.allomas_nev)))
                    {
                        Tavolsagok[new Pair(allomas1.allomas_nev, allomas2.allomas_nev)] = Tavolsagok[new Pair(allomas2.allomas_nev, allomas1.allomas_nev)];
                    }
                    if (!Tavolsagok.ContainsKey(new Pair(allomas2.allomas_nev, allomas1.allomas_nev)) && Tavolsagok.ContainsKey(new Pair(allomas1.allomas_nev, allomas2.allomas_nev)))
                    {
                        Tavolsagok[new Pair(allomas2.allomas_nev, allomas1.allomas_nev)] = Tavolsagok[new Pair(allomas1.allomas_nev, allomas2.allomas_nev)];
                    }
                    if (!Tavolsagok.ContainsKey(new Pair(allomas1.allomas_nev, allomas2.allomas_nev))) Tavolsagok.Add(new Pair(allomas1.allomas_nev, allomas2.allomas_nev), 10000);

                    if (Utvonalak.ContainsKey(new Pair(allomas1.allomas_nev, allomas2.allomas_nev))) continue;
                    if (allomas1.allomas_nev == allomas2.allomas_nev)
                    {
                        Utvonalak.Add(new Pair(allomas1.allomas_nev, allomas2.allomas_nev), new List<Allomas> { allomas1 });
                    }
                    else
                    {
                        Utvonalak.Add(new Pair(allomas1.allomas_nev, allomas2.allomas_nev), new List<Allomas> { allomas1, allomas2 });
                        Utvonalak.Add(new Pair(allomas2.allomas_nev, allomas1.allomas_nev), new List<Allomas> { allomas2, allomas1 });
                    }
                }
            }



            TavolsagokFeltoltese();
            foreach(Allomas allomas in Allomasok){
                foreach(Vonat vonat in allomas.VarakozoVonatok)
                {
                    this.Vonatok.Add(vonat);
                    this.Vonatok[this.Vonatok.Count - 1].JelenlegiAllomas = allomas;
                    this.Vonatok[this.Vonatok.Count - 1].KovetkezoAllomas = Utvonalak[new Pair(allomas.allomas_nev, CelAllomasok[vonat.jaratszam])][0];
                    
                }
            }
        }

        public void TavolsagokFeltoltese()
        {
            foreach (Allomas allomask in Allomasok)
            {
                foreach (Allomas allomas1 in Allomasok)
                {
                    foreach (Allomas allomas2 in Allomasok)
                    {

                        string k = allomask.allomas_nev;
                        string a = allomas1.allomas_nev;
                        string b = allomas2.allomas_nev;


                        if (b == a) { 
                            continue;
                        }
                        if (a == k)
                        {
                            Tavolsagok[new Pair(a, k)] = 0;
                            Tavolsagok[new Pair(k, a)] = 0;
                        }
                        if(b == k)
                        {
                            Tavolsagok[new Pair(b, k)] = 0;
                            Tavolsagok[new Pair(k, b)] = 0;
                        }


                        if(Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)] <= Tavolsagok[new Pair(a, b)])
                        {
                            Tavolsagok[new Pair(a, b)] = Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)];

                            /*if (Utvonalak[new Pair(a, b)].Count != 0)
                            {
                                bool valid = true;
                                for(int i = 0; i < Utvonalak[new Pair(a, b)].Count-1; i++)
                                {
                                    if (!Van_kozte[new Pair(Utvonalak[new Pair(a, b)][i].allomas_nev, Utvonalak[new Pair(a, b)][i + 1].allomas_nev)])
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                                if(!valid)
                                {
                                    Utvonalak[new Pair(a, b)] = Utvonalak[new Pair(a, k)];
                                    Utvonalak[new Pair(a, b)].AddRange(Utvonalak[new Pair(k, b)].Where((n, i) => i > 0));
                                }
                            }
                            else
                            {
                                Utvonalak[new Pair(a, b)] = Utvonalak[new Pair(a, k)];
                                Utvonalak[new Pair(a, b)].AddRange(Utvonalak[new Pair(k, b)].Where((n, i) => i > 0));
                            }

                            if (a == "Győr Vasútállomás" && b == "Budapest-Kelenföld")
                            {
                                Console.WriteLine(k + ":");
                                foreach(Allomas asd in Utvonalak[new Pair(a, k)])
                                {
                                    Console.Write(asd.allomas_nev + ", ");
                                }
                                Console.WriteLine();

                                foreach (Allomas asd in Utvonalak[new Pair(k, b)])
                                {
                                    Console.Write(asd.allomas_nev + ", ");
                                }


                                Console.WriteLine();
                            }*/
                            Utvonalak[new Pair(a, b)] = Utvonalak[new Pair(a, k)];
                            Utvonalak[new Pair(a, b)].AddRange(Utvonalak[new Pair(k, b)].Where((n, i) => i > 0));
                        }
                    }
                }
            }
        }

        public void Leptetes(int pluszido)
        {
            ido += pluszido;

            foreach(Vonat v in Vonatok)
            {
                if(ido > v.erkezes)
                {
                    Random r = new Random();
                    if(v.KovetkezoAllomas.allomas_nev == CelAllomasok[v.jaratszam])
                    {
                        v.JelenlegiAllomas = null;
                        v.ElozoAllomas = v.KovetkezoAllomas;
                        CelAllomasok[v.jaratszam] = Allomasok[r.Next(0, 11)].allomas_nev;
                        while (CelAllomasok[v.jaratszam] == v.ElozoAllomas.allomas_nev)
                        {
                            CelAllomasok[v.jaratszam] = Allomasok[r.Next(0, 11)].allomas_nev;
                        }
                        v.KovetkezoAllomas = Utvonalak[new Pair(v.ElozoAllomas.allomas_nev, CelAllomasok[v.jaratszam])][1];
                        v.erkezes = ido + Tavolsagok[new Pair(v.ElozoAllomas.allomas_nev, CelAllomasok[v.jaratszam])];
                        int felszallok = r.Next(0, Math.Min(v.ElozoAllomas.varakozo_utasok, v.ures_helyek));

                        v.ElozoAllomas.varakozo_utasok -= felszallok;
                        v.utasok += felszallok;
                    }
                    else
                    {
                        v.JelenlegiAllomas = null;
                        v.ElozoAllomas = v.KovetkezoAllomas;
                        v.KovetkezoAllomas = Utvonalak[new Pair(v.ElozoAllomas.allomas_nev, CelAllomasok[v.jaratszam])][0];
                        v.erkezes = ido + Tavolsagok[new Pair(v.ElozoAllomas.allomas_nev, CelAllomasok[v.jaratszam])];

                        int felszallok = r.Next(0, Math.Min(v.ElozoAllomas.varakozo_utasok, v.ures_helyek));

                        v.ElozoAllomas.varakozo_utasok -= felszallok;
                        v.utasok += felszallok;
                    }
                    v.ElozoAllomas.VarakozoVonatok.Remove(v);

                }
                else if (ido == v.erkezes)
                {

                    Random r = new Random();
                    if (v.KovetkezoAllomas.allomas_nev == CelAllomasok[v.jaratszam])
                    {
                        if(v.JelenlegiAllomas != null) v.ElozoAllomas = v.JelenlegiAllomas;
                        v.JelenlegiAllomas = v.KovetkezoAllomas;
                        CelAllomasok[v.jaratszam] = Allomasok[r.Next(0, 11)].allomas_nev;
                        while (CelAllomasok[v.jaratszam] == v.JelenlegiAllomas.allomas_nev || CelAllomasok[v.jaratszam] == v.ElozoAllomas.allomas_nev)
                        {
                            CelAllomasok[v.jaratszam] = Allomasok[r.Next(0, 11)].allomas_nev;
                        }
                        v.KovetkezoAllomas = Utvonalak[new Pair(v.JelenlegiAllomas.allomas_nev, CelAllomasok[v.jaratszam])][0];
                        v.erkezes = ido + Tavolsagok[new Pair(v.JelenlegiAllomas.allomas_nev, CelAllomasok[v.jaratszam])];
                        int felszallok = r.Next(0, Math.Min(v.JelenlegiAllomas.varakozo_utasok, v.ures_helyek));

                        v.JelenlegiAllomas.varakozo_utasok -= felszallok;
                        v.utasok += felszallok;
                    }
                    else
                    {
                        if(v.JelenlegiAllomas != null) v.ElozoAllomas = v.JelenlegiAllomas;
                        v.JelenlegiAllomas = v.KovetkezoAllomas;
                        v.KovetkezoAllomas = Utvonalak[new Pair(v.JelenlegiAllomas.allomas_nev, CelAllomasok[v.jaratszam])][0];
                        v.erkezes = ido + Tavolsagok[new Pair(v.JelenlegiAllomas.allomas_nev, CelAllomasok[v.jaratszam])];

                        int felszallok = r.Next(0, Math.Min(v.JelenlegiAllomas.varakozo_utasok, v.ures_helyek));

                        v.JelenlegiAllomas.varakozo_utasok -= felszallok;
                        v.utasok += felszallok;
                    }
                    v.ElozoAllomas.VarakozoVonatok.Remove(v);
                    v.JelenlegiAllomas.VarakozoVonatok.Add(v);

                }

            }
        }
    }
}
