using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write("введите путь к выполняемому файлу --> \n");
        string filePath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("ошибка,путь не может быть пустым");
            return;
        }

        try
        {
            using (Process childProcess = new Process { StartInfo = { FileName = filePath, UseShellExecute = true } })
            {
                childProcess.Start();
                Console.ResetColor();
                Console.Write("|---------------------------------------------|\n");
                Console.BackgroundColor= ConsoleColor.DarkRed;
                Console.WriteLine($"процесс с PID {childProcess.Id} запущен\n");

                Console.WriteLine("выберите действие:");
                Console.WriteLine("1. ожидать завершения процесса ");
                Console.WriteLine("2. принудительно завершить процесс");
                Console.ResetColor();
                Console.Write("ваш выбор (1/2): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    childProcess.WaitForExit();
                    Console.WriteLine($"\nпроцесс завершен с кодом: {childProcess.ExitCode}");
                }
                else if (choice == "2")
                {
                    if (!childProcess.HasExited)
                    {
                        childProcess.Kill();
                        childProcess.WaitForExit();
                        Console.WriteLine("процесс принудительно завершен");
                    }
                    else
                    {
                        Console.WriteLine("процесс уже завершен");
                    }
                }
                else
                {
                    Console.WriteLine("ошибка,неверный выбор");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ошибка {ex.Message}");
        }
    }
}
