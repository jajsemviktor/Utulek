using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Zvire
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string druh { get; set; }
        public int vek { get; set; }
        public string pohlavi { get; set; }
        public string adoptovano { get; set; }


        public Zvire(int iD, string name, string druh, int vek, string pohlavi, string adoptovano)
        {
            ID = iD;
            Name = name;
            this.druh = druh;
            this.vek = vek;
            this.pohlavi = pohlavi;
            this.adoptovano = adoptovano;
        }
    }
}
