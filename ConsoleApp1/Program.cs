
using System.Net.Http.Headers;

internal class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 10);
            Console.Write(array[i] + "\t");
        }
        Console.WriteLine("Отсортированый массив:");
        foreach (var VARIABLE in MergeSort(array))
        {
            Console.Write(VARIABLE + "\t");
        }  
    }

    static int[] MergeSort(int[] array)
    {
        if (array.Length == 1)
        {
            return array;
        }

        int midleIndex = array.Length / 2;
        int[] left = new int[midleIndex];
        for (int i = 0; i < midleIndex; i++)
        {
            left[i] = array[i]; 
        }
        int[] right = new int[array.Length - midleIndex];
        for (int i = 0; i < array.Length - midleIndex; i++)
        {
            right[i] = array[i + midleIndex];
        }
        left = MergeSort(left);
        right = MergeSort(right);
        int leftptr = 0;
        int rightptr = 0;
        int[] sorted = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            if (rightptr == right.Length ||
                ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
            {
                sorted[i] = left[ leftptr ];
                leftptr++;
            }
            else if( leftptr == left.Length ||
                     ((rightptr < right.Length ) && (right[rightptr] <= left[leftptr] )))
            {
                sorted[i] = right[rightptr];
                rightptr++;
            }
        }
         return sorted;
    }
}
