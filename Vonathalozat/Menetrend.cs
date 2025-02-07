using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Menetrend
    {
        public List<Vonat> Vonatok = new List<Vonat>();             //az i.-ik vonat
        public List<int> Kesesek = new List<int>();                 //az i.-ik vonat késése
        public List<Allomas> CelAllomasok = new List<Allomas>();    //az i.-ik vonat célállomása
        public Menetrend(List<Vonat> Vonatok, List<Allomas> CelAllomasok)
        {
            this.Vonatok = Vonatok;
            this.CelAllomasok = CelAllomasok;
        }
    }
}
