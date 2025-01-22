/*using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть шлях до виконуваного файлу дочірнього процесу:");
        string processPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(processPath))
        {
            Console.WriteLine("Шлях до програми не може бути порожнім.");
            return;
        }

        try
        {
            Process process = new Process();
            process.StartInfo.FileName = processPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            Console.WriteLine("Дочірній процес запущено.");
            process.WaitForExit();
            int exitCode = process.ExitCode;
            Console.WriteLine($"Дочірній процес завершено з кодом: {exitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка: {ex.Message}");
        }
    }
}
*/