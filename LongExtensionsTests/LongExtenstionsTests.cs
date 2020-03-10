using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceResearch;

namespace LongExtensionsTests
{
    [TestClass]
    public class LongExtensionsTests
    {
        [TestMethod]
        public void TestMagnitudeMethods()
        {
            Func<long, long>[] funcs = new Func<long, long>[]
            {
                LongExtensions.MagnitudeByDivision,
                LongExtensions.MagnitudeByLog,
                LongExtensions.MagnitudeByMultiplication,
                LongExtensions.MagnitudeByMultiplication2,
                LongExtensions.MagnitudeByMultiplication3,
                LongExtensions.MagnitudeByRange,
                LongExtensions.MagnitudeByString,
                LongExtensions.MagnitudeBySwitch
            };

            foreach (Func<long, long> func in funcs)
            {
                Assert.IsTrue(func(0) == 1);
                Assert.IsTrue(func(1) == 1);
                Assert.IsTrue(func(9) == 1);
                Assert.IsTrue(func(10) == 10);
                Assert.IsTrue(func(11) == 10);
                Assert.IsTrue(func(19) == 10);
                Assert.IsTrue(func(99) == 10);
                Assert.IsTrue(func(100) == 100);
                Assert.IsTrue(func(101) == 100);
                Assert.IsTrue(func(999) == 100);
                Assert.IsTrue(func(long.MaxValue - 1) == 1000000000000000000);
                Assert.IsTrue(func(long.MaxValue) == 1000000000000000000);
            }
        }

        public void TestAppendMethods()
        {
            Func<long, long, long>[] funcs = new Func<long, long, long>[]
            {
                LongExtensions.AppendByConvertString,
                LongExtensions.AppendByConvertString2,
                LongExtensions.AppendByMagnitude,
                LongExtensions.AppendByParseString,
                LongExtensions.AppendByParseString2,
                LongExtensions.AppendByRange,
                LongExtensions.AppendByRangeChecked,
                LongExtensions.AppendLoop
            };

            foreach (Func<long, long, long> func in funcs)
            {
                Assert.IsTrue(func(0, 0) == 0);
                Assert.IsTrue(func(0, 1) == 1);
                Assert.IsTrue(func(1, 0) == 10);
                Assert.IsTrue(func(1, 1) == 11);
                Assert.IsTrue(func(1, 10) == 110);
                Assert.IsTrue(func(10, 1) == 101);
                Assert.IsTrue(func(10, 10) == 1010);
                Assert.IsTrue(func(0, long.MaxValue) == long.MaxValue);
                Assert.IsTrue(func(9, 223372036854775807) == long.MaxValue);
                Assert.IsTrue(func(9223372036, 854775807) == long.MaxValue);
                Assert.IsTrue(func(922337203685477580, 7) == long.MaxValue);
            }
        }
    }
}
