using System;
using System.Collections.Generic;
using Xunit;
using Laboratornaya;
using System.Linq;

namespace Test
{
    public class TestExp
    {
        [Fact]
        void ExpRec()
        {
            Assert.Equal(1ul, Exponentiation.RecPow(999, 0));
            Assert.Equal(1024ul, Exponentiation.RecPow(2, 10));
            Assert.Equal(9ul, Exponentiation.RecPow(3, 2));
            Assert.Equal(2357947691ul, Exponentiation.RecPow(11, 9));
        }
        [Fact]
        void ExpCyc()
        {
            Assert.Equal(1ul, Exponentiation.Cycle(999, 0));
            Assert.Equal(1024ul, Exponentiation.Cycle(2ul, 10u));
            Assert.Equal(9ul, Exponentiation.Cycle(3, 2));
            Assert.Equal(2357947691ul, Exponentiation.Cycle(11, 9));
        }
        [Fact]
        void ExpQuick1()
        {
            Assert.Equal(1ul, Exponentiation.QuickPow(999, 0));
            Assert.Equal(1024ul, Exponentiation.QuickPow(2, 10));
            Assert.Equal(9ul, Exponentiation.QuickPow(3, 2));
            Assert.Equal(2357947691ul, Exponentiation.QuickPow(11, 9));
        }
        [Fact]
        void ExpQuick2()
        {
            Assert.Equal(1ul, Exponentiation.QuickPowTwo(999, 0));
            Assert.Equal(1024ul, Exponentiation.QuickPowTwo(2, 10));
            Assert.Equal(9ul, Exponentiation.QuickPowTwo(3, 2));
            Assert.Equal(2357947691ul, Exponentiation.QuickPowTwo(11, 9));
        }
    }
}
