using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratornaya
{
    class Program
    {
        static void Main()
        {
            var s = new Sort();
            Timer.Sorting(s.BubbleSort);
            Timer.Sorting(s.QuickSorting);
            Timer.Sorting(s.TimSorting);
            Timer.Sorting(s.InsertionSort);
            Timer.Sorting(s.ShakerSort);
            Timer.Sorting(s.ShellSort);
            Timer.Sorting(s.CombSort);
            Timer.Sorting(s.GnomeSort);
            Timer.Sorting(s.MergeSort);
            Timer.Sorting(s.TreeSort);
            Timer.Sorting(Array.Sort);
            Timer.CreateDoc("TestBegin");

            Timer.Powing(Exponentiation.Cycle);
            Timer.Powing(Exponentiation.RecPow);
            Timer.Powing(Exponentiation.QuickPow);
            Timer.Powing(Exponentiation.QuickPowTwo);
            Timer.Powing(Exponentiation.MathPow);
            Timer.CreateDoc("Powing");
        }
    }
}
