using NUnit.Framework;

namespace SumOfDigitsDigitalRoot.Tests
{
    [TestFixture]
    public class NumberTest
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(16, ExpectedResult = 7)]
        [TestCase(195, ExpectedResult = 6)]
        [TestCase(992, ExpectedResult = 2)]
        [TestCase(167346, ExpectedResult = 9)]
        [TestCase(999999999999, ExpectedResult = 9)]
        [TestCase(2958819262903, ExpectedResult = 1)]
        public int Tests(long n)
        {
            return Number.DigitalRoot(n);
        }
    }
}