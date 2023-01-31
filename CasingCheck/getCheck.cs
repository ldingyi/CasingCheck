using Check.AF;
using Check.Bean;
using Check.IF;
using Check.OF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    public  class GetCheck
    {
        static AFService aFService = new AFService();
        static OFService oFService = new OFService();
        static IFService iFService= new IFService();

        public static Result getResult(Data data ,CasingInfo casingInfo, int[] chuishen)
        {
            
            List<Point> OFS = oFService.OFS(data, chuishen);
            List<Point> IFS = iFService.IFS(data, chuishen);
            List<Point> AFS = aFService.AFS(data, chuishen);
            List<double> OFCoefficients = CasingCheck.getCoefficients(OFS, casingInfo.OFStrength);
            List<double> IFCoefficients = CasingCheck.getCoefficients(OFS, casingInfo.IFStrength);
            List<double> AFCoefficients = CasingCheck.getCoefficients(OFS, casingInfo.AFStrength);
            Result result = new Result(OFS, OFCoefficients, IFS, IFCoefficients, AFS, AFCoefficients);
            return result;

        }
        public static Result getResult(Data data, CasingInfo casingInfo, int[] chuishen,List<Casing> casings)
        {
            List<Point> OFS = oFService.OFS(data, chuishen);
            List<Point> IFS = iFService.IFS(data, chuishen);
            List<Point> AFS = aFService.AFS(data, casings);
            List<double> OFCoefficients = CasingCheck.getCoefficients(OFS, casingInfo.OFStrength);
            List<double> IFCoefficients = CasingCheck.getCoefficients(OFS, casingInfo.IFStrength);
            List<double> AFCoefficients = CasingCheck.getCoefficients(OFS, casingInfo.AFStrength);
            Result result = new Result(OFS, OFCoefficients, IFS, IFCoefficients, AFS, AFCoefficients);
            return result;
        }
    }
}
