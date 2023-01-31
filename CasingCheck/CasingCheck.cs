using Check.Bean;

namespace Check
{
    public class CasingCheck
    {
        /*
            @function 内压力，气井，表层和技术
            @param densityMax 下次钻井最大钻井液密度
            @param densityg 天然气相对密度
            @param censhen[] 井深轨迹测深数组
         */
        public static List<Point> function1(double densityMax, double densityg,int Hs, int[] ceshen)
        {
            List<Point> result = new List<Point>();
            
            double Pbs = FunctionUtil.function27(densityMax, Hs);
            for (int i = 0; i < ceshen.Length; i++)
            {
                double Pbh = FunctionUtil.function28(Pbs, Hs, ceshen[i], densityg);
                result.Add(new Point(ceshen[i], Pbh));
            }
            return result;
        }

        /*
            @function 内压力 油井 表层和技术
            @param densityMax 下次钻井最大钻井液密度
            @param censhen[] 井深轨迹测深数组
         */
        public static List<Point> function3(double densityMax, int[] ceshen)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < ceshen.Length; i++)
            {
                double Pbh = FunctionUtil.function33(densityMax, ceshen[i]);
                points.Add(new Point(ceshen[i], Pbh));
            }
            return points;
        }

        /*
            @fucntion 内压力 油井 生产和尾管
            @param Gp double 油层或底层压力梯度 
            @param densityw double 完井液密度
            @param censhen[] 井深轨迹测深数组
         */
        public static List<Point> function4(double Gp, double densityw, int[] ceshen)
        {
            List<Point> points = new List<Point>();
            int Hs = ceshen[ceshen.Length - 1];
            double Pbs = FunctionUtil.function35(Gp, Hs);
            for (int i = 0; i < ceshen.Length - 1; i++)
            {
                double Pbh = FunctionUtil.function37(Pbs, densityw, ceshen[i]);
                points.Add(new Point(ceshen[i], Pbh));
            }
            return points;
        }

        /*
            @function 有效外压力:非塑性蠕变地层
            @param densitym double 固井时钻井液密度
            @param km double 掏空系数  0-1
            @param density double 不同情况含义不同，为了用一个函数表示出来
            @param censhen[] 井深轨迹测深数组
         */
        public static List<Point> function5(double densitym, double km, double density, int[] ceshen)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < ceshen.Length; i++)
            {
                double Pce = FunctionUtil.function39(densitym, km, density, ceshen[i]);
                points.Add(new Point(ceshen[i], Pce));
            }
            return points;
        }

        /*
            @function 有效外压力:塑性蠕变地层
            @param v double 底层岩石泊松系数  0.3-0.5
            @param Gv double 油层或底层压力梯度
            @param km double 掏空系数  0-1
            @param density double 下次钻井最小钻井液密度
            @param censhen[] 井深轨迹测深数组
         */
        public static List<Point> function6(double v, double Gv, double km, double density, int[] ceshen)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < ceshen.Length; i++)
            {
                double Pce = FunctionUtil.function40(v, Gv, km, density, ceshen[i]);
                points.Add(new Point(ceshen[i], Pce));
            }
            return points;
        }

        /*
            @function 直井 拉力
            @param q  double 第i段套管柱在空气中的单位长度质量
            @param densitym double 固井时钻井液密度
            @param densitys double 套管钢材密度 
            @param Hs int 此段的最大下深
         */
        public static List<Point> function7(double q, double densitym, double densitys, int Hs, int[] chuishen)
        {
            List<Point> points = new List<Point>();
            //单位长度有效重量
            double qei = FunctionUtil.function43(q, densitym, densitys);
            for (int i = 0; i < chuishen.Length; i++)
            {
                double t = (Hs - chuishen[i]) * qei;
                points.Add(new Point(i, t));
            }
            return points;
        }

        /*
            @param q  double 第i段套管柱在空气中的单位长度质量
            @param densitym double 固井时钻井液密度
            @param densitys double 套管钢材密度 
            @param u  double 摩阻系数
         */
        public static List<Point> function8(double q, double densitym, double densitys, double u, List<Casing> casings)
        {
            //先把casings反转，为了从下往上求
            casings.Reverse();
            //单位长度有效重量，目前看，求出啦是一个固定的值，所以就设为了全局变量
            double qei = FunctionUtil.function43(q, densitym,densitys);
            //用来存放力，从下至上，是每一段套管的上端的里，
            List<double> AFList = new List<double>();
            //用于递归公式，t代表靠近井底的。用来递归求靠近上端的。
            double t = 0;
            for (int i = 0; i < casings.Count; i++)
            {
                if (casings[i].Type.Equals("稳斜"))
                {

                    double tNext = FunctionUtil.function48(t, casings[i].JingXieJiao, u, casings[i].L, qei);
                    AFList.Add(tNext);
                    t = tNext;
                }
                if (casings[i].Type.Equals("降斜"))
                {
                    double A = FunctionUtil.GetA(u, qei, casings[i].R);
                    double B = FunctionUtil.GetB(u, qei, casings[i].R);
                    double tNext = FunctionUtil.function47(t, A, B, casings[i].JingXieJiao, casings[i + 1].JingXieJiao, u);
                    AFList.Add(tNext);
                    t = tNext;

                }
                if (casings[i].Type.Equals("造斜"))
                {
                    double A = FunctionUtil.GetA(u, qei, casings[i].R);
                    double B = FunctionUtil.GetB(u, qei, casings[i].R);
                    bool N = FunctionUtil.N(qei, casings[i].JingXieJiaoYuJiao, t, casings[i].R);
                   
                    if (N)
                    {
                        double tNext = FunctionUtil.function45(t, A, B, casings[i].JingXieJiaoYuJiao, casings[i + 1].JingXieJiaoYuJiao, u);
                        AFList.Add(tNext);
                        t = tNext;
                    }
                    else
                    {
                        double tNext = FunctionUtil.function46(t, A, B, casings[i].JingXieJiaoYuJiao, casings[i + 1].JingXieJiaoYuJiao, u);
                        AFList.Add(tNext);
                        t = tNext;
                    }
                }
                if (casings[i].Type.Equals("直段"))
                {
                   
                    double tNext = t + qei * casings[i].L;
                    AFList.Add(tNext);
                    t = tNext;

                }


            }
            List<Point> points = new List<Point>();
            AFList.Reverse();
            casings.Reverse();

            for (int i = 0; i < AFList.Count; i++)
            {
                points.Add(new Point(casings[i].ceshenU, AFList[i]));

            }

            return points;

        }
        public static List<double> getCoefficients(List<Point> F ,double xCoefficient)
        {
            List<double> cofficients= new List<double>();
            foreach (var item in F)
            {
                cofficients.Add(xCoefficient / item.f);
            }
            return cofficients;
        }

    }
}
