using FluentAssertions;

using NUnit.Framework;

namespace MidEndianNumbers.Tests.Tests;

internal class Tests
{
    [TestCase("96987F", 9999999)]
    [TestCase("00", 0)]
    [TestCase("0B0A0C", 658188)] // 1-2-0
    [TestCase("0D0B0A0C", 168496141)] // 0-2-3-1
    [TestCase("0D0B0A0C0E", 43135012110)] // 1-3-4-2-0
    [TestCase("10", 16)]
    [TestCase("1B04", 1051)]
    [TestCase("79DC0180", 31228025)] // 0-2-3-1
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