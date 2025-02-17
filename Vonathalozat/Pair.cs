using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Pair
    {
        public string Allomas1 {  get; set; }
        public string Allomas2 {  get; set; }

        public Pair(string allomas1, string allomas2)
        {
            this.Allomas1 = allomas1;
            this.Allomas2 = allomas2;
        }

        public override bool Equals(object obj)
        {
            if (obj is Pair other)
            {
                return Allomas1 == other.Allomas1 && Allomas2 == other.Allomas2;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Allomas1, Allomas2);
        }
    }
}
