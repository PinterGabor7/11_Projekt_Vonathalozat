using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Utas
    {
        public bool helyjegy { get; set; }
        public string cel_allomas { get; set; }
        public Utas(string cel_allomas, bool van_jegy = true)
        {
            this.cel_allomas = cel_allomas;
            this.helyjegy = van_jegy;
        }

    }
}
