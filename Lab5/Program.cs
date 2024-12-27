//Habalov Oleg Olegovich
using System.Numerics;

internal class Program
{
    static void AvgArray()
    {
        int threadID = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Поток {0}. Создание массива...", threadID);
        int num;
        Console.WriteLine("Поток {0}. Инициализация элементов массива...", threadID);
        Random rnd = new Random();
        num = rnd.Next(100);
        Console.WriteLine("Поток {0}. Число: {1}", threadID, num);
        Console.WriteLine("Поток {0}. Вычисление факториала числа...", threadID);
        BigInteger fact = 1;
        for (int i = 1; i <= num; i++) fact *= i;
        Console.WriteLine("Поток {0}. Факториал числа = {1}.", threadID, fact);
    }
    static void Main(string[] args)
    {
        Action method = AvgArray;
        Thread[] tmas = new Thread[20];
        for (int i = 0; i < 20; i++)
        {
            tmas[i] = new Thread(AvgArray);
            tmas[i].Start();
        }
        Console.ReadKey();
    }
}