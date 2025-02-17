using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Menetrend
    {
        public List<Allomas> Allomasok = new List<Allomas>();
        public List<Vonat> Vonatok = new List<Vonat>();             //az i.-ik vonat
        //public List<int> Kesesek = new List<int>();                 //az i.-ik vonat késése       TODO
        public Dictionary<string, string> Kovetkezo_Allomas = new Dictionary<string, string>(); //a vonatok következő állomása
        public Dictionary<string, string> CelAllomasok = new Dictionary<string, string>();    //a vonatok célállomásai, key a vonat, value a célállomás
        public Dictionary<Pair, int> Tavolsagok = new Dictionary<Pair, int>();  //két állomás közti távolság
        public Menetrend(List<Allomas> Allomasok, Dictionary<string, string> CelAllomasok, Dictionary<Pair, int> Tavolsagok)
        {
            this.Allomasok = Allomasok;
            this.CelAllomasok = CelAllomasok;
            this.Tavolsagok = Tavolsagok;

            foreach(Allomas allomas in Allomasok){
                foreach(Vonat vonat in allomas.VarakozoVonatok)
                {
                    this.Vonatok.Add(vonat);
                }
            }


            TavolsagokFeltoltese();
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

                        if (b == a) continue;
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



                        if (!Tavolsagok.ContainsKey(new Pair(a, k)) && !Tavolsagok.ContainsKey(new Pair(k, a))) continue;
                        if(!Tavolsagok.ContainsKey(new Pair(b, k)) && !Tavolsagok.ContainsKey(new Pair(k, b))) continue;
                        if(!Tavolsagok.ContainsKey(new Pair(a, k))) Tavolsagok.Add(new Pair(a, k), Tavolsagok[new Pair(k, a)]);
                        if(!Tavolsagok.ContainsKey(new Pair(b, k))) Tavolsagok.Add(new Pair(b, k), Tavolsagok[new Pair(k, b)]);
                        if (!Tavolsagok.ContainsKey(new Pair(k, a))) Tavolsagok.Add(new Pair(k, a), Tavolsagok[new Pair(a, k)]);
                        if (!Tavolsagok.ContainsKey(new Pair(k, b))) Tavolsagok.Add(new Pair(k, b), Tavolsagok[new Pair(b, k)]);

                        if (!Tavolsagok.ContainsKey(new Pair(b, a)) && Tavolsagok.ContainsKey(new Pair(a, b))) Tavolsagok.Add(new Pair(b, a), Tavolsagok[new Pair(a, b)]);
                        if (Tavolsagok.ContainsKey(new Pair(b, a)) && !Tavolsagok.ContainsKey(new Pair(a, b))) Tavolsagok.Add(new Pair(a, b), Tavolsagok[new Pair(b, a)]);

                        if (!Tavolsagok.ContainsKey(new Pair(a, b)) && !Tavolsagok.ContainsKey(new Pair(b, a)))
                        {
                            Tavolsagok.Add(new Pair(a, b), Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)]);
                            Tavolsagok.Add(new Pair(b, a), Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)]);
                        }
                        if(Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)] < Tavolsagok[new Pair(a, b)])
                        {
                            Tavolsagok[new Pair(a, b)] = Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)];
                            Tavolsagok[new Pair(b, a)] = Tavolsagok[new Pair(a, b)];
                        }

                    }
                }
            }
        }
    }
}
