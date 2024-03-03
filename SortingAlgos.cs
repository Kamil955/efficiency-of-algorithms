using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class SortingAlgos
{

    const int N = 1000;

    int[] arr = new int[N];

    //arrays
    [GlobalSetup]
    // random array

    // public void Setup()
    // {
    //     var rand = new System.Random();
    //     for (int i = 0; i < N; i++)
    //     {
    //         arr[i] = rand.Next(0, 10);
    //     }
    // }

    // sorted array

    // public void Setup()
    // {
    //     for (int i = 0; i < N; i++)
    //     {
    //         arr[i] = i;
    //     }
    // }

    // reverse sorted array

    // public void Setup()
    // {
    //     for (int i = 0; i < N; i++)
    //     {
    //         arr[i] = N - i;
    //     }
    // }

    // nearly sorted array

    // public void Setup()
    // {
    //     for (int i = 0; i < N; i++)
    //     {
    //         arr[i] = i;
    //     }

    //     for (int i = 0; i < N / 10; i++)
    //     {
    //         int index1 = new System.Random().Next(0, N);
    //         int index2 = new System.Random().Next(0, N);
    //         int temp = arr[index1];
    //         arr[index1] = arr[index2];
    //         arr[index2] = temp;
    //     }
    // }


    // few unique array
    public void Setup()
    {
        int[] uniqueValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int uniqueValuesCount = uniqueValues.Length;

        for (int i = 0; i < N; i++)
        {
            arr[i] = uniqueValues[i % uniqueValuesCount];
        }
    }

    // InsertionSort
    [Benchmark]
    public  void InsertionSort()
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    // SelectionSort
    [Benchmark]
    public  void SelectionSort()
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    //QuickSort - Array.Sort
    [Benchmark]
    public void QuickSort()
    {
        System.Array.Sort(arr);
    }

    //QuickSortClassical
    [Benchmark]
    public void QuickSortClassical()
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    private void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}