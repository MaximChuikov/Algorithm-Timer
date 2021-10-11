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
            //Timer.Bogosort();
            //Console.WriteLine("Bogosort complete");
            //var s = new Sort();
            //Timer.Sort(s.InsertionSort);
            //Console.WriteLine("InsertionSort complete");
            //Timer.Sort(s.QuickSorting);
            //Console.WriteLine("QuickSorting complete");
            //Timer.BinarySearch();
            //Console.WriteLine("BinarySearch complete");
            //Timer.Backpack();
            //Console.WriteLine("Backpack complete");
            Timer.Daekstra();
            Console.WriteLine("Daekstra complete");
            Timer.CreateDoc("Daekstra final");
        }
    }
}
