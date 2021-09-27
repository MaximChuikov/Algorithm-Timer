using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var gen = new NumGenerator();
            System.Diagnostics.Stopwatch clock = new();
            clock.Start();
            string a = gen.GetNum(n);
            clock.Stop();

            Console.WriteLine($"Для числа {n} ответом на задачу является: {a}");
            Console.WriteLine($"Время выполнения программы {(float)clock.ElapsedMilliseconds / 1000} секунд");
            Console.ReadKey();
        }
    }
    class NumGenerator
    {
        public string GetNum(int digit)
        {
            if (digit < 1 || digit > 9)
                throw new ArgumentException();

            int toIncrement = 0;
            var resultNum = new Stack<int>();
            resultNum.Push(digit);
            while (MultOn(resultNum.Peek(), digit, ref toIncrement) != digit)
            {
                resultNum.Push(MultOn(resultNum.Peek(), digit, ref toIncrement));
            }
            return GetString(resultNum);
        }
        private static int MultOn(int num, int mult, ref int toInc)
        {
            int temp = (num * mult + toInc) % 10;
            int toRet = (num * mult + toInc) / 10;
            toInc = toRet;
            return temp;
        }
        private static string GetString(Stack<int> stack)
        {
            var str = new StringBuilder();
            foreach (var n in stack)
                str.Append(n);
            return str.ToString();
        }
    }
}
