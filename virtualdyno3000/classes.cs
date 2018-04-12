using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtualdyno3000
{
    class Car
    {
        public int id { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public double engine { get; set; }
        public int year { get; set; }
        public int camshaft { get; set; }
        public int piston { get; set; }
        public int injectionsystem { get; set; }
        public int exhaust { get; set; }
        public int turbo { get; set; }
        public int block { get; set; }
        public int broke { get; set; }
    }

    class Part
    {
        public int id { get; set; }
        public string manufacturer { get; set; }
        public string partname { get; set; }
        public int parttype { get; set; }
        public int stage { get; set; }
        public int toughness { get; set; }
    }
    class State
    {
        public double torgue { get; set; }
        public int rpm { get; set; }
        public bool broke { get; set; }

    }

}
