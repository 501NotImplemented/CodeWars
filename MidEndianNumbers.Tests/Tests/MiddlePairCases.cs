using System.Collections;

namespace MidEndianNumbers.Tests.Tests
{
    internal class MiddlePairCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
                             {
                                 658188, 2, "0A", new List<string>
                                                      {
                                                          "0C", "0B", "0A"
                                                      }
                             };
            yield return new object[]
                             {
                                 9999999, 2, "98", new List<string>
                                                       {
                                                           "7F", "96", "98"
                                                       }
                             };
            yield return new object[]
                             {
                                 1051, 1, "1B", new List<string>
                                                    {
                                                        "04", "1B"
                                                    }
                             };
            yield return new object[]
                             {
                                 16, 0, "10", new List<string>
                                                  {
                                                      "10"
                                                  }
                             };
            yield return new object[]
                             {
                                 00, 0, "00", new List<string>
                                                  {
                                                      "00"
                                                  }
                             };
            yield return new object[]
                             {
                                 43135012110, 4, "0A", new List<string>
                                                           {
                                                               "0E",
                                                               "0D",
                                                               "0C",
                                                               "0B",
                                                               "0A"
                                                           }
                             };
        }
    }
}