using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    public class FunctionUtil
    {


        //@unction：有效内压力：气井：表层套管和技术套管


        /*
            @function:按下一次使用的最大钻井液密度计算套管鞋处最大内压力
            @param ρmax double 下次钻井最大钻井液密度
            @param Hs double 套管下深或套管鞋深度
            @return Pbs double
         */
        public static double function27(double densityMax, int Hs)
        {
            double Pbs = 0.00981 * densityMax * Hs;
            return Pbs;
        }

        /*
            @function 任意井深处套管最大内压力
            @Pbs double 套管鞋处的最大压力
            @param densityg 天然气相对密度
            @param Hs 套管下深或套管鞋深度
            @param h 计算点井深
            @return Pbh  计算点最大内压力
         */
        public static double function28(double Pbs, int Hs, int h, double densityg)
        {
            double Pbh = Pbs / (Math.Exp(0.00011155 * (Hs - h) * densityg) );
            return Pbh;
        }
        /*
            @function 有效内压力
            @param Pbh  计算点最大内压力
            @param densitys 地层水密度
            @param h 计算点井深
            @return Pe有效内压力
         */
        public static double fucntion29(double Pbh, double densitys, int h)
        {
            double Pbe = Pbh - 0.00981 * densitys * h;
            return Pbe;
        }

        ////@unction：有效内压力：气井：生产套管和生产尾管
        /* 
           @function :有效内压力：气井：生产套管和生产尾管
           @param Pp   底层或油层压力
           @param densitys 底层水密度
           @param h 计算点井深
           @return Pe' 有效内压力
        */
        public static double function31(double Pp, double densitys, int h)
        {
            //按管内全充满天然气考虑，
            double Pbh = Pp;
            //有效内压力
            double Pbe = Pbh - 0.00981 * densitys * h;
            return Pbe;
        }
        /*
            @function 预设井涌量,求气液界面处的压力
            @param densityMax 下次钻井最大钻井液密度
            @param Hs 套管下深或套管鞋深度
            @param Hmg 气液界面测量深度
            @return Pmg 气液界面处的压力
        */
        public static double function32(double densityMax, int Hs, int Hmg)
        {
            double Pbs = 0.09881 * densityMax * Hs;
            double Pmg = Pbs - 0.00981 * densityMax * (Hs - Hmg);
            return Pmg;
        }

        //油井：有效内压力：表层套管和技术套管

        /*
            @function 任一井深的套管最大内压力
            @param densityMax 下次钻井最大钻井液密度
            @param h 计算点井深
            @return Pbh  计算点最大内压力
         */
        public static double function33(double densityMax, int h)
        {
            //任意井深的套管最大内压力
            double Pbh = 0.00981 * densityMax * h;
            return Pbh;
        }
        /*
            @function 有效内压力
            @param Pbh  计算点最大内压力
            @param densityc 底层水密度
            @param h 计算点井深
            @return Pbe 有效内压力
         */
        public static double function34(double Pbh, double densityc, int h)
        {
            double Pbe = Pbh - 0.00981 * densityc * h;
            return Pbe;
        }

        /*
            @function 对不同油管生产，计算最大内压力
            @param Gp double 油层或底层压力梯度 
            @param Hs int 套管下深或套管鞋深度 
            @return bs  套管鞋处最大压力
         */
        public static double function35(double Gp, int Hs)
        {
            return Gp * Hs;
        }
        /*
            @function 任一井深处的最大内压力
            @param Pbs  套管鞋处最大压力
            @param Hs int 套管下深或套管鞋深度 
            @param h int 计算点井深
            @param densityg double天然气相对密度
            @return Pbh 套管鞋处最大内压力
         */
        public static double function36(double Pbs, int Hs, int h, double densityg)
        {
            double Pbh;
            Pbh = Pbs / Math.Exp(0.00011155 * (Hs - h)) * densityg;
            return Pbh;
        }
        /*
            @function 对油管生产用37计算最大内压力
            @param Pbs  套管鞋处最大压力
            @param densityw double 完井液密度
            @param h int 计算点井深 
            @return Pbh 套管鞋处最大内压力
            
         */
        public static double function37(double Pbs, double densityw, int h)
        {
            double Pbh;
            Pbh = Pbs + 0.00981 * densityw * h;
            return Pbh;
        }

        /*
            @function 有效内压力
            @param Pbh 计算点最大内压力
            @param densityc double 底层水密度
            @param h int 计算点井深 
            @return Pbe有效内压力
         */
        public static double Pbe(double Pbh, double densityc, int h)
        {
            double Pbe = Pbh - 0.00981 * densityc * h;
            return Pbe;
        }

        /*
           @function 有效外压力：直井 ：表层和技术套管:非塑性蠕变地层
           @param densitym double 固井时钻井液密度
           @param km double 掏空系数  0-1
           @param densitymin double 下次钻井最小钻井液密度
           @param h int 计算点井深
           @return Pce double  有效外压力
       */
        public static double function39(double densitym, double km, double densitymin, int h)
        {
            double Pce = 0.0098 * (densitym - (1 - km) * densitymin) * h;
            return Pce;
        }

        /*
            @function 有效外压力：直井 ：表层和技术套管:塑性蠕变地层
            @param v double 底层岩石泊松系数  0.3-0.5
            @param Gv double 上覆岩层压力梯度
            @param km double 掏空系数  0-1
            @param densitymin double 下次钻井最小钻井液密度
            @param h int 计算点井深
            @return Pce double  有效外压力
        */
        public static double function40(double v, double Gv, double km, double densitymin, int h)
        {
            double Pce = (v / (1 - v) * Gv - 0.00981 * (1 - km) * densitymin) * h;
            return Pce;
        }

        /*  
           @function 有效外压力 :直井：生产套管和生产尾管：非塑性蠕变底层
           @param densitym double 固井时钻井液密度
           @param km double 掏空系数  0-1
           @param densityw double 完井液密度
           @param h int 计算点井深
           @return Pce double  有效外压力
        */
        public static double function41(double densitym, double km, double densityw, int h)
        {
            double Pce = 0.00981 * (densitym - (1 - km) * densityw) * h;
            return Pce;
        }

        /*
           @function 有效外压力：直井 :生产套管和生产尾管:塑性蠕变地层
           @param v double 底层岩石泊松系数  0.3-0.5
           @param Gv double 上覆岩层压力梯度
           @param km double 掏空系数  0-1
           @param densityw double 完井液密度
           @param h int 计算点井深
           @return Pce double  有效外压力
       */
        public static double function42(double v, double Gv, double km, double densityw, int h)
        {
            double Pce = ((v / 1 - v) * Gv - 0.00981 * (1 - km) * densityw) * h;
            return Pce;
        }

        /* 
            @function 单位有效重量
            @param dLi int 第i管柱的长度
            @param q  double 第i段套管柱在空气中的单位长度质量
            @param densitym double 固井时钻井液密度
            @param densitys double 套管钢材密度 
            @return qei  double 第i段套管单位长度有效重量
         */
        public static double function43(double q, double densitym, double densitys)
        {


            double qei = q * (1 - densitym / densitys) * 9.81;

       
            return qei;
        }
        /*
            @function 用于二维井眼，求A
            @param u  double 摩阻系数
            @param qei 第i段套管单位长度有效重量
            @param R double 曲率半径
         */
        public static double GetA(double u, double qei, double R)
        {
            return (2 * u / (1 + Math.Pow(u, 2))) * qei * R;
        }
        /*
            @function 用于二维井眼，求B
            @param u  double 摩阻系数
            @param qei 第i段套管单位长度有效重量
            @param R double 曲率半径
         */
        public static double GetB(double u, double qei, double R)
        {
            return -(((1 - Math.Pow(u, 2)) / (1 + Math.Pow(u, 2))) * qei * R);
        }
        /*
            @function N
            @param qei 第i段套管单位长度有效重量
            @param beta double 第i管柱单元下端井斜角的余角
            @param Tei double  第i段套管受到的拉力
            @param R double 曲率半径
         */
        public static bool N(double qei, double beta, double tei, double R)
        {
            double N = qei * Math.Cos(beta) - tei / R;
            return N > 0;

        }
        /*
            @param Tei double  第i段套管受到的拉力
            @param A
            @param B
            @param u  double 摩阻系数
            @param beta double 第i管柱单元下端井斜角的余角
            @param betaiNext double 第i+1管柱单元下端井斜角的余角 即上一段的
            @return TeNext    
         */
        public static double function45(double tei, double A, double B, double beta, double betaNext, double u)
        {
            return (tei - A * Math.Sin(beta) - B * Math.Cos(beta)) * Math.Exp(-u * (betaNext - beta)) + A * Math.Sin(betaNext) + B * Math.Cos(betaNext);
        }
        /*
            @param Tei double  第i段套管受到的拉力
            @param A
            @param B
            @param u  double 摩阻系数
            @param beta double 第i管柱单元下端井斜角的余角
            @param betaiNext double 第i+1管柱单元下端井斜角的余角 即上一段的
            @return TeNext    
         */
        public static double function46(double tei, double A, double B, double beta, double betaNext, double u)
        {
            return (tei + A * Math.Sin(beta) - B * Math.Cos(beta)) * Math.Exp(u * (betaNext - beta)) - A * Math.Sin(betaNext) + B * Math.Cos(betaNext);
        }
        /*
            @function 降斜井段拉力
            @param Tei double  第i段套管受到的拉力
            @param A
            @param B
            @param alpha double 第i管柱单元下端的井斜角
            @param alphaNext double 第i+1管柱单元下端的井斜角
            @param u  double 摩阻系数
            
            
         */
        public static double function47(double tei, double A, double B, double alpha, double alphaNext, double u)
        {
            return (tei + A * Math.Cos(alpha) + B * Math.Sin(alpha)) * Math.Exp(u * (alphaNext - alpha)) - A * Math.Cos(alphaNext) - B * Math.Sin(alphaNext);
        }

        /*
            @function 稳斜井段
            @param Tei double  第i段套管受到的拉力
            @param alphai double 第i管柱单元下端的井斜角
            @param u double 摩阻系数
            @param Li int 管柱单元上端井深
            @param LiNext int i+1管柱单元上端井深
            @param qsi  double 第i段套管柱在空气中的单位长度重量
            @param densitym double 固井时钻井液密度
            @param densitys double 套管钢材密度
            @return TeiNext

         */
        public static double function48(double Tei, double alphai, double u, double L, double qei)
        {

            double TeiNext = Tei + qei * (Math.Cos(alphai) + u * Math.Sin(alphai)) * L;
            return TeiNext;
        }








    }
}
