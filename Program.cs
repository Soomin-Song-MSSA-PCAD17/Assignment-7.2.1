
using System.Diagnostics;

/// Implement shell sort on an unsorted array of numbers. Take the array input from user.
/// 
Demo();

void Demo()
{
    bool waitingForLength=true;
    int arraySize=-1; // assign invalid value
    while (waitingForLength)
    {
    Console.Write("Array length: ");
        if (int.TryParse(Console.ReadLine(), out int size)&&size>=0)
        {
            waitingForLength = false;
            arraySize = size;
        }
        else
        { Console.Write("Invalid input. "); }
    }
    Debug.Assert(arraySize >= 0);
    int[] intArray = new int[arraySize];

    for (int i = 0; i < arraySize; i++)
    {
        bool waitingForValidInput = true;
        while (waitingForValidInput)
        {
            Console.Write($"intArray[{i}]: ");
            if(int.TryParse(Console.ReadLine(), out int value))
            {
                waitingForValidInput = false;
                intArray[i] = value;
            }
            else
            { Console.Write("Invalid input. "); }
        }
    }

    Console.WriteLine($"Before ShellSort(): [{string.Join(", ",intArray)}]");
    ShellSort(intArray);
    Console.WriteLine($" After ShellSort(): [{string.Join(", ",intArray)}]");
}

void ShellSort(int[] arr)
{
    int n = arr.Length;
    for (int gap = n / 2; gap > 0; gap /= 2)
    {
        for (int i = gap; i < n; i++)
        {
            int temp = arr[i];
            int j;
            for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
            {
                arr[j] = arr[j - gap];
            }
            arr[j] = temp;
        }
    }
}