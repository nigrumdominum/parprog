//Habalov Oleg Olegovich
class Program
{
    static void Main()
    {
        int n = 5, m = 6, k = 7;
        int[,,] mas = new int[n, m, k];
        Parallel.For(0, n, i =>
        {
            for (int j = 0; j < m; j++)
            {
                for (int l = 0; l < k; l++)
                {
                    mas[i, j, l] = new Random().Next(1, 101);
                }
            }
        });
        int maxSliceIndex = 0;
        int maxSum = 0;
        for (int sliceIndex = 0; sliceIndex < n; sliceIndex++)
        {
            int currentSum = 0;
            for (int j = 0; j < m; j++)
            {
                for (int l = 0; l < k; l++)
                {
                    currentSum += mas[sliceIndex, j, l];
                }
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxSliceIndex = sliceIndex;
            }
        }
        Console.WriteLine($"Срез с индексом {maxSliceIndex} имеет максимальную сумму элементов: {maxSum}.");
    }
}