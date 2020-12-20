using System;
using System.Linq;

namespace ArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            const string answerDisplay = "Answer for {0}: {1}";
            var arr = new int[] { 1, 2, 3, 4 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));

            arr = new int[] { 1, 2, 1, 5 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));

            arr = new int[] { 22, 21, 35, 20, 1, 8, 11, 16 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));
            
            arr = new int[] { 2, 2, 4, 2 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));

            arr = new int[] { 2, 2, 4, 2, 3 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));
            
            arr = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 17 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));

            arr = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 12 };
            Console.WriteLine(answerDisplay, string.Join(",", arr), calculateArraySum(arr));
        }

        static string calculateArraySum(int[] arr)
        {
            if (arr.Length % 2 != 0 || arr.Sum() % 2 != 0)
            {
                return "-1";
            }

            Array.Sort(arr);

            var partSum = arr.Sum() / 2;
            var partArr = new int[arr.Length / 2];
            var result = getFirstEvenSum(partArr, arr, partSum, 0, arr.Length - 1, 0);

            if (result == null)
            {
                return "-1";
            }

            var returnElement = result.ToList();
            var originalArray = arr.ToList();

            for (var i = 0; i < returnElement.Count; i++)
            {
                for(var j = 0; j < originalArray.Count; j++)
                {
                    if (returnElement[i] == originalArray[j])
                    {
                        originalArray.RemoveAt(j);
                        j--;
                        break;
                    }
                }
            }
            returnElement.AddRange(originalArray);

            return string.Join(",", returnElement);
        }

        static int[] getFirstEvenSum(int[] currentArray, int[] originalArray, int partSum, int start, int end, int currentIndex)
        {
            if (currentIndex == originalArray.Length / 2)
            {
                if (currentArray.Sum() == partSum)
                {
                    return currentArray;
                }
            }

            for (int i = start; i <= end && currentIndex < currentArray.Length; i++)
            {
                currentArray[currentIndex] = originalArray[i];
                var result = getFirstEvenSum(currentArray, originalArray, partSum, i + 1, end, currentIndex + 1);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
