// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine(Kata.MidEndian(658188));

//http://catb.org/jargon/html/M/middle-endian.html
internal class Kata
{
    public static Dictionary<string, List<int>> GetIndexes(List<string> input, int indexOfMostSignificantPair)
    {
        bool indexOfMostSignificantPairIsEven = IsEven(indexOfMostSignificantPair);
        List<int> evenIndexesList = GetEvenIndexes(input);
        List<int> oddIndexesList = GetOddIndexes(input);

        Dictionary<string, List<int>> indexes = new()
                                                    {
                                                        {
                                                            "Left", new List<int>()
                                                        },
                                                        {
                                                            "Right", new List<int>()
                                                        },
                                                        {
                                                            "Middle", new List<int>()
                                                        }
                                                    };
        indexes["Middle"].Add(indexOfMostSignificantPair);

        if (indexOfMostSignificantPairIsEven)
        {
            evenIndexesList.Remove(indexOfMostSignificantPair);
        }
        else
        {
            oddIndexesList.Remove(indexOfMostSignificantPair);
        }

        Stack<int> evenIndexesStack = new();
        Stack<int> oddIndexesStack = new();

        evenIndexesList.ForEach(evenIndexesStack.Push);
        oddIndexesList.ForEach(oddIndexesStack.Push);

        Queue<int> reversedEvenQueue = new();

        IEnumerable<int> reversedEvenCollection = evenIndexesStack.Reverse();
        reversedEvenQueue = new Queue<int>(reversedEvenCollection);

        for (var i = 0; i <= input.Count; i++)
        {
            if (IsOdd(i))
            {
                if (reversedEvenQueue.Count > 0)
                {
                    indexes["Left"].Add(reversedEvenQueue.Dequeue()); // Right
                }

                if (oddIndexesStack.Count > 0)
                {
                    indexes["Right"].Add(oddIndexesStack.Pop()); // Left
                }
            }
            else
            {
                if (oddIndexesStack.Count > 0)
                {
                    indexes["Left"].Add(oddIndexesStack.Pop()); // Right
                }

                if (reversedEvenQueue.Count > 0)
                {
                    indexes["Right"].Add(reversedEvenQueue.Dequeue()); // Left
                }
            }
        }

        if (oddIndexesStack.Count > 0)
        {
            for (var i = 0; oddIndexesStack.Count > 0; i++)
            {
                indexes["Right"].Add(oddIndexesStack.Pop()); // Left

                if (oddIndexesStack.Count == 0)
                {
                    break;
                }

                indexes["Left"].Add(oddIndexesStack.Pop()); // Right
            }
        }

        if (indexes["Left"].Count > 2)
        {
            // Left
            indexes["Left"] = SortLeftIndexes(indexes["Left"]); // Left
        }

        return indexes;
    }

    public static string MidEndian(long n)
    {
        List<byte> convertedBytes = BitConverter.GetBytes(n).ToList();
        int indexOfMostSignificantPair = convertedBytes.IndexOf(convertedBytes.Max());

        List<string> hexSplitIntoPairs = new();

        bool allBytesAre0 = !convertedBytes.Any(x => x > 0);

        if (allBytesAre0)
        {
            var hexValue = convertedBytes.First().ToString("X");
            hexValue = Pad0ForSingleDigit(hexValue);
            hexSplitIntoPairs.Add(hexValue);
        }
        else
        {
            foreach (byte convertedByteIntByte in convertedBytes.Where(x => x > 0))
            {
                var hexValue = convertedByteIntByte.ToString("X");
                hexValue = Pad0ForSingleDigit(hexValue);
                hexSplitIntoPairs.Add(hexValue);
            }
        }

        var midEndianBuilder = new StringBuilder();

        int middleCharIndex = indexOfMostSignificantPair;
        Console.WriteLine($"Middle char index is {middleCharIndex}");
        string middlePair;

        if (middleCharIndex == 0)
        {
            middlePair = Convert.ToString(hexSplitIntoPairs.First());
        }
        else
        {
            middlePair = Convert.ToString(hexSplitIntoPairs[middleCharIndex]);
        }

        string midEndian;

        if (allBytesAre0)
        {
            midEndianBuilder.Append(hexSplitIntoPairs[indexOfMostSignificantPair]);
        }
        else
        {
            if (indexOfMostSignificantPair == 0 && hexSplitIntoPairs.Count == 2)
            {
                return hexSplitIntoPairs[0] + hexSplitIntoPairs[1];
            }

            Dictionary<string, List<int>> indexes = GetIndexes(hexSplitIntoPairs, indexOfMostSignificantPair);
            List<int> leftIndexes = indexes["Left"];
            string leftPair = GetLeftPair(hexSplitIntoPairs, leftIndexes);
            midEndianBuilder.Append(leftPair);

            Console.Write(middleCharIndex);
            midEndianBuilder.Append(middlePair);

            List<int> rightIndexes = indexes["Right"];
            string rightPair = GetRightPair(hexSplitIntoPairs, rightIndexes);
            midEndianBuilder.Append(rightPair);
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

    private static List<int> GetEvenIndexes(List<string> input)
    {
        List<int> result = Enumerable.Range(0, input.Count).Where(IsEven).Select(i => i).ToList();
        return result;
    }

    private static string GetLeftPair(List<string> input, List<int> leftIndexes)
    {
        var leftPairBuilder = new StringBuilder();

        for (var i = 0; i < leftIndexes.Count; i++)
        {
            int leftIndex = leftIndexes[i];
            Console.Write($"{leftIndex}-");
            string value = input[leftIndex];
            leftPairBuilder.Append(value);
        }

        var leftPair = leftPairBuilder.ToString();
        return leftPair;
    }

    private static List<int> GetOddIndexes(List<string> input)
    {
        List<int> oddIndexList = Enumerable.Range(0, input.Count).Where(IsOdd).Select(i => i).Reverse().ToList();

        return oddIndexList;
    }

    private static string GetRightPair(List<string> input, List<int> rightIndexes)
    {
        var rightPairBuilder = new StringBuilder();

        foreach (int rightIndex in rightIndexes)
        {
            if (rightIndex < input.Count)
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

    private static string Pad0ForSingleDigit(string input)
    {
        if (input.Length == 1)
        {
            input = $"0{input}";
        }

        return input;
    }

    private static void Pad0ForSingleDigits(string[] inputHex)
    {
        for (var index = 0; index < inputHex.Length; index++)
        {
            string pair = inputHex[index];
            inputHex[index] = Pad0ForSingleDigit(pair);
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