using NUnit.Framework;

internal class Tests
{
    [TestCase("96987F", 9999999)]
    [TestCase("00", 0)]
    [TestCase("0B0A0C", 658188)]
    [TestCase("0D0B0A0C", 168496141)]
    [TestCase("0D0B0A0C0E", 43135012110)]
    public void FixedTest(string expected, long input)
    {
        Assert.AreEqual(expected, Kata.MidEndian(input));
    }
}