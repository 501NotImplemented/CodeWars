// See https://aka.ms/new-console-template for more information

using System.Text;

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

        var leftPair = string.Empty;
        var rightPair = string.Empty;
        if (hexSplitIntoPairs.Length > 1)
        {
            leftPair = GetLeftPair(hexSplitIntoPairs);
            rightPair = GetRightPair(hexSplitIntoPairs);
        }

        midEndianBuilder.Append(leftPair);
        midEndianBuilder.Append(middlePair);
        midEndianBuilder.Append(rightPair);

        var midEndian = midEndianBuilder.ToString();

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

    private static string GetLeftPair(string[] input)
    {
        var leftPairStartIndex = 1;
        var leftPairBuilder = new StringBuilder();
        List<int> leftIndexes = GetLeftIndexes(leftPairStartIndex, input.Length - 1).ToList();

        for (int i = leftIndexes.Count; i >= leftPairStartIndex; i--)
        {
            int leftIndex = leftIndexes[i - 1];
            leftPairBuilder.Append(input[leftIndex]);
        }

        var leftPair = leftPairBuilder.ToString();
        return leftPair;
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

    private static string GetRightPair(string[] input)
    {
        var rightPairStartIndex = 2;
        var rightPairBuilder = new StringBuilder();
        IEnumerable<int> rightIndexes = GetRightIndexes(rightPairStartIndex, input.Length - 1);
        foreach (int rightIndex in rightIndexes)
        {
            if (rightIndex < input.Length)
            {
                rightPairBuilder.Append(input[rightIndex]);
            }
            else
            {
                break;
            }
        }

        var rightPair = rightPairBuilder.ToString();
        return rightPair;
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
            var zeroChar = '0';
            if (initialPair.Contains(zeroChar))
            {
                char initialFirstChar = initialPair[0];

                if (initialFirstChar != zeroChar)
                {
                    char[] swappedChars =
                        {
                            zeroChar, initialFirstChar
                        };

                    inputHex[index] = new string(swappedChars);
                }
            }
        }
    }
}