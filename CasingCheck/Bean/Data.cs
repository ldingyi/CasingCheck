using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.Bean
{
    public class Data
    {

        /*
            井深
         */
        public int Hs { get; set; }
        /*
            固井时钻井液密度
         */
        public double densitym { get; set; }
        /*
            下层钻井液最大密度
         */
        public double densityMax { get; set; }
        /*
            下层钻井液最小密度
         */
        public double densityMin { get; set; }
        /*
            完井液密度
         */
        public double densityw { get; set; }
        /*
            封隔液密度
         */
        public double densityf { get; set; }
        /*
            地层水密度
        */
        public double densitys { get; set; }
        /*
            天然气相对密度
         */
        public double densityg { get; set; }
        /*
            地层压力梯度
         */
        public double Gp { get; set; }
        /*  
            地层或油层压力
         */
        public double Pp { get; set; }
        /*
            上覆岩层压力梯度
         */
        public double Gv { get; set; }
        /*
            破裂压力梯度
         */
        public double polie { get; set; }
        /*
            掏空系数
         */
        public double km { get; set; }
        /*
            井涌量
         */
        public double kick { get; set; }
        /*
            套管类型 表层套管 中间套管 生产套管
         */
        public String casingType { get; set; }
        /*
            油井类型  油井  气井
         */
        public String wellType { get; set; }

        /*
            是否为蠕变地层
            是为1不是为0
         */
        public int isRB { get; set; }
        /*
            岩石泊松系数
         */
        public double V { get; set; }
        /*
            线重
         */
        public double q { get; set; }
        /*  
            摩阻系数
         */
        public double u { get; set; }

        public Data()
        {
        }

        public Data(int hs, double densitym, double densityMax, double densityMin, double densityw, double densityf, double densitys, double densityg, double gp, double gv, double polie, double km, double kick, string casingType, string wellType, int isRB, double v, double q, double u, double pp)
        {
            Hs = hs;
            this.densitym = densitym;
            this.densityMax = densityMax;
            this.densityMin = densityMin;
            this.densityw = densityw;
            this.densityf = densityf;
            this.densitys = densitys;
            this.densityg = densityg;
            Gp = gp;
            Gv = gv;
            this.polie = polie;
            this.km = km;
            this.kick = kick;
            this.casingType = casingType;
            this.wellType = wellType;
            this.isRB = isRB;
            V = v;
            this.q = q;
            this.u = u;
            Pp = pp;
        }
    }
}

