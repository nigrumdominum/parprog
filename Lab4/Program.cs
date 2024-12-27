//Habalov Oleg Olegovich
class Program
{
    public delegate Task<Dictionary<char, int>> StatisticsAsyncDelegate(string inputString);
    private static async Task<Dictionary<char, int>> CalculateStatisticsAsync(string inputString)
    {
        Dictionary<char, int> statistics = new Dictionary<char, int>();
        await Task.Run(() =>
        {
            foreach (char c in inputString)
            {
                if (!statistics.ContainsKey(c))
                    statistics[c] = 1;
                else
                    statistics[c]++;
            }
        });

        return statistics;
    }
    static void Main(string[] args)
    {
        string inputString = "Hello, World!";
        StatisticsAsyncDelegate calculateStats = CalculateStatisticsAsync;
        calculateStats(inputString).ContinueWith(task =>
        {
            var result = task.Result;
            Console.WriteLine("Статистика для строки:");
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }).Wait(); // Ждем завершения выполнения
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}