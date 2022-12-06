// See https://aka.ms/new-console-template for more information

Console.WriteLine(Kata.MidEndian(0));

internal class Kata
{
    public static string MidEndian(long n)
    {
        var hexValueInBigEndian = n.ToString("X");

        if (hexValueInBigEndian.Length == 1)
        {
            hexValueInBigEndian = $"0{hexValueInBigEndian}";
        }

        var leftPart = string.Empty;
        var middlePart = string.Empty;
        var rightPart = string.Empty;

        string midEndian;

        if (hexValueInBigEndian.Length == 2)
        {
            midEndian = hexValueInBigEndian;
        }
        else
        {
            midEndian = $"{leftPart}{middlePart}{rightPart}";
        }

        return midEndian;
    }
}