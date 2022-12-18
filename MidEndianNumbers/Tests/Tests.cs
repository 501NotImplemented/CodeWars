using MidEndianNumbers.Tests;

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
    [TestCaseSource(typeof(LeftIndexCases))]
    public void GetIndexesReturnsCorrectLeftPart(List<int> expectedLeftPart, char[] input, long number)
    {
        Dictionary<string, List<int>> allIndexes = Kata.GetIndexes(input);
        List<int> actualLeftIndexes = allIndexes["Left"];

        CollectionAssert.AreEqual(expectedLeftPart, actualLeftIndexes, $"Incorrect left indexes for {number}");
    }

    [Test]
    [TestCaseSource(typeof(RightIndexCases))]
    public void GetIndexesReturnsCorrectRightPart(List<int> expectedRightPart, char[] input, long number)
    {
        Dictionary<string, List<int>> allIndexes = Kata.GetIndexes(input);
        List<int> actualRightIndexes = allIndexes["Right"];
        CollectionAssert.AreEqual(expectedRightPart, actualRightIndexes, $"Incorrect right indexes for {number}");
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