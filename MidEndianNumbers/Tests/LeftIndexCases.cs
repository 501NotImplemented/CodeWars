using System.Collections;

namespace MidEndianNumbers.Tests
{
    internal class LeftIndexCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
                             {
                                 new List<int>
                                     {
                                         2, 3
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
                                         2, 3
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
                                         6, 7, 2, 3
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
                                         6, 7, 2, 3
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