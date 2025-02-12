using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Vonat
    {
        public string jaratszam {  get; set; }
        public int ures_helyek {  get; set; }
        public List<Utas> Utasok { get; set; }
        public Vonat(string jaratszam, int ures_helyek = 0, List<Utas> Utasok = null)
        {
            this.jaratszam = jaratszam;
            this.ures_helyek = ures_helyek;
            if(Utasok == null)
            {
                this.Utasok = new List<Utas>();
            }
            else
            {
                this.Utasok = Utasok;
            }
        }
    }
}
