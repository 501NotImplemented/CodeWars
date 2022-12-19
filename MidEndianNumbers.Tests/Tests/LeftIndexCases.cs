using System.Collections;

namespace MidEndianNumbers.Tests.Tests
{
    internal class LeftIndexCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
                             {
                                 658188, new List<int>
                                             {
                                                 1, 2
                                             },
                                 new List<string>
                                     {
                                         "0C", "0B", "0A"
                                     },
                                 0
                             };

            yield return new object[]
                             {
                                 9999999, new List<int>
                                              {
                                                  2, 3
                                              },
                                 new List<string>
                                     {
                                         "7F", "96", "98"
                                     },
                                 2
                             };
            yield return new object[]
                             {
                                 168496141, new List<int>(), new List<string>
                                                                 {
                                                                     "0D", "0C", "0B", "0A"
                                                                 },
                                 0
                             };
            yield return new object[]
                             {
                                 43135012110, new List<int>
                                                  {
                                                      1
                                                  },
                                 new List<string>
                                     {
                                         "0E",
                                         "0D",
                                         "0C",
                                         "0B",
                                         "0A"
                                     },
                                 0
                             };
        }
    }
}