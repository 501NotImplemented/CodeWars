// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine(Kata.MidEndian(658188));

//http://catb.org/jargon/html/M/middle-endian.html
internal class Kata
{
    public static Dictionary<string, List<int>> GetIndexes(char[] input)
    {
        Stack<int> evenIndexes = GetEvenIndexes(input);
        Stack<int> oddIndexes = GetOddIndexes(input);

        Queue<int> reversedEvenQueue = new();
        Dictionary<string, List<int>> indexes = new()
                                                    {
                                                        {
                                                            "Left", new List<int>()
                                                        },
                                                        {
                                                            "Right", new List<int>()
                                                        }
                                                    };
        IEnumerable<int> reversedEvenCollection = evenIndexes.Reverse();
        reversedEvenQueue = new Queue<int>(reversedEvenCollection);

        for (var i = 0; reversedEvenQueue.Count > 0; i++)
        {
            if (IsOdd(i))
            {
                indexes["Right"].Add(reversedEvenQueue.Dequeue());

                if (reversedEvenQueue.Count == 0)
                {
                    break;
                }

                indexes["Left"].Add(oddIndexes.Pop());
            }
            else
            {
                indexes["Right"].Add(oddIndexes.Pop());
                indexes["Left"].Add(reversedEvenQueue.Dequeue());
            }
        }

        if (oddIndexes.Count > 0)
        {
            for (var i = 0; oddIndexes.Count > 0; i++)
            {
                indexes["Left"].Add(oddIndexes.Pop());

                if (oddIndexes.Count == 0)
                {
                    break;
                }

                indexes["Right"].Add(oddIndexes.Pop());
            }
        }

        if (indexes["Left"].Count > 2)
        {
            indexes["Left"] = SortLeftIndexes(indexes["Left"]);
        }

        return indexes;
    }

    public static string MidEndian(long n)
    {
        var hexValueInBigEndian = n.ToString("X");
        string[] hexSplitIntoPairs = SplitString(hexValueInBigEndian);

        Pad0ForSingleDigits(hexSplitIntoPairs);
        Swap0AndAddress(hexSplitIntoPairs);

        var midEndianBuilder = new StringBuilder();
        char[] hexChars = string.Concat(hexSplitIntoPairs).ToCharArray();
        var middleCharIndex = 0;
        Console.WriteLine($"Middle char index is {middleCharIndex}");
        var middleChar = Convert.ToString(hexChars[middleCharIndex]);

        string midEndian;

        if (hexChars.Length > 2)
        {
            Dictionary<string, List<int>> indexes = GetIndexes(hexChars);

            List<int> leftIndexes = indexes["Left"];
            string leftPair = GetLeftPair(hexChars, leftIndexes);

            midEndianBuilder.Append(leftPair);

            Console.Write(middleCharIndex);
            midEndianBuilder.Append(middleChar);

            List<int> rightIndexes = indexes["Right"];
            string rightPair = GetRightPair(hexChars, rightIndexes);
            midEndianBuilder.Append(rightPair);
        }
        else
        {
            foreach (char hexChar in hexChars)
            {
                midEndianBuilder.Append(hexChar);
            }
        }

        midEndian = midEndianBuilder.ToString();
        return midEndian;
    }

    public static List<int> SortLeftIndexes(List<int> input)
    {
        List<int> tempList = input;
        var nextIndex = 2;

        for (var currentIndex = 0; nextIndex < input.Count; currentIndex++, nextIndex++)
        {
            (tempList[currentIndex], tempList[nextIndex]) = (tempList[nextIndex], tempList[currentIndex]);
        }

        List<int> sortedIndexes = tempList;
        return sortedIndexes;
    }

    private static Stack<int> GetEvenIndexes(char[] input)
    {
        Stack<int> evenIndexesStack = new();
        List<int> result = Enumerable.Range(1, input.Length - 1).Where(IsEven).Select(i => i).ToList();
        result.ForEach(evenIndexesStack.Push);
        return evenIndexesStack;
    }

    private static string GetLeftPair(char[] input, List<int> leftIndexes)
    {
        var leftPairBuilder = new StringBuilder();

        for (var i = 0; i < leftIndexes.Count; i++)
        {
            int leftIndex = leftIndexes[i];
            Console.Write($"{leftIndex}-");
            char value = input[leftIndex];
            leftPairBuilder.Append(value);
        }

        var leftPair = leftPairBuilder.ToString();
        return leftPair;
    }

    private static Stack<int> GetOddIndexes(char[] input)
    {
        Stack<int> oddIndexesStack = new();
        List<int> oddIndexList = Enumerable.Range(1, input.Length - 1).Where(IsOdd).Select(i => i).Reverse().ToList();
        oddIndexList.ForEach(oddIndexesStack.Push);
        return oddIndexesStack;
    }

    private static string GetRightPair(char[] input, List<int> rightIndexes)
    {
        var rightPairBuilder = new StringBuilder();

        foreach (int rightIndex in rightIndexes)
        {
            if (rightIndex < input.Length)
            {
                Console.Write($"-{rightIndex}");
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

    private static bool IsEven(int number)
    {
        if (number % 2 == 0)
        {
            return true;
        }

        return false;
    }

    private static bool IsOdd(int number)
    {
        if (number % 2 != 0)
        {
            return true;
        }

        return false;
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