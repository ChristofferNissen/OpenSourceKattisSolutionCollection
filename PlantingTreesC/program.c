#include <stdio.h>

void merge(int array[], int aux[], int left, int right)
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

void mergeSort(int array[], int aux[], int left, int right)
{
    if (left == right) return;
    int middelIndex = (left + right) / 2;
    mergeSort(array, aux, left, middelIndex);
    mergeSort(array, aux, middelIndex + 1, right);
    merge(array, aux, left, right);

    for (int i = left; i <= right; i++)
    {
        array[i] = aux[i];
    }
}

int max(int a, int b)
{
    return a < b ? b : a;
}

int days(const int seeds)
{
    int arr[seeds];

    int next;
    for (int i = 0; i < seeds; i++)
    {
        scanf("%d", &next);
        arr[i] = next;
    }

    int aux[seeds];
    mergeSort(arr, aux, 0, seeds-1);

    int counter = 0;
    int day = 1, max_days = 0;
    while (counter < seeds)
    {
        max_days = max(arr[counter] + day++, max_days);
        counter = counter + 1;
    }

    return max_days + 1;
}

int main()
{
    int n;
    scanf("%d", &n);
    printf("%d\n", days(n));
    return 0;
}