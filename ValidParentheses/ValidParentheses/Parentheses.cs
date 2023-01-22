namespace ValidParentheses
{
    public class Parentheses
    {
        public static bool ValidParenthesesSequence(string input)
        {
            var openingBracketsAmount = 0;
            var closingBracketsAmount = 0;
            bool isCorrectSequence;
            var openingBracket = '(';
            var closingBracket = ')';

            for (var i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                bool currentSymbolIsOpeningBracket = currentSymbol == openingBracket;
                bool currentSymbolIsClosingBracket = currentSymbol == closingBracket;

                if (!currentSymbolIsOpeningBracket && !currentSymbolIsClosingBracket)
                {
                    continue;
                }

                if (currentSymbolIsOpeningBracket)
                {
                    openingBracketsAmount = ++openingBracketsAmount;
                }
                else
                {
                    bool firstBracketIsInvalid = i == 0;
                    if (firstBracketIsInvalid)
                    {
                        isCorrectSequence = false;
                        return isCorrectSequence;
                    }

                    if (currentSymbolIsClosingBracket)
                    {
                        closingBracketsAmount = ++closingBracketsAmount;
                        if (openingBracketsAmount < closingBracketsAmount)
                        {
                            isCorrectSequence = false;
                            return isCorrectSequence;
                        }
                    }
                }
            }

            isCorrectSequence = openingBracketsAmount == closingBracketsAmount;
            return isCorrectSequence;
        }
    }
}