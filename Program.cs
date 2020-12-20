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

            for (var i = 0; i < arr.Length; i++)
            {
                var elementExisted = false;
                for (var j = 0; j < returnElement.Count; j++)
                {
                    if (returnElement[j] == arr[i])
                    {
                        elementExisted = true;
                        break;
                    }
                }

                if (!elementExisted)
                {
                    returnElement.Add(arr[i]);
                }
            }

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
