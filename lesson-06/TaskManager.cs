using System;
using System.Diagnostics;
using System.Threading;

namespace lesson_06
{
    public class TaskManager
    {
        public void Start()
        {
            Console.Title = " Task Manager ";
            Console.WindowHeight = 30;
            ShowMainMenu();
        }

        void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine(" - - - Main Menu - - -");
            Console.WriteLine();
            Console.WriteLine("A - Show all processes");
            Console.WriteLine();
            Console.WriteLine("K - Kill process by ID or NAME");
            Console.WriteLine();
            Console.WriteLine("Q - Exit");
            Console.WriteLine();
            Console.Write("    Your choice: ");

            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.A:
                    ShowAllProcesses(Process.GetProcesses());
                    break;
                case ConsoleKey.K:
                    ShowKillTaskMenu();
                    break;
                case ConsoleKey.Q:
                    return;
                default:
                    Console.WriteLine();
                    Console.WriteLine("You press wrong key. Please, try again.");
                    Thread.Sleep(2000);
                    ShowMainMenu();
                    break;
            }
        }

        void ShowAllProcesses(Process[] processes, int countOfProcessesOnPage = 10, int page = 1)
        {
            Console.Clear();
            Console.WriteLine($" - - - List of Processes ({processes.Length}) - - - ");
            Console.WriteLine();
            if (processes is null || processes.Length == 0)
            {
                Console.WriteLine("No processes started :( ");
                return;
            }
            Console.WriteLine($"#\tID\tName");
            Console.WriteLine();

            int pageCount = processes.Length / countOfProcessesOnPage;
            if (processes.Length % countOfProcessesOnPage > 0)
                pageCount++;

            while (page > pageCount)
                page -= pageCount;

            if (page < 1)
                page = pageCount;

            for (int i = 0; i < countOfProcessesOnPage; i++)
            {
                int n = countOfProcessesOnPage * (page - 1) + i;
                if (n >= processes.Length)
                    break;
                try
                {
                    Process proc = processes[n];

                    Console.WriteLine($"{n + 1}.\t{proc.Id}\t{proc.ProcessName}");
                }
                catch
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine(@$"Page {page} of {pageCount}

- - - - - - - - - - - - - - - -

N - Next page
B - Previouse page

K - Kill process by ID or NAME
M - Main Menu

");

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.N:
                        ShowAllProcesses(processes, countOfProcessesOnPage, page + 1);
                        return;
                    case ConsoleKey.B:
                        ShowAllProcesses(processes, countOfProcessesOnPage, page - 1);
                        return;
                    case ConsoleKey.K:
                        ShowKillTaskMenu();
                        return;
                    case ConsoleKey.M:
                        ShowMainMenu();
                        return;
                    default:
                        Console.WriteLine($"Wrong ansver.{Environment.NewLine}N - next page\tB - previuose page");
                        Console.WriteLine();
                        Console.WriteLine($"K - kill task\tM - Main Menu");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void ShowKillTaskMenu()
        {
            Console.WriteLine();
            Console.Write("Enter ID or NAME of process: ");
            Process[] processes = FindProcess(Console.ReadLine());
            Console.WriteLine();
            // Процесс не найден
            if (processes is null)
            {
                Console.WriteLine();
                Console.WriteLine("No proesses found...");
                Console.WriteLine();
                Console.WriteLine("K - Try Again");
                Console.WriteLine();
                Console.WriteLine("M - Main Menu");

                while (true)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (key)
                    {
                        case ConsoleKey.K:
                            ShowKillTaskMenu();
                            return;
                        case ConsoleKey.M:
                            ShowMainMenu();
                            return;
                        default:
                            Console.WriteLine($"Wrong ansver.{Environment.NewLine}K - try again{Environment.NewLine}M - main menu");
                            break;
                    }
                }
            }
            else if (processes.Length == 1)
            {
                KillProcess(processes[0]);
            }
            else
            {
                ShowAllProcesses(processes);
            }
        }

        void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        void KillProcess(Process process)
        {
            Console.Clear();
            Console.WriteLine($" - - - Kill Process - - - ");
            Console.WriteLine();
            Console.WriteLine($"Process ID: {process.Id}{Environment.NewLine}Name: {process.ProcessName}");
            Console.WriteLine();
            Console.WriteLine("Are You sure You want to kill the process?");
            Console.WriteLine();
            Console.WriteLine("Y - yes\tN - no");
            Console.WriteLine();
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.Y:
                        try
                        {
                            process.Kill();
                            Console.WriteLine("The process was killed...");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        Pause();
                        ShowMainMenu();
                        return;
                    case ConsoleKey.M:
                        ShowMainMenu();
                        return;
                    default:
                        Console.WriteLine($"Wrong ansver.{Environment.NewLine}{Environment.NewLine}");
                        Console.WriteLine($"Y - kill the process{Environment.NewLine}M - main menu");
                        break;
                }
            }
        }

        /// <summary>
        /// If no processes find return NULL.
        /// </summary>
        /// <param name="nameOrId"></param>
        /// <returns></returns>
        Process[] FindProcess(string nameOrId)
        {
            Process[] processes;

            if (int.TryParse(nameOrId, out int id))
                try
                {
                    processes = new Process[1] { Process.GetProcessById(id) };
                }
                catch
                {
                    return null;
                }
            else
                processes = Process.GetProcessesByName(nameOrId.Trim());

            if (processes is null || processes.Length == 0 || processes[0] is null)
                return null;
            else
                return processes;
        }








    }
}
