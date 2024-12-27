//Habalov Oleg Olegovich
class Program
{
    static readonly Random random = new Random();
    static void Main()
    {
        int arraySize = random.Next(10, 20);
        int[] randomArray = Enumerable.Range(0, arraySize).Select(_ => random.Next(-50, 51)).ToArray();
        Task<int> minOddTask = Task.Run(() =>
        {
            int? minOdd = null;
            foreach (var num in randomArray.Where(n => n % 2 != 0))
            {
                if (!minOdd.HasValue || num < minOdd){minOdd = num;}
            }
            return minOdd ?? Int32.MaxValue;
        });
        Task<int> countDivisibleBySevenTask = Task.Run(() =>
        {return randomArray.Count(num => num % 7 == 0);});
        Task.WhenAll(minOddTask, countDivisibleBySevenTask).Wait();
        int minOdd = minOddTask.Result;
        int divisibleCount = countDivisibleBySevenTask.Result;
        Console.WriteLine($"Минимальное нечетное число: {minOdd}");
        Console.WriteLine($"Количество элементов, делящихся на 7: {divisibleCount}");
        Console.WriteLine("Завершение программы.");
    }
}