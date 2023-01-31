using Check.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.AF
{
    internal class AFService
    {
        List<Point> points = new List<Point>();
        public List<Point> AFS(Data data, int[] chuishen) 
        {
            List<Point> points = new List<Point>();
            points = CasingCheck.function7(data.q, data.densitym, data.densitys, data.Hs, chuishen);
            return points;
        }
        public List<Point> AFS(Data data,List<Casing> casings)
        {
            List<Point> points = new List<Point>();
            points = CasingCheck.function8(data.q, data.densitym, data.densitys, data.u, casings);
            return points;
        }

        

    }
}
