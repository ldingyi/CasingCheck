using Check.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.OF
{
    internal class OFService
    {
        public List<Point> OFS(Data data, int[] chuishen)
        {
            int isRB = data.isRB;
            String casingType = data.casingType;
            List<Point> points = new List<Point>();
            if(isRB== 0)
            {
                if (casingType.Equals("表层套环") || casingType.Equals("技术套管"))
                {
                    points = CasingCheck.function5(data.densitym, data.km, data.densityMin, chuishen);
                }
                if (casingType.Equals("生产套管") || casingType.Equals("生产为官"))
                {
                    points = CasingCheck.function5(data.densitym, data.km, data.densityw, chuishen);
                }
            }
            else
            {
                if (casingType.Equals("表层套环") || casingType.Equals("技术套管"))
                {
                    points = CasingCheck.function6(data.V, data.Gv, data.km, data.densityMin, chuishen);
                }
                if (casingType.Equals("生产套管") || casingType.Equals("生产为官"))
                {
                    points = CasingCheck.function6(data.V, data.Gv, data.km, data.densityw, chuishen);
                }
            }
            return points;
        }
       

    }
}
