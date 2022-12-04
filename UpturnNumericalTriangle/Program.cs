// See https://aka.ms/new-console-template for more information

using System.Text;

Pattern.UpturnNumeralTriangle(16);
Console.ReadKey();

public class Pattern
{
    public static string UpturnNumeralTriangle(int n)
    {
        int lastHorizontalXCoordinate = n;
        int totalSymbolsInRow = lastHorizontalXCoordinate;
        var currentXCoordinate = 1;

        var stringBuilder = new StringBuilder();

        for (var row = 1; row <= n + 1; row++)
        {
            string line = DrawLineWithSpaces(row, currentXCoordinate, lastHorizontalXCoordinate, totalSymbolsInRow);
            stringBuilder.Append(line);

            if (row < n)
            {
                stringBuilder.Append("\n");
            }
        }

        var triangle = stringBuilder.ToString();
        return triangle;
    }

    private static string DrawLineWithSpaces(
        int currentRowNumber,
        int currentXCoordinate,
        int lastHorizontalXCoordinate,
        int totalSymbolsInRow)
    {
        int totalAmountOfSpaces = currentRowNumber;
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(DrawSpacesLeftOfSymbol(totalAmountOfSpaces));
        stringBuilder.Append(DrawSymbols(currentRowNumber,
            currentXCoordinate,
            lastHorizontalXCoordinate,
            totalSymbolsInRow,
            totalAmountOfSpaces));

        return stringBuilder.ToString().TrimEnd();
    }

    private static string DrawSpacesLeftOfSymbol(int totalAmountOfSpaces)
    {
        var stringBuilder = new StringBuilder();
        for (var spaceIndex = 1; spaceIndex <= totalAmountOfSpaces; spaceIndex++)
        {
            stringBuilder.Append(" ");
        }

        return stringBuilder.ToString();
    }

    private static string DrawSymbols(
        int currentRowNumber,
        int currentXCoordinate,
        int lastHorizontalXCoordinate,
        int totalSymbolsInRow,
        int totalAmountOfSpaces)
    {
        int amountOfNumbersToDraw = totalSymbolsInRow - totalAmountOfSpaces;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i <= amountOfNumbersToDraw; i++)
        {
            string currentSymbol = $"{currentRowNumber % 10} ";

            bool lastSymbol = currentXCoordinate == lastHorizontalXCoordinate;
            if (lastSymbol)
            {
                currentSymbol = $"{currentRowNumber}";
            }

            stringBuilder.Append(currentSymbol);
        }

        string symbols = stringBuilder.ToString().TrimEnd();
        return symbols;
    }
}