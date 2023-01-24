namespace Array.Diff

{
    public class Kata
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> aList = a.ToList();

            foreach (int itemA in a)
            {
                foreach (int itemB in b)
                {
                    if (itemA == itemB)
                    {
                        aList.Remove(itemB);
                    }
                }
            }

            int[] result = aList.ToArray();
            return result;
        }
    }
}