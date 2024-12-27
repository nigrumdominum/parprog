//Habalov Oleg Olegovich
internal class Program
{
    public struct Data{public string[] arr;}
    static void ThreadMainWithParameters(object o)
    {
        Data d = (Data)o;
        Console.WriteLine("Выполняется в потоке получено: [{0}]",string.Join(",",d.arr));
        MaxArray(d.arr);
    }
    static void MaxArray(string[] arr)
    {
        int threadID = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Поток {0}. Вычисление максимального размера строки...", threadID);
        string max = "";
        for (int i = 0; i < arr.Length; i++){if (arr[i].Length>max.Length){max=arr[i];}}
        Console.WriteLine("Поток {0}. Самая длинная строка в массиве = {1},({2}).", threadID, max, max.Length);
    }
    static void Main(string[] args)
    {
        Thread[] tmas = new Thread[20];
        Random rand = new Random();
        for (int t = 0; t < 20; t++)
        {
            String allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"+"0123456789"+"abcdefghijklmnopqrstuvxyz";
            int stringSize = rand.Next(20, 40);
            int massSize = rand.Next(5,7);
            String randString = "";
            string[] randArr = new String[massSize];
            for (int k = 0; k < massSize; k++)
            {
                for (int i = 0; i < stringSize; i++)
                {
                    int j = rand.Next(allChars.Length);
                    randString += allChars[j];
                }
                randArr[k] = randString;
                randString = "";
            }
            var d = new Data { arr = randArr };
            tmas[t] = new Thread(ThreadMainWithParameters);
            tmas[t].Start(d);
        }
        Console.ReadKey();
    }
}