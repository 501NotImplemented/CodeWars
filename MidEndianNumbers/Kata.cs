// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine(Kata.MidEndian(168496141));

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
        char[] hexChars = string.Concat(hexSplitIntoPairs).ToCharArray();
        var middleCharIndex = 0; // GetMiddlePairIndex(hexChars);
        Console.WriteLine($"Middle char index is {middleCharIndex}");
        var middleChar = Convert.ToString(hexChars[middleCharIndex]);

        // midEndianBuilder.Append(middleChar);
        string midEndian;

        if (hexChars.Length > 1)
        {
            Dictionary<string, List<int>> indexes = GetIndexes(hexChars);

            string leftPair = GetLeftPair(hexChars);

            //// 96987F
            //// act 698
            midEndianBuilder.Append(leftPair);

            Console.Write(middleCharIndex);
            midEndianBuilder.Append(middleChar);

            string rightPair = GetRightPair(hexChars, middleCharIndex);
            midEndianBuilder.Append(rightPair);
            midEndian = midEndianBuilder.ToString();

            // 69867F
            // 0D0B0A0C
            // 0D0B0A0C0E
        }
        else
        {
            midEndian = middleChar;
        }

        // 2-3-0-1-4-5 9999999
        // 6-7-2-3-0-1-4-5 168496141
        // 6-7-2-3-0-1-4-5-8-9 43135012110
        return midEndian;
    }

    private static Stack<int> GetEvenIndexes(char[] input)
    {
        Stack<int> evenIndexesStack = new();
        List<int> result = Enumerable.Range(1, input.Length - 1).Where(IsEven).Select(i => i).ToList();
        result.ForEach(evenIndexesStack.Push);
        return evenIndexesStack;
    }

    private static Dictionary<string, List<int>> GetIndexes(char[] input)
    {
        Stack<int> evenIndexes = GetEvenIndexes(input);
        Stack<int> oddIndexes = GetOddIndexes(input);

        Dictionary<string, List<int>> indexes = new()
                                                    {
                                                        {
                                                            "Left", new List<int>()
                                                        },
                                                        {
                                                            "Right", new List<int>()
                                                        }
                                                    };

        // 6-7-2-3-0-1-4-5
        for (var i = 0; i < input.Length; i++)
        {
            if (evenIndexes.Count > 0)
            {
                if (IsEven(i))
                {
                    indexes["Left"].Add(evenIndexes.Pop());
                    indexes["Right"].Add(oddIndexes.Pop());
                }
                else
                {
                    IEnumerable<int> reversedOddCollection = oddIndexes.Reverse();
                    Queue<int> reversedOddQue = new(reversedOddCollection);
                    oddIndexes = new Stack<int>(reversedOddQue);
                    indexes["Left"].Add(reversedOddQue.Dequeue());

                    // IEnumerable<int> reversedEvenCollection = evenIndexes.Reverse();
                    // Queue<int> reversedEvenQue = new(reversedEvenCollection);
                    // evenIndexes = new Stack<int>(reversedEvenQue);
                    indexes["Right"].Add(evenIndexes.Pop());
                }
            }
            else
            {
                Console.WriteLine($"Indexes left: {oddIndexes.Count}");
            }
        }

        return indexes;
    }

    private static List<int> GetLeftIndexes(char[] input)
    {
        int leftLength = GetLeftPartLength(input);

        List<int> result = new();

        // for (var i = 0; i <= leftLength; i++)
        // {
        // if (IsEven(i))
        // {
        // indexes["Left"].Add(evenIndexes.Pop());
        // }
        // else
        // {
        // IEnumerable<int> collection = oddIndexes.Reverse();
        // Queue<int> reversed = new(collection);
        // oddIndexes = new Stack<int>(reversed);
        // indexes["Left"].Add(reversed.Dequeue());
        // }
        // }

        // Get right indexes
        int rightLength = input.Length - (leftLength + 1);

        // for (var i = 0; i <= rightLength; i++)
        // {
        // if (IsEven(i))
        // {
        // indexes["Right"].Add(oddIndexes.Pop());
        // }
        // else
        // {
        // indexes["Right"].Add(oddIndexes.Pop());
        // }
        // }

        // 6-7-2-3-0-1-4-5

        // 2-3-
        // 6-7-2-3-
        // result = indexes["Left"];
        return result;
    }

    private static string GetLeftPair(char[] input)
    {
        var leftPairStartIndex = 0;
        var leftPairBuilder = new StringBuilder();

        List<int> leftIndexes = GetLeftIndexes(input);

        // 2-3
        // 6-7-2-3-
        for (int i = leftIndexes.Count; i >= leftPairStartIndex; i--)
        {
            int leftIndex = i;
            Console.Write($"{leftIndex}-");
            leftPairBuilder.Append(input[leftIndex]);
        }

        var leftPair = leftPairBuilder.ToString();
        return leftPair;
    }

    private static int GetLeftPartLength(char[] input)
    {
        var middlePartLength = 1;
        int restOfTheStringLength = input.Length - middlePartLength;
        bool isLengthEven = IsEven(restOfTheStringLength);
        var leftPartLength = 0;

        if (isLengthEven)
        {
            leftPartLength = restOfTheStringLength / 2;
        }
        else
        {
            leftPartLength = restOfTheStringLength / 2 - 1;
        }

        return leftPartLength;
    }

    private static int GetMiddlePairIndex(char[] hexChars)
    {
        int index = -1;

        for (var i = 0; i <= 9; i++)
        {
            var predicate = Convert.ToString(i);
            index = hexChars.ToList().LastIndexOf(char.Parse(predicate));

            bool indexFound = index != -1;
            if (indexFound)
            {
                break;
            }
        }

        return index;
    }

    private static Stack<int> GetOddIndexes(char[] input)
    {
        Stack<int> oddIndexesStack = new();
        List<int> oddIndexList = Enumerable.Range(1, input.Length - 1).Where(IsOdd).Select(i => i).Reverse().ToList();
        oddIndexList.ForEach(oddIndexesStack.Push);
        return oddIndexesStack;
    }

    private static IEnumerable<int> GetRightIndexes(char[] input)
    {
        IEnumerable<int> result = GetEvenIndexes(input);

        // IEnumerable<int> result = Enumerable.Range(startIndex, endIndex).Select(i => i);
        return result;
    }

    private static string GetRightPair(char[] input, int middleCharIndex)
    {
        int rightPairStartIndex = middleCharIndex + 1;
        var rightPairBuilder = new StringBuilder();
        IEnumerable<int> rightIndexes = GetRightIndexes(input);

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