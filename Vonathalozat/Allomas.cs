using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Allomas
    {
        public string allomas_nev {  get; set; }
        public int varakozo_utasok {  get; set; }
        public int vonat_kapacitas {  get; set; }
        public List<Vonat> VarakozoVonatok = new List<Vonat>();
        public Allomas(string allomas_nev, int varakozo_utasok = 0, int vonat_kapacitas = 0, List<Vonat> VarakozoVonatok = null!)
        {
            this.allomas_nev = allomas_nev;
            this.varakozo_utasok = varakozo_utasok;
            this.vonat_kapacitas = vonat_kapacitas;
            if (VarakozoVonatok == null)
            {
                VarakozoVonatok = new List<Vonat>();
            }
            else
            {
                this.VarakozoVonatok = VarakozoVonatok;
            }
        }
    }
}
