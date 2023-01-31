using Check.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.IF
{
    internal class IFService
    {
        public List<Point> IFS(Data data, int[] chuishen)
        {
            String wellType = data.wellType;
            String casingType = data.casingType;
            List<Point> points = new List<Point>();
            if (wellType.Equals("气井"))
            {

                if (casingType.Equals("表层套环") || casingType.Equals("技术套管"))
                {
                    points = CasingCheck.function1(data.densityMax, data.densityg, data.Hs, chuishen);
                }
                if(casingType.Equals("生产套管") || casingType.Equals("生产为官"))
                {
                    
                    foreach (var item in chuishen)
                    {
                        points.Add(new Point(item, data.Pp));
                    }
                    
                }
            }
            if (wellType.Equals("油井"))
            {
                if (casingType.Equals("表层套环") || casingType.Equals("技术套管"))
                {
                    points = CasingCheck.function3(data.densityMax, chuishen);
                }
                if (casingType.Equals("生产套管") || casingType.Equals("生产尾管"))
                {
                    points = CasingCheck.function4(data.Gp, data.densityw, chuishen);
                }


            }

            return points;
        }
        


    }
 
}
