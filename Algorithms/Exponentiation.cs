using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya
{
    public static class Exponentiation
    {
        public static double Cycle(double num, uint degree)
        {
            if (degree == 0)
                return 1;
            if (num == 0)
                return 0;

            double x = num;
            for (uint k = 1; k < degree; k++)
                x *= num;
            return x;
        }
        public static double RecPow(double x, uint deg)
        {
            double f;
            if (deg == 0)
                return 1;
            else
                f = RecPow(x, deg / 2);
            if (deg % 2 == 1)
                f = f * f * x;
            else f *= f;

            return f;
        }
        public static double QuickPow(double x, uint n)
        {
            double f;
            double c = x;
            uint k = n;
            if (k % 2 == 1)
                f = c;
            else
                f = 1;
            do
            {
                k /= 2;
                c *= c;
                if (k % 2 == 1)
                    f *= c;
            } while (k != 0);
            return f;
        }

        public static double QuickPowTwo(double num, uint degree)
        {
            var c = num;
            double f = 1;
            var k = degree;
            while(k != 0)
            {
                if (k % 2 == 0)
                {
                    c *= c;
                    k /= 2;
                }
                else
                {
                    f *= c;
                    k -= 1;
                }
            }
            return f;
        }
        public static double MathPow(double num, uint degree)
        {
            return Math.Pow(num, degree);
        }
    }
}
