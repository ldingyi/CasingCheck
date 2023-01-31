using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.Bean
{
    
    public class Point

    {

        public int deep { get; set; }
        public double f { get; set; }

        public Point(int deep, double f)
        {
            this.deep = deep;
            this.f = f;
        }

        
    }
}
