using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Laboratornaya
{
    class Program
    {
        static void Main()
        {
            int i = 13;
            int b = -2;
            do
            {
                Console.WriteLine(i);
                i--;
                i = i + b;
            }
            while (i >= 0);


            ////Timer.Bogosort();
            ////Console.WriteLine("Bogosort complete");
            ////var s = new Sort();
            ////Timer.Sort(s.InsertionSort);
            ////Console.WriteLine("InsertionSort complete");
            ////Timer.Sort(s.QuickSorting);
            ////Console.WriteLine("QuickSorting complete");
            ////Timer.BinarySearch();
            ////Console.WriteLine("BinarySearch complete");
            ////Timer.Backpack();
            ////Console.WriteLine("Backpack complete");
            //Timer.Daekstra();
            //Console.WriteLine("Daekstra complete");
            //Timer.CreateDoc("Daekstra final");
        }
    }
}
