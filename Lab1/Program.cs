//Habalov Oleg Olegovich
class Program
{
    public static void Main(string[] args)
    {
        Func<Action<string>, int, int> lambda = Function;
        Action<string> action = Method;

        Console.WriteLine(lambda(action, 4)); // true
        Console.ReadLine();
        Console.WriteLine(lambda(action, 5)); // false
        Console.ReadLine();
        Console.WriteLine(lambda(action, 2)); // true
        Console.ReadLine();
    }
    static void Method(string s)
    {
        Console.WriteLine(s); // Вывод строкового выражения
    }

    static int Function(Action<string> action, int num)
    {
        //Проверка на четность натурального числа
        int res = num % 2 == 0 ? 2 : 1;
        action(res.ToString()); // Вывод строкового выражения
        return res; // Вывод остатка от деления на 2
    }
}