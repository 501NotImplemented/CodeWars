using System.Text;

namespace MidEndianNumbers;

public static class Kata
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

        for (var i = 0; i < input.Count; i++)
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
            indexes["Left"] = SortLeftIndexes(indexes["Left"]);
        }

        return indexes;
    }

    public static string MidEndian(long n)
    {
        List<byte> convertedBytes = BitConverter.GetBytes(n).Where(x => x > 0).ToList();
        int indexOfMostSignificantPair = GetInDexOfMostSignificantByte(convertedBytes);

        List<string> hexSplitIntoPairs = SplitBytesIntoHexPairs(convertedBytes);

        string middlePair = GetMiddlePair(indexOfMostSignificantPair, hexSplitIntoPairs);

        string midEndian;
        var midEndianBuilder = new StringBuilder();

        if (!convertedBytes.Any(x => x > 0))
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

            Console.Write(indexOfMostSignificantPair);
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

    private static int GetInDexOfMostSignificantByte(List<byte> convertedBytes)
    {
        if (convertedBytes.Count == 0)
        {
            convertedBytes.Add(0);
        }

        byte mostSignificantByte = convertedBytes.Max();
        int indexOfMostSignificantPair = convertedBytes.IndexOf(mostSignificantByte);
        Console.WriteLine($"Index of most significant byte is {indexOfMostSignificantPair}");
        return indexOfMostSignificantPair;
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

    private static string GetMiddlePair(int indexOfMostSignificantPair, List<string> hexSplitIntoPairs)
    {
        string middlePair;

        if (indexOfMostSignificantPair == 0)
        {
            middlePair = Convert.ToString(hexSplitIntoPairs.First());
        }
        else
        {
            middlePair = Convert.ToString(hexSplitIntoPairs[indexOfMostSignificantPair]);
        }

        Console.WriteLine($"Most significant byte pair is {middlePair}");

        return middlePair;
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

    private static List<string> SplitBytesIntoHexPairs(List<byte> convertedBytes)
    {
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

        return hexSplitIntoPairs;
    }
}