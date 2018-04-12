﻿using System;
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
        public int camshaft { get; set; }           // 1
        public int piston { get; set; }             // 2
        public int injectionsystem { get; set; }    // 3
        public int exhaust { get; set; }            // 4
        public int turbo { get; set; }              // 5
        public int block { get; set; }              // 6
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

}
