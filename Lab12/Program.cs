//Habalov Oleg Olegovich
class Program
{
    static readonly Random random = new Random();
    static void Main()
    {
        int arraySize = random.Next(10, 20); // Размер массива от 10 до 19
        int[] randomArray = Enumerable.Range(0, arraySize).Select(_ => random.Next(-50, 51)).ToArray();
        Task<int> squareOfSumTask = Task.Run(() =>
        {
            int sum = randomArray.Sum();
            return sum * sum;
        });
        Task<int> sumOfCubesTask = Task.Run(() =>
        {
            return randomArray.Select(x => x * x * x).Sum();
        });
        Task printArrayTask = Task.Run(() =>
        {
            Console.WriteLine("Случайный массив:");
            foreach (var number in randomArray)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        });
        Task.WhenAll(squareOfSumTask, sumOfCubesTask, printArrayTask).ContinueWith(t =>
        {
            int squareOfSum = squareOfSumTask.Result;
            int sumOfCubes = sumOfCubesTask.Result;
            Console.WriteLine($"Квадрат суммы элементов: {squareOfSum}");
            Console.WriteLine($"Сумма кубов элементов: {sumOfCubes}");
        }).Wait();

        Console.WriteLine("Завершение программы.");
    }
}