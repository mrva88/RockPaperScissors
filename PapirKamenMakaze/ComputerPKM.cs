using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapirKamenMakaze
{
    class ComputerPKM
    {
        public static string GetSelection()
        {
            string[] niz = new string[3];
            niz[0] = "papir";
            niz[1] = "kamen";
            niz[2] = "makaze";
            Random rnd = new Random();
            int r = rnd.Next(niz.Length);
            return niz[r];
        }
    }
}
