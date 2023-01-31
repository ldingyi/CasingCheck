
using Check;
using Check.Bean;
using System.Collections.Generic;
using Xunit;


public class Test
{
   

    static void Main(string[] args)
    {
        Test test = new Test();
        List<Point> list = test.test5();
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i].deep + "   " + list[i].f + "\n");
        }
        
    }
    /*
        抗击 表层 气井 蠕变
     */
     List<Point> test1()
    {
        int[] ceshen = { 1500 };
        List<Point> list =CasingCheck.function6(0.35, 0.023, 0.85, 1.2, ceshen);
        return list;
    }
    /*
        抗内压，气井，表层
     */
    List<Point> test2()
    {
        int[] ceshen = { 0 };
        return CasingCheck.function1(1.45, 0.55, 3500, ceshen);

    }

/*
    直井 拉力
 */
   /* List<Point> test3()
    {
        int[] ceshen= {0};
        return CasingCheck.function7(101.2, 1.25, 7.85, 1500);
    }*/
    /*
        生产套管，抗挤压
     */
    List<Point> test4()
    {
        int[] ceshen= { 4500};
        return CasingCheck.function6(0.35, 0.023, 1, 1.25, ceshen);
    }

    List<Point> test5() 
    { 
        Casing casingc= new Casing("稳斜",3307,1600,4907,60*Math.PI/180,30*Math.PI/180,0);
        Casing casingb = new Casing("造斜",600,1000,1600,60 * Math.PI/180, 30* Math.PI/180,573);
        Casing casinga = new Casing("直段", 1000, 0, 1000, 0, 90*Math.PI/180, 0);
        List<Casing> casings = new List<Casing>();
        casings.Add(casinga);
        casings.Add(casingb);
        casings.Add(casingc);
        return CasingCheck.function8(43.16, 1.25, 7.85, 0.4, casings);

    }
    [Theory]
    public void test7()
    {
        Console.WriteLine(Math.Cos( Math.PI*60/180));
    }
}