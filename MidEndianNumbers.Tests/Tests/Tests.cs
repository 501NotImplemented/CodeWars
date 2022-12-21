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
    [TestCase("10", 16)]
    [TestCase("1B04", 1051)]
    [TestCase("79DC0180", 31228025)]
    public void FixedTest(string expected, long input)
    {
        string actual = Kata.MidEndian(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    [TestCaseSource(typeof(LeftIndexCases))]
    public void GetIndexesReturnsCorrectLeftPart(
        long number,
        List<int> expectedLeftPart,
        List<string> input,
        int indexOfMostSignificantPair)
    {
        Dictionary<string, List<int>> allIndexes = Kata.GetIndexes(input, indexOfMostSignificantPair);
        List<int> actualLeftIndexes = allIndexes["Left"];
        expectedLeftPart.Should().BeEquivalentTo(actualLeftIndexes, $"Incorrect left indexes for {number}");
    }

    [Test]
    [TestCaseSource(typeof(RightIndexCases))]
    public void GetIndexesReturnsCorrectRightPart(
        long number,
        List<int> expectedRightPart,
        List<string> input,
        int indexOfMostSignificantPair)
    {
        Dictionary<string, List<int>> allIndexes = Kata.GetIndexes(input, indexOfMostSignificantPair);
        List<int> actualRightIndexes = allIndexes["Right"];
        actualRightIndexes.Should().BeEquivalentTo(expectedRightPart, $"Incorrect right indexes for {number}");
    }

    [TestCase(0, 0)]
    [TestCase(16, 0)]
    [TestCase(9999999, 2)]
    [TestCase(658188, 2)]
    [TestCase(1051, 0)]
    [TestCase(43135012110, 4)]
    [TestCase(31228025, 2)]
    [TestCase(168496141, 3)]
    public void MostSignificantByteIndexIsDeterminedCorrectly(long inputNumber, int expectedIndex)
    {
        List<byte> convertedBytes = Kata.GetConvertedBytes(inputNumber);
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

    [Test]
    public void SortLeftIndexesPerformsSorting()
    {
        List<int> input = new()
                              {
                                  2, 3, 6, 7
                              };

        List<int> expected = new()
                                 {
                                     6, 7, 2, 3
                                 };
        List<int> actual = Kata.SortLeftIndexes(input);
        CollectionAssert.AreEqual(expected, actual);
    }
}