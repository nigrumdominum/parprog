//Habalov Oleg Olegovich
class MatrixTransformer
{
    const int N = 10;
    static double[,] GenerateRandomMatrix()
    {
        var matrix = new double[N, N];
        var random = new Random();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = random.NextDouble() * 360; // Случайное число от 0 до 359 градусов
            }
        }
        return matrix;
    }
    static double[,] TransformMatrix(double[,] matrix)
    {
        var transformedMatrix = new double[N, N];
        Parallel.For(0, N, i =>
        {
            for (int j = 0; j < N; j++)
            {
                double angleInRadians = Math.PI / 180 * matrix[i, j]; // Переводим угол в радианы
                transformedMatrix[i, j] = Math.Sin(angleInRadians) + Math.Cos(angleInRadians);
            }
        });
        return transformedMatrix;
    }
    static void Main()
    {
        var originalMatrix = GenerateRandomMatrix();
        var transformTask = Task.Run(() => TransformMatrix(originalMatrix));
        transformTask.Wait();
        var transformedMatrix = transformTask.Result;
        Console.WriteLine("Преобразованная матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"{transformedMatrix[i, j]:F2}\t");
            }
            Console.WriteLine();
        }
    }
}