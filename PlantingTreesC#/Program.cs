using System;

namespace PlantingTreesKattis
{
    class Program
    {
        private static void MergeSort(int[] array, int[] aux, int left, int right)
        {
            if (left == right) return;
            int middelIndex = (left + right) / 2;
            MergeSort(array, aux, left, middelIndex);
            MergeSort(array, aux, middelIndex + 1, right);
            Merge(array, aux, left, right);

            for (int i = left; i <= right; i++)
                array[i] = aux[i];
        }

        private static void Merge(int[] array, int[] aux, int left, int right)
        {
            int middleIndex = (left + right) / 2;
            int leftIndex = left;
            int rightIndex = middleIndex + 1;
            int auxIndex = left;
            while (leftIndex <= middleIndex && rightIndex <= right)
            {
                if (array[leftIndex] >= array[rightIndex])
                {
                    aux[auxIndex] = array[leftIndex++];
                }
                else
                {
                    aux[auxIndex] = array[rightIndex++];
                }
                auxIndex++;
            }
            while(leftIndex <= middleIndex)
            {
                aux[auxIndex] = array[leftIndex++];
                auxIndex++;
            }
            while(rightIndex <= right)
            {
                aux[auxIndex] = array[rightIndex++];
                auxIndex++;
            }
        }


        static int Max(int a, int b)
        {
            return a < b ? b : a;
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine().Trim());
            if(n > 0 && n <= 100_000)
            {
                var arr = Console.ReadLine().Trim().Split(" ");
                var intArr = new int[n];
                for(int i = 0; i < n; i++)
                    intArr[i] = int.Parse(arr[i]);

                var aux = new int[n];
                MergeSort(intArr, aux, 0, n - 1);

                int counter = 0;
                int day = 1, max_days = 0;
                while (counter < n)
                    max_days = Max(intArr[counter++] + day++, max_days);
            
               Console.Write(max_days + 1);

            }

        }
    }

}