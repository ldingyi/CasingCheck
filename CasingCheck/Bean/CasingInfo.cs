using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.Bean
{
    public class CasingInfo
    {
        /*
            抗拉强度
         */
        public double AFStrength { get; set; }
        /*
            抗挤强度
         */
        public double OFStrength { get; set; }
        /*
            抗内压强度
         */
        public double IFStrength { get; set; }

        public CasingInfo()
        {
        }

        public CasingInfo(double aFStrength, double oFStrength, double iFStrength)
        {
            AFStrength = aFStrength;
            OFStrength = oFStrength;
            IFStrength = iFStrength;
        }
    }
}
