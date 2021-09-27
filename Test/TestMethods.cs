using System;
using Xunit;
using Laboratornaya;
using System.Linq;
using System.Reflection;

namespace Test
{
    public class TestMethods
    {
        [Fact]
        void Clearing()
        {
            MethodInfo mI = typeof(Timer).GetMethod("ClearingData", BindingFlags.NonPublic | BindingFlags.Static);

            var a = new double[] { 40, 3, 5, 4, 5, 6, 4 };
            var test1 = new object[] { a };
            mI.Invoke(null, test1);
            Assert.Equal(new double[] { 3, 5, 4, 5, 6, 4 }.OrderBy(e => e), (double[])test1[0]);

            var b = new double[] { 0.01, 0.03, 0.02, 0.0344, 0.051, 0.05995959, 0.019 };
            var test2 = new object[] { b };
            mI.Invoke(null, test2);
            Assert.Equal(new double[] { 0.01, 0.02, 0.019 }.OrderBy(e => e), (double[])test2[0]);
        }
    }
}
