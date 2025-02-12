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
        public Dictionary<string, string> CelAllomasok = new Dictionary<string, string>();    //a vonatok célállomásai
        public Dictionary<Pair, int> Tavolsagok = new Dictionary<Pair, int>();  //két állomás közti távolság
        public Menetrend(List<Allomas> Allomasok, List<Vonat> Vonatok, Dictionary<string, string> CelAllomasok, Dictionary<Pair, int> Tavolsagok)
        {
            this.Allomasok = Allomasok;
            this.Vonatok = Vonatok;
            this.CelAllomasok = CelAllomasok;
            this.Tavolsagok = Tavolsagok;

        }
    }
}
