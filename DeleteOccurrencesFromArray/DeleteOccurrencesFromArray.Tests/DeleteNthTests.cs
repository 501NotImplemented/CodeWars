using NUnit.Framework;

namespace DeleteOccurrencesFromArray.Tests
{
    [TestFixture]
    public class DeleteNthTests
    {
        [Test]
        public void TestSimple()
        {
            var expected = new[]
                               {
                                   20, 37, 21
                               };

            var actual = Kata.DeleteNth(new[]
                                            {
                                                20, 37, 20, 21
                                            },
                1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSimple2()
        {
            var expected = new[]
                               {
                                   1, 1, 3, 3, 7, 2, 2, 2
                               };

            var actual = Kata.DeleteNth(new[]
                                            {
                                                1, 1, 3, 3, 7, 2, 2, 2, 2
                                            },
                3);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}