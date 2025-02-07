using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Allomas
    {
        public string allapot {  get; set; }
        public int varakozo_utasok {  get; set; }
        public Vonat varakozo_vonat { get; set; }
        public Allomas(string allapot, int varakozo_utasok, Vonat varakozo_vonat)
        {
            this.allapot = allapot;
            this.varakozo_utasok = varakozo_utasok;
            this.varakozo_vonat = varakozo_vonat;
        }
    }
}
