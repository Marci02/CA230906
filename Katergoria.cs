using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA230906
{
    class Katergoria
    {
        public string KategoriaNev { get; set; }
        public int TulelokSzama { get; set; }
        public int EltuntekSzama { get; set; }

        public int UtasokSzama => this.TulelokSzama + this.EltuntekSzama;

        public Katergoria(string sor)
        {
            string[] d = sor.Split(';');
            this.KategoriaNev = d[0];
            this.TulelokSzama = int.Parse(d[1]);
            this.EltuntekSzama = int.Parse(d[2]);
        }
    }
}
