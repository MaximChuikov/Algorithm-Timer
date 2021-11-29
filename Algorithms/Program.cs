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
            string path = Environment.CurrentDirectory;
            Timer.TextSort(new string[] { path + "\\6000.txt", path + "\\12000.txt", path + "\\18000.txt",
                                          path + "\\24000.txt", path + "\\30000.txt", path + "\\36000.txt"});
            Timer.CreateDoc("TextTimering");
        }
    }
}
