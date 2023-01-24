using NUnit.Framework;

namespace Array.Diff.Tests
{
    [TestFixture]
    public class SolutionTest
    {
        [TestCase(new[]
                      {
                          1, 2
                      },
            new[]
                {
                    1
                },
            new[]
                {
                    2
                })]
        [TestCase(new[]
                      {
                          1, 2, 2
                      },
            new[]
                {
                    1
                },
            new[]
                {
                    2, 2
                })]
        [Test]
        public void SampleTest(int[] a, int[] b, int[] expectedResult)
        {
            Assert.AreEqual(expectedResult, Kata.ArrayDiff(a, b));

            // Assert.AreEqual(new[]
            // {
            // 1
            // },
            // Kata.ArrayDiff(new[]
            // {
            // 1, 2, 2
            // },
            // new[]
            // {
            // 2
            // }));
            // Assert.AreEqual(new[]
            // {
            // 1, 2, 2
            // },
            // Kata.ArrayDiff(new[]
            // {
            // 1, 2, 2
            // },
            // new int[]
            // {
            // }));
            // Assert.AreEqual(new int[]
            // {
            // },
            // Kata.ArrayDiff(new int[]
            // {
            // },
            // new[]
            // {
            // 1, 2
            // }));
            // Assert.AreEqual(new[]
            // {
            // 3
            // },
            // Kata.ArrayDiff(new[]
            // {
            // 1, 2, 3
            // },
            // new[]
            // {
            // 1, 2
            // }));
        }
    }
}