// See https://aka.ms/new-console-template for more information

Pattern.UpturnNumeralTriangle(16);
Console.ReadKey();

public class Pattern
{
    public static string UpturnNumeralTriangle(int n)
    {
        int lastHorizontalXCoordinate = n;
        int lastVerticalYCoordinate = n;
        int totalSymbolsInLine = lastHorizontalXCoordinate;
        var currentXCoordinate = 1;
        var currentLineNumber = 1;

        DrawFirstLine(lastHorizontalXCoordinate, currentXCoordinate, currentLineNumber, totalSymbolsInLine);
        currentLineNumber++;

        DrawRestOfTheLines(n, currentLineNumber, currentXCoordinate, lastVerticalYCoordinate);

        var triangle = string.Empty;
        return triangle;
    }

    private static void DrawFirstLine(
        int lastHorizontalXCoordinate,
        int currentXCoordinate,
        int currentLineNumber,
        int totalSymbolsInLine)
    {
        DrawLine(lastHorizontalXCoordinate, currentXCoordinate, currentLineNumber, totalSymbolsInLine);
        Console.WriteLine();
    }

    private static void DrawLine(
        int lastHorizontalXCoordinate,
        int currentXCoordinate,
        int currentLineNumber,
        int totalSymbolsInLine)
    {
        int amountOfNumbersToDraw = totalSymbolsInLine;
        for (var i = 0; i < amountOfNumbersToDraw; i++)
        {
            string currentSymbol = $"{currentLineNumber} ";

            bool lastSymbol = currentXCoordinate == lastHorizontalXCoordinate;
            if (lastSymbol)
            {
                currentSymbol = $"{currentLineNumber}";
            }

            Console.Write(currentSymbol);
        }
    }

    private static int DrawLineWithSpaces(
        int currentLineNumber,
        int currentXCoordinate,
        int lastVerticalYCoordinate,
        int lastHorizontalXCoordinate,
        int totalSymbolsInLine)
    {
        int totalAmountOfSpaces = currentLineNumber - 1;
        DrawSpacesLeft(totalAmountOfSpaces);

        DrawNumberAfterSpaces(lastHorizontalXCoordinate,
            currentXCoordinate,
            currentLineNumber,
            totalAmountOfSpaces,
            totalSymbolsInLine);
        Console.WriteLine();

        lastVerticalYCoordinate--;
        return lastVerticalYCoordinate;
    }

    private static void DrawNumberAfterSpaces(
        int lastHorizontalXCoordinate,
        int currentXCoordinate,
        int currentLineNumber,
        int totalAmountOfSpaces,
        int totalSymbolsInLine)
    {
        int amountOfNumbersToDraw = totalSymbolsInLine - totalAmountOfSpaces;

        for (var i = 0; i < amountOfNumbersToDraw; i++)
        {
            string currentSymbol = $"{currentLineNumber} ";

            bool lastSymbol = currentXCoordinate == lastHorizontalXCoordinate;
            if (lastSymbol)
            {
                currentSymbol = $"{currentLineNumber}";
            }

            Console.Write(currentSymbol);
        }
    }

    private static void DrawRestOfTheLines(
        int inputNumber,
        int currentLineNumber,
        int currentXCoordinate,
        int lastVerticalYCoordinate)
    {
        int totalSymbolsInLine = inputNumber;
        int lastHorizontalXCoordinate = inputNumber;

        var itemsInOneRound = 9;
        bool isInputMoreThanOneRound = inputNumber >= itemsInOneRound;

        if (isInputMoreThanOneRound)
        {
            double roundsToDraw = (double) inputNumber / itemsInOneRound;

            for (double currentRound = roundsToDraw; (int) Math.Abs(currentRound) > 0; currentRound--)
            {
                var lastVerticalYCoordinateForRound = 9;
                int currentLineNumberInRound = currentLineNumber;

                for (int currentVerticalYCoordinate = currentLineNumberInRound;
                     currentXCoordinate <= lastHorizontalXCoordinate
                     && currentVerticalYCoordinate <= lastVerticalYCoordinateForRound
                     && currentLineNumber <= inputNumber;
                     currentLineNumberInRound++, currentLineNumber++, currentXCoordinate++)
                {
                    DrawLineWithSpaces(currentLineNumberInRound,
                        currentXCoordinate,
                        lastVerticalYCoordinateForRound,
                        lastHorizontalXCoordinate,
                        totalSymbolsInLine);

                    // if (currentLineNumberInRound > 9)
                    // {
                    // currentLineNumberInRound = 0;
                    // }
                }
            }
        }
        else
        {
            for (int currentVerticalYCoordinate = currentLineNumber;
                 currentXCoordinate <= lastHorizontalXCoordinate
                 && currentVerticalYCoordinate <= lastVerticalYCoordinate && currentLineNumber <= inputNumber;
                 currentLineNumber++, currentXCoordinate++)
            {
                lastVerticalYCoordinate = DrawLineWithSpaces(currentLineNumber,
                    currentXCoordinate,
                    lastVerticalYCoordinate,
                    lastHorizontalXCoordinate,
                    totalSymbolsInLine);
            }
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