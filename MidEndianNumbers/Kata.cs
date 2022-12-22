using System.Text;

namespace MidEndianNumbers;

public static class Kata
{
    public static byte[] GetConvertedBytes(long input)
    {
        byte[] converted = BitConverter.GetBytes(input);

        if (converted.Length > 1)
        {
            List<int> nonZeroByteIndexes = Enumerable.Range(0, converted.Length).Where(i => converted[i] != 0).ToList();
            List<byte> transformed = converted.ToList();
            if (nonZeroByteIndexes.Count > 0)
            {
                transformed.RemoveAll(x => x.Equals(0));
            }

            converted = transformed.ToArray();
        }

        Console.WriteLine($"Converted byte array: {BitConverter.ToString(converted)}");
        return converted;
    }

    public static int GetIndexOfMostSignificantByte(byte[] convertedBytes)
    {
        Console.WriteLine("Converted bytes:");
        for (var i = 0; i < convertedBytes.Length; i++)
        {
            Console.WriteLine(
                $"Byte '{convertedBytes[i]}' with hex value '{convertedBytes[i].ToString("X")}' has index '{i}'");
        }

        bool isLittleEndian = BitConverter.IsLittleEndian;

        byte mostSignificantByte;
        if (isLittleEndian)
        {
            // MSB in little-endian is the smallest
            mostSignificantByte = convertedBytes.Min();
        }
        else
        {
            mostSignificantByte = convertedBytes.Max();
        }

        int indexOfMostSignificantPair = Array.IndexOf(convertedBytes, mostSignificantByte);
        Console.WriteLine($"Index of most significant byte is {indexOfMostSignificantPair}");
        return indexOfMostSignificantPair;
    }

    public static string GetMiddlePair(int indexOfMostSignificantPair, List<string> hexSplitIntoPairs)
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

    public static string MidEndian(long n)
    {
        byte[] convertedBytes = GetConvertedBytes(n);
        int indexOfMostSignificantPair = GetIndexOfMostSignificantByte(convertedBytes);
        List<string> hexSplitIntoPairs = SplitBytesIntoHexPairs(convertedBytes);

        string middlePair = GetMiddlePair(indexOfMostSignificantPair, hexSplitIntoPairs);

        string midEndian;
        var midEndianBuilder = new StringBuilder();
        var leftPairBuilder = new StringBuilder();
        var rightPairBuilder = new StringBuilder();
        bool allBytesAreZeros = !convertedBytes.Any(x => x > 0);

        if (allBytesAreZeros)
        {
            midEndianBuilder.Append(hexSplitIntoPairs[indexOfMostSignificantPair]);
        }
        else
        {
            Stack<string> restOfTheBytePairs = new();
            for (var i = 0; i < hexSplitIntoPairs.Count; i++)
            {
                if (i == indexOfMostSignificantPair)
                {
                    break;
                }

                restOfTheBytePairs.Push(hexSplitIntoPairs[i]);
            }

            for (var i = 0; restOfTheBytePairs.Count > 0; i++)
            {
                string hexPair = restOfTheBytePairs.Pop();

                if (IsEven(i))
                {
                    Console.WriteLine($"Insert {hexPair} to the left, index {i}");
                    leftPairBuilder.Insert(0, hexPair);
                }
                else
                {
                    Console.WriteLine($"Insert {hexPair} to the right, index {i}");
                    rightPairBuilder.Append(hexPair);
                }
            }

            var leftPair = leftPairBuilder.ToString();
            var rightPair = rightPairBuilder.ToString();

            midEndianBuilder.Append(leftPair);
            midEndianBuilder.Append(middlePair);
            midEndianBuilder.Append(rightPair);
        }

        midEndian = midEndianBuilder.ToString();
        return midEndian;
    }

    private static bool IsEven(int number)
    {
        if (number % 2 == 0)
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

    private static List<string> SplitBytesIntoHexPairs(byte[] convertedBytes)
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

        Console.WriteLine();
        Console.WriteLine("Hex pairs");
        for (var i = 0; i < hexSplitIntoPairs.Count; i++)
        {
            Console.WriteLine($"Hex pair {hexSplitIntoPairs[i]} has index {i}");
        }

        return hexSplitIntoPairs;
    }
}