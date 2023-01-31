using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.Bean
{
    public class Result
    {
        /*
            外压力集合
         */
        public List<Point> OFS { get; set; }
        /*外压力安全系数*/
        public List<double> OFCoefficients { get; set; }

        /*
            内压力集合
         */
        public List<Point> IFS { get; set; }
        /*
            内压力安全系数
         */
        public List<double> IFCoefficients { get; set; }
        /*
            拉力集合
         */
        public List<Point> AFS { get; set; }
        /*
            轴向力安全系数
         */
        public List<double> AFCoefficients { get; set; }

        public Result(List<Point> oFS, List<double> oFCoefficients, List<Point> iFS, List<double> iFCoefficients, List<Point> aFS, List<double> aFCoefficients)
        {
            OFS = oFS;
            OFCoefficients = oFCoefficients;
            IFS = iFS;
            IFCoefficients = iFCoefficients;
            AFS = aFS;
            AFCoefficients = aFCoefficients;
        }
    }
}
