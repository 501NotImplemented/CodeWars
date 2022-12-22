using FluentAssertions;

using NUnit.Framework;

namespace MidEndianNumbers.Tests.Tests;

internal class Tests
{
    [TestCase("96987F", 9999999)]
    [TestCase("00", 0)]
    [TestCase("0B0A0C", 658188)]
    [TestCase("0D0B0A0C", 168496141)]
    [TestCase("0D0B0A0C0E", 43135012110)]
    public void FixedTest(string expected, long input)
    {
        string actual = Kata.MidEndian(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [TestCase(0, 0)]
    [TestCase(658188, 2)]
    [TestCase(168496141, 3)]
    [TestCase(43135012110, 4)]
    [TestCase(9999999, 2)]
    public void MostSignificantByteIndexIsDeterminedCorrectly(long inputNumber, int expectedIndex)
    {
        byte[] convertedBytes = Kata.GetConvertedBytes(inputNumber);
        int actual = Kata.GetIndexOfMostSignificantByte(convertedBytes);
        actual.Should().Be(expectedIndex);
    }

    [TestCaseSource(typeof(MiddlePairCases))]
    public void MostSignificantBytePairIsDeterminedCorrectly(
        long inputNumber,
        int middleIndex,
        string expectedPair,
        List<string> hexSplitIntoPairs)
    {
        string actual = Kata.GetMiddlePair(middleIndex, hexSplitIntoPairs);
        actual.Should().Be(expectedPair, $"Middle pair of {inputNumber} is {expectedPair}");
    }

    [TestCase("10", 16)]
    [TestCase("1B04", 1051)]
    [TestCase("79DC0180", 31228025)]
    [TestCase("D10E", 3793)]
    [TestCase("8D0C71", 822641)]
    [TestCase("6F0997", 618391)]
    [TestCase("73B60F31", 263598451)]
    public void RandomTest(string expected, long input)
    {
        string actual = Kata.MidEndian(input);
        actual.Should().BeEquivalentTo(expected);
    }
}