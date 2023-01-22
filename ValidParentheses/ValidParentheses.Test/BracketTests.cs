using FluentAssertions;

using NUnit.Framework;

namespace ValidParentheses.Test
{
    [TestFixture]
    public class BracketTests
    {
        [Test]
        [TestCase("(()())()", true)]
        [TestCase("(())", true)]
        [TestCase("()()", true)]
        [TestCase("(())()", true)]
        [TestCase("()(", false)]
        [TestCase("()()())", false)]
        [TestCase(")(", false)]
        [TestCase("())(()", false)]
        [TestCase("(())((()())())", true)]
        [TestCase("hi(hi)", true)]
        public void CorrectBrackets(string input, bool expectedResult)
        {
            bool actualResult = Parentheses.ValidParenthesesSequence(input);
            actualResult.Should().Be(expectedResult);
        }
    }
}