using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть шлях до програми, яку хочете запустити (наприклад, notepad.exe):");
        string processPath = Console.ReadLine();

        Process childProcess = new Process();

        try
        {
            childProcess.StartInfo.FileName = processPath;
            childProcess.Start();

            Console.WriteLine("Дочірній процес запущено.");
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Дочекатися завершення процесу.");
            Console.WriteLine("2. Примусово завершити процес.");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                childProcess.WaitForExit();
                Console.WriteLine($"Процес завершився. Код завершення: {childProcess.ExitCode}");
            }
            else if (choice == "2")
            {
                childProcess.Kill();
                Console.WriteLine("Дочірній процес примусово завершено.");
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        finally
        {
            if (childProcess != null && !childProcess.HasExited)
            {
                childProcess.Kill();
            }
        }

        Console.WriteLine("Програма завершена.");
    }
}
