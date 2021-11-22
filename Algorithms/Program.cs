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
            Timer.QueueEnqueChallenge();
            Timer.QueueRandomChallenge();
            Timer.CreateDoc("QueueChallenge");
        }
    }
}
