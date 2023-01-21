namespace SumOfDigitsDigitalRoot
{
    public class Number
    {
        public static int DigitalRoot(long n)
        {
            long[] digits = GetDigitsArrayFromNumber(n);

            int root = Sum(digits);
            long[] digitsFromInitialRoot = GetDigitsArrayFromNumber(root);

            if (digitsFromInitialRoot.Length == 0)
            {
                return root;
            }

            while (digitsFromInitialRoot.Length > 1)
            {
                root = Sum(digitsFromInitialRoot);
                digitsFromInitialRoot = GetDigitsArrayFromNumber(root);
            }

            return root;
        }

        public static long[] GetDigitsArrayFromNumber(long value)
        {
            Stack<long> numbers = new();

            for (; value > 0; value /= 10)
            {
                numbers.Push(value % 10);
            }

            return numbers.ToArray();
        }

        private static int Sum(long[] digits)
        {
            var root = 0;

            foreach (long digit in digits)
            {
                root += Convert.ToInt32(digit);
            }

            return root;
        }
    }
}