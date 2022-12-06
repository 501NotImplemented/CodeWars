// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine(Kata.MidEndian(168496141));

internal class Kata
{
    public static string MidEndian(long n)
    {
        var hexValueInBigEndian = n.ToString("X");
        string[] hexSplitIntoPairs = SplitString(hexValueInBigEndian);

        Pad0ForSingleDigits(hexSplitIntoPairs);

        var sb = new StringBuilder();
        for (var index = 0; index < hexSplitIntoPairs.Length; index++)
        {
            string pair = hexSplitIntoPairs[index];
            sb.Append(pair);
        }

        var midEndian = sb.ToString();

        // 0D0B0A0C
        return midEndian;
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
}