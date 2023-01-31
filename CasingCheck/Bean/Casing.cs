using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check.Bean;

public class Casing
{
    public Casing()
    {
    }


    /*
       类型
       直段，造斜段，降斜段，稳斜段
     */
    public string Type { get; set; }
    /*
        段长，即测深
     */
    public int L { get; set; }
    /*
        上端的垂深
     */
   // public int ChuishenU { get; set; }
    /*
        下端垂深
     */
   // public int ChuishenD { get; set; }

    /*
        上端测深

     */
    public int ceshenU { get; set; }
    /*
        下端测深

     */
    public int ceshenD { get; set; }

    /*
        井斜角
        需要前端穿过来的直接是弧度进制 
        即  pi/180
     */
    public double JingXieJiao { get; set; }
    /*
        井斜角余角
        需要前端穿过来的直接是弧度进制 
        即  pi/180
     */
    public double JingXieJiaoYuJiao { get; set; }
    /*
        曲率半径
     */
    public double R { get; set; }

    public Casing(string type, int l, int ceshenU, int ceshenD, double jingXieJiao, double jingXieJiaoYuJiao, double r)
    {
        Type = type;
        L = l;
        this.ceshenU = ceshenU;
        this.ceshenD = ceshenD;
        JingXieJiao = jingXieJiao;
        JingXieJiaoYuJiao = jingXieJiaoYuJiao;
        R = r;
    }
}
