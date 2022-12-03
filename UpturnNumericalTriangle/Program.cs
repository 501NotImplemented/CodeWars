// See https://aka.ms/new-console-template for more information

using System.Text;

Pattern.UpturnNumeralTriangle(16);
Console.ReadKey();

public class Pattern
{
    public static string UpturnNumeralTriangle(int n)
    {
        int lastHorizontalXCoordinate = n;
        int lastVerticalYCoordinate = n;
        int totalSymbolsInRow = lastHorizontalXCoordinate;
        var currentXCoordinate = 1;

        var stringBuilder = new StringBuilder();

        for (var row = 1; row < n + 1; row++)
        {
            int symbol = row % 10;
            DrawLineWithSpaces(row,
                currentXCoordinate,
                lastVerticalYCoordinate,
                lastHorizontalXCoordinate,
                totalSymbolsInRow);

            stringBuilder.Append(symbol);
        }

        var triangle = stringBuilder.ToString();
        return triangle;
    }

    private static int DrawLineWithSpaces(
        int currentRowNumber,
        int currentXCoordinate,
        int lastVerticalYCoordinate,
        int lastHorizontalXCoordinate,
        int totalSymbolsInRow)
    {
        int totalAmountOfSpaces = currentRowNumber - 1;

        DrawSpacesLeft(totalAmountOfSpaces);

        DrawRestOfTheSymbols(currentRowNumber,
            currentXCoordinate,
            lastHorizontalXCoordinate,
            totalSymbolsInRow,
            totalAmountOfSpaces);

        Console.WriteLine();

        lastVerticalYCoordinate--;
        return lastVerticalYCoordinate;
    }

    private static void DrawRestOfTheSymbols(
        int currentRowNumber,
        int currentXCoordinate,
        int lastHorizontalXCoordinate,
        int totalSymbolsInRow,
        int totalAmountOfSpaces)
    {
        int amountOfNumbersToDraw = totalSymbolsInRow - totalAmountOfSpaces;

        for (var i = 0; i < amountOfNumbersToDraw; i++)
        {
            string currentSymbol = $"{currentRowNumber % 10} ";

            bool lastSymbol = currentXCoordinate == lastHorizontalXCoordinate;
            if (lastSymbol)
            {
                currentSymbol = $"{currentRowNumber}";
            }

            Console.Write(currentSymbol);
        }
    }

    private static void DrawSpacesLeft(int totalAmountOfSpaces)
    {
        for (var spaceIndex = 0; spaceIndex < totalAmountOfSpaces; spaceIndex++)
        {
            Console.Write(" ");
        }
    }
}