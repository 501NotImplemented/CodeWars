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

    [Test]
    public void InputIsCorrectlyReversed()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void MidEndianReturns483F0DAD()
    {
        // actual 08FAD3D4
        Assert.AreEqual("483F0DAD", Kata.MidEndian(0));
    }

    [Test]
    public void MidEndianReturns4BAC06C6()
    {
        // actual 0BCC6A64
        Assert.AreEqual("4BAC06C6", Kata.MidEndian(0));
    }

    [Test]
    public void MidEndianReturnsA6E20625()
    {
        // actual 06226E5A
        Assert.AreEqual("A6E20625", Kata.MidEndian(0));
    }

    [Test]
    public void MidEndianReturnsAB05()
    {
        // actual 0B5A
        Assert.AreEqual("AB05", Kata.MidEndian(0));
    }
}