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

            Console.WriteLine(Vonatok.Count);

            TavolsagokFeltoltese();
        }

        public void TavolsagokFeltoltese()
        {
            foreach (Vonat vonatk in Vonatok)
            {
                foreach (Vonat vonat1 in Vonatok)
                {
                    foreach(Vonat vonat2 in Vonatok)
                    {
                        if (vonat1.jaratszam == vonat2.jaratszam) continue;
                        string k = vonatk.jaratszam;
                        string a = vonat1.jaratszam;
                        string b = vonat2.jaratszam;


                        if(!Tavolsagok.ContainsKey(new Pair(a, k)) && !Tavolsagok.ContainsKey(new Pair(k, a))) continue;
                        if(!Tavolsagok.ContainsKey(new Pair(b, k)) && !Tavolsagok.ContainsKey(new Pair(k, b))) continue;
                        if(!Tavolsagok.ContainsKey(new Pair(a, k))) Tavolsagok[new Pair(a, k)] = Tavolsagok[new Pair(k, a)];
                        if(!Tavolsagok.ContainsKey(new Pair(b, k))) Tavolsagok[new Pair(b, k)] = Tavolsagok[new Pair(k, b)];
                        if(!Tavolsagok.ContainsKey(new Pair(a, b))) Tavolsagok[new Pair(a, b)] = Tavolsagok[new Pair(b, a)];
                        if(!Tavolsagok.ContainsKey(new Pair(a, b)))
                        {
                            Tavolsagok.Add(new Pair(a, b), Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)]);
                            Tavolsagok.Add(new Pair(b, a), Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)]);
                        }
                        if(Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)] < Tavolsagok[new Pair(a, b)])
                        {
                            Tavolsagok[new Pair(a, b)] = Tavolsagok[new Pair(a, k)] + Tavolsagok[new Pair(k, b)];
                            Tavolsagok[new Pair(b, a)] = Tavolsagok[new Pair(a, b)];
                        }
                        Console.WriteLine($"{a}     {b}");
                    }
                }
            }
        }
    }
}
