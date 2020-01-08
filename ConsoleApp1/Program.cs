using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //首先生成 x 点的向量，在区间 [0,2.5] 内等间距分布；然后计算这些点处的 erf(x)。
            //double[] x = Generate.LinearRange(start: 0, step: 0.1, stop: 2.5);
            double[] x = Generate.LinearRange(start: 1, step: 1, stop: 10);
            List<double> y = new List<double>();
            foreach (double x0 in x)
            {
                y.Add(SpecialFunctions.Erf(x0));
            }
            //确定 6 阶逼近多项式的系数。
            double[] p = Fit.Polynomial(x, y.ToArray(), order: 6);
            Write("p = ");
            foreach (double coefficient in p)
            {
                Write($"{coefficient:F2} ");
            }
            WriteLine();
            //为了查看拟合情况如何，在各数据点处计算多项式，并生成说明数据、拟合和误差的一个表。
            WriteLine();
            var funcP = Fit.PolynomialFunc(x, y.ToArray(), 6);
            WriteLine($"{"x",10}|{"y",10}|{"Fit",10}|{"FitError",10}");
            WriteLine($"{new string('-', 10)}|{new string('-', 10)}|{new string('-', 10)}|{new string('-', 10)}");
            foreach (double x0 in Generate.LinearRange(1, 1, 10))
            {
                double y0 = SpecialFunctions.Erf(x0);
                double fit = funcP(x0);
                double fitError = fit - y0;
                WriteLine($"{x0,10:F2}|{y0,10:F2}|{fit,10:F2}|{fitError,10:F2}");
            }
            ReadKey();



            /*
             *
             * using MathNet.Numerics;
            using System.Collections.Generic;
using static System.Console;
 
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            //首先生成 x 点的向量，在区间 [0,2.5] 内等间距分布；然后计算这些点处的 erf(x)。
            double[] x = Generate.LinearRange(start: 0, step: 0.1, stop: 2.5);
            List<double> y = new List<double>();
            foreach (double x0 in x)
            {
                y.Add(SpecialFunctions.Erf(x0));
            }
            //确定 6 阶逼近多项式的系数。
            double[] p = Fit.Polynomial(x, y.ToArray(), order: 6);
            Write("p = ");
            foreach (double coefficient in p)
            {
                Write($"{coefficient:F5} ");
            }
            WriteLine();
            //为了查看拟合情况如何，在各数据点处计算多项式，并生成说明数据、拟合和误差的一个表。
            WriteLine();
            var funcP = Fit.PolynomialFunc(x, y.ToArray(), 6);
            WriteLine($"{"x",10}|{"y",10}|{"Fit",10}|{"FitError",10}");
            WriteLine($"{new string('-', 10)}|{new string('-', 10)}|{new string('-', 10)}|{new string('-', 10)}");
            foreach (double x0 in Generate.LinearRange(0, 0.1, 1.5))
            {
                double y0 = SpecialFunctions.Erf(x0);
                double fit = funcP(x0);
                double fitError = fit - y0;
                WriteLine($"{x0,10:F4}|{y0,10:F4}|{fit,10:F4}|{fitError,10:F4}");
            }
        }
    }
}
             */

            


        }
    }
}
