namespace DeleteOccurrencesFromArray
{
    public class Kata
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            List<int> occurrencesList = new();

            foreach (int item in arr)
            {
                int itemsAlreadyInList = occurrencesList.Count(num => num.Equals(item));
                if (itemsAlreadyInList >= x)
                {
                    continue;
                }

                occurrencesList.Add(item);
            }

            int[] filtered = occurrencesList.ToArray();
            return filtered;
        }
    }
}