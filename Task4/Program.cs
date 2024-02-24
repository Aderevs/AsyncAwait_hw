using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int counter = 0;
    static object block = new object();
    static async Task FunctionAsync()
    {
        for (int i = 0; i < 50; ++i)
        {
            await Task.Run(() =>
            {
                // Встановлюється блокування кожен (50!) разів у новий object (boxing).
                lock (block)
                {
                    // Виконання деякої роботи потоком ...
                    Console.WriteLine(++counter);
                }
            });
        }
    }

    static async Task Main()
    {
        Task[] tasks = { FunctionAsync(), FunctionAsync(), FunctionAsync() };

        await Task.WhenAll(tasks);

        // Delay
        Console.ReadKey();
    }
}
