//Habalov Oleg Olegovich
public delegate int[] MaxElementsDelegate(int sizeA, int sizeB);
class Program
{
    public static int[] GetMaxElements(int sizeA, int sizeB)
    {
        Random random = new Random();
        int[] arrayA = new int[sizeA];
        for (int i = 0; i < sizeA; i++)
            arrayA[i] = random.Next(100); // Генерация случайного числа от 0 до 99
        int maxElementA = arrayA[0];
        foreach (var item in arrayA)
            if (item > maxElementA)
                maxElementA = item;
        int[] arrayB = new int[sizeB];
        for (int j = 0; j < sizeB; j++)
            arrayB[j] = random.Next(100); // Генерация случайного числа от 0 до 99

        int maxElementB = arrayB[0];
        foreach (var item in arrayB)
            if (item > maxElementB)
                maxElementB = item;

        return new int[] { maxElementA, maxElementB };
    }

    static void Main(string[] args)
    {
        MaxElementsDelegate getMaxElements = GetMaxElements;
        Console.Write("Введите размер первого массива: ");
        int sizeA = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите размер второго массива: ");
        int sizeB = Convert.ToInt32(Console.ReadLine());
        int[] result = getMaxElements(sizeA, sizeB);
        Console.WriteLine($"Максимальный элемент первого массива: {result[0]}");
        Console.WriteLine($"Максимальный элемент второго массива: {result[1]}");
    }
}