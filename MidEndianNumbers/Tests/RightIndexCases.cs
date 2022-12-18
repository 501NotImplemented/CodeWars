using System.Collections;

namespace MidEndianNumbers.Tests
{
    internal class RightIndexCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
                             {
                                 new List<int>
                                     {
                                         1, 4, 5
                                     },
                                 new[]
                                     {
                                         '0', 'A', '0', 'B', '0', 'C'
                                     },
                                 658188
                             };

            yield return new object[]
                             {
                                 new List<int>
                                     {
                                         1, 4, 5
                                     },
                                 new[]
                                     {
                                         '9', '8', '9', '6', '7', 'F'
                                     },
                                 9999999
                             };
            yield return new object[]
                             {
                                 new List<int>
                                     {
                                         1, 4, 5
                                     },
                                 new[]
                                     {
                                         '0', 'A', '0', 'B', '0', 'C', '0', 'D'
                                     },
                                 168496141
                             };
            yield return new object[]
                             {
                                 new List<int>
                                     {
                                         1,
                                         4,
                                         5,
                                         8,
                                         9
                                     },
                                 new[]
                                     {
                                         '0', 'A', '0', 'B', '0', 'C', '0', 'D', '0', 'E'
                                     },
                                 43135012110
                             };
        }
    }
}