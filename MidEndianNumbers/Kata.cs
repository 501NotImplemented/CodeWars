// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine(Kata.MidEndian(658188));

//http://catb.org/jargon/html/M/middle-endian.html
internal class Kata
{
    public static string MidEndian(long n)
    {
        var hexValueInBigEndian = n.ToString("X");
        string[] hexSplitIntoPairs = SplitString(hexValueInBigEndian);

        Pad0ForSingleDigits(hexSplitIntoPairs);
        Swap0AndAddress(hexSplitIntoPairs);

        var midEndianBuilder = new StringBuilder();
        var middlePairIndex = 0;
        string middlePair = hexSplitIntoPairs[middlePairIndex];

        var leftPairStartIndex = 1;
        var rightPairStartIndex = 2;

        var leftPairBuilder = new StringBuilder();
        var rightPairBuilder = new StringBuilder();

        if (hexSplitIntoPairs.Length > 1)
        {
            IEnumerable<int> leftIndexes = GetLeftIndexes(leftPairStartIndex, hexSplitIntoPairs.Length - 1);
            foreach (int leftIndex in leftIndexes)
            {
                leftPairBuilder.Append(hexSplitIntoPairs[leftIndex]);
            }

            IEnumerable<int> rightIndexes = GetRightIndexes(rightPairStartIndex, hexSplitIntoPairs.Length - 1);
            foreach (int rightIndex in rightIndexes)
            {
                rightPairBuilder.Append(hexSplitIntoPairs[rightIndex]);
            }
        }

        var leftPair = leftPairBuilder.ToString();
        var rightPair = rightPairBuilder.ToString();

        midEndianBuilder.Append(leftPair);
        midEndianBuilder.Append(middlePair);
        midEndianBuilder.Append(rightPair);

        var midEndian = midEndianBuilder.ToString();

        // 0B0A0C 658188 1-0-2
        // 0D0B0A0C 168496141 3-1-0-2
        // 0D0B0A0C0E 43135012110 3-1-0-2-4
        // 96987F 9999999 1-0-2
        return midEndian;
    }

    private static bool GetEven(int number)
    {
        if (number % 2 == 0)
        {
            return true;
        }

        return false;
    }

    private static IEnumerable<int> GetLeftIndexes(int startIndex, int endIndex)
    {
        IEnumerable<int> result = Enumerable.Range(startIndex, endIndex).Where(GetOdd).Select(i => i);
        return result;
    }

    private static bool GetOdd(int number)
    {
        if (number % 2 != 0)
        {
            return true;
        }

        return false;
    }

    private static IEnumerable<int> GetRightIndexes(int startIndex, int endIndex)
    {
        IEnumerable<int> result = Enumerable.Range(startIndex, endIndex).Where(GetEven).Select(i => i);
        return result;
    }

    private static void Pad0ForSingleDigits(string[] inputHex)
    {
        for (var index = 0; index < inputHex.Length; index++)
        {
            string pair = inputHex[index];
            if (pair.Length == 1)
            {
                inputHex[index] = $"0{pair}";
            }
        }
    }

    private static string[] SplitString(string input)
    {
        var output = new string[input.Length / 2 + (input.Length % 2 == 0 ? 0 : 1)];

        for (var i = 0; i < output.Length; i++)
        {
            output[i] = input.Substring(i * 2, i * 2 + 2 > input.Length ? 1 : 2);
        }

        return output;
    }

    private static void Swap0AndAddress(string[] inputHex)
    {
        for (var index = 0; index < inputHex.Length; index++)
        {
            char[] initialPair = inputHex[index].ToCharArray();
            if (initialPair.Contains('0'))
            {
                char initialFirstChar = initialPair[0];

                if (initialFirstChar != '0')
                {
                    char[] swappedChars =
                        {
                            '0', initialFirstChar
                        };

                    inputHex[index] = new string(swappedChars);
                }
            }
        }
    }
}