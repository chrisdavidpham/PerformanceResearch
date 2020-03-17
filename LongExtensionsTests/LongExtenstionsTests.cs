using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongExtensionsTests
{
    [TestClass]
    public class LongExtensionsTests
    {
        [TestMethod]
        public void TestMagnitudeByMultiplication()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByMultiplication);
        }
        [TestMethod]
        public void TestMagnitudeByMultiplication2()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByMultiplication2);
        }
        [TestMethod]
        public void TestMagnitudeByMultiplication3()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByMultiplication3);
        }
        [TestMethod]
        public void TestMagnitudeByRange()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByRange);
        }
        [TestMethod]
        public void TestMagnitudeBySwitch()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeBySwitch);
        }
        [TestMethod]
        public void TestMagnitudeByLog()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByLog);
        }
        [TestMethod]
        public void TestMagnitudeByDivision()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByDivision);
        }
        [TestMethod]
        public void TestMagnitudeByString()
        {
            TestMagnitudeMethod(LongExtensions.LongExtensions.MagnitudeByString);
        }
        public static void TestMagnitudeMethod(Func<long, long> func)
        {
            Assert.AreEqual(1, func(0));
            Assert.AreEqual(1, func(1));
            for (long i = 10; i < LongExtensions.LongExtensions.MAX_MAGNITUDE; i *= 10)
            {
                Assert.AreEqual(i/10, func(i - 1));
                Assert.AreEqual(i,    func(i));
                Assert.AreEqual(i,    func(i + 1));
            }
            Assert.AreEqual(100000000000000000,  func(999999999999999999));
            Assert.AreEqual(1000000000000000000, func(1000000000000000000));
            Assert.AreEqual(1000000000000000000, func(1000000000000000001));
            Assert.AreEqual(1000000000000000000, func(long.MaxValue - 1));
            Assert.AreEqual(1000000000000000000, func(long.MaxValue));
            Assert.AreEqual(100000000000000000,  func(-999999999999999999));
            Assert.AreEqual(1000000000000000000, func(-1000000000000000000));
            Assert.AreEqual(1000000000000000000, func(-1000000000000000001));
            Assert.AreEqual(1000000000000000000, func(-long.MaxValue + 1));
            Assert.AreEqual(1000000000000000000, func(-long.MaxValue));
        }

        [TestMethod]
        public void TestAppendByConvertString()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByConvertString);
        }
        [TestMethod]
        public void TestAppendByConvertString2()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByConvertString2);
        }
        [TestMethod]
        public void TestAppendByParseString()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByParseString);
        }
        [TestMethod]
        public void TestAppendByParseString2()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByParseString2);
        }
        [TestMethod]
        public void TestAppendByMagnitude()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByMagnitude);
        }
        [TestMethod]
        public void TestAppendByRange()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByRange);
        }
        [TestMethod]
        public void TestAppendByRangeChecked()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendByRangeChecked);
        }
        [TestMethod]
        public void TestAppendByLoop()
        {
            TestAppendMethod(LongExtensions.LongExtensions.AppendLoop);
        }

        public void TestAppendMethod(Func<long, long, long> func)
        {
            Assert.IsTrue(func(0, 0) == 0);
            Assert.IsTrue(func(0, 1) == 1);
            Assert.IsTrue(func(1, 0) == 10);
            Assert.IsTrue(func(1, 1) == 11);
            Assert.IsTrue(func(1, 10) == 110);
            Assert.IsTrue(func(10, 1) == 101);
            Assert.IsTrue(func(10, 10) == 1010);
            Assert.IsTrue(func(854775807, 9223372036) == 8547758079223372036);
            Assert.IsTrue(func(0, long.MaxValue) == long.MaxValue);
            Assert.IsTrue(func(9, 223372036854775807) == long.MaxValue);
            Assert.IsTrue(func(9223372036, 854775807) == long.MaxValue);
            Assert.IsTrue(func(922337203685477580, 7) == long.MaxValue);
            Assert.ThrowsException<OverflowException>(() => func(9223372036854775807, 0));
            Assert.ThrowsException<OverflowException>(() => func(922337203685477580, 8));
            Assert.ThrowsException<OverflowException>(() => func(92233720368547758, 10));
            Assert.ThrowsException<LongExtensions.LongAppendException>(() => func(-1, 0));
            Assert.ThrowsException<LongExtensions.LongAppendException>(() => func(0, -1));
            Assert.ThrowsException<LongExtensions.LongAppendException>(() => func(-1, -1));
        }
    }
}
