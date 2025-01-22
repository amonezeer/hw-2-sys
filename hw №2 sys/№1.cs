using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("введите путь к исполняемому файлу дочернего процесса");
        string processPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(processPath))
        {
            Console.WriteLine("путь к программе не может быть пустым");
            return;
        }

        try
        {
            Process process = new Process();
            process.StartInfo.FileName = processPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            Console.WriteLine("дочерний процесс запущен");
            process.WaitForExit();
            int exitCode = process.ExitCode;
            Console.WriteLine($"дочерний процесс завершён с кодом {exitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"возникла ошибка {ex.Message}");
        }
    }
}
