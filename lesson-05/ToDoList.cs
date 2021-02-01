using System;
using System.IO;
using System.Text.Json;

namespace lesson_05
{
    // task 5
    public class ToDoList
    {
        string fileName = "task.json";

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Show();
                Console.WriteLine();
                Console.WriteLine("N - новая задача" + Environment.NewLine);
                Console.WriteLine("E - выполнить задачу" + Environment.NewLine);
                Console.WriteLine("D - удалить список задач" + Environment.NewLine);
                Console.WriteLine("Q - выход" + Environment.NewLine);
                Console.Write("Введите вариант: ");
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.N:
                        Add();
                        break;
                    case ConsoleKey.E:
                        Complete();
                        break;
                    case ConsoleKey.D:
                        DeleteToDoList();
                        break;
                    case ConsoleKey.Q:
                        exit = true;
                        break;
                }
            }
        }

        private void DeleteToDoList()
        {
            Console.WriteLine(
                @"Вы уверены, что хотите удалить весь список?
    Y - удалить
    N - не удалять"
);
            if (Console.ReadKey().Key == ConsoleKey.Y)
                if (File.Exists(fileName))
                    File.Delete(fileName);
        }

        private void Complete()
        {
            Console.Write("Введите номер задачи: ");
            string str = Console.ReadLine();
            string json = "";
            if (int.TryParse(str, out int res) && File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                if (res > 0 && res <= lines.Length)
                {
                    res--;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (i == res)
                        {
                            ToDo task = JsonSerializer.Deserialize<ToDo>(lines[i]);
                            task.IsDone = true;
                            AddTaskToString(ref json, JsonSerializer.Serialize(task));
                        }
                        else
                        {
                            AddTaskToString(ref json, lines[i]);
                        }
                    }
                    File.WriteAllText(fileName, json);
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный номер задачи.");
                    Console.ReadKey();
                }
            }
        }

        void AddTaskToString(ref string json, string newTask)
        {
            if (json is null || json.Length == 0)
                json = newTask;
            else if (newTask.Length > 0)
                json += Environment.NewLine + newTask;
        }

        void Show()
        {
            Console.WriteLine("= = = TASK LIST = = =");
            Console.WriteLine();
            if (!File.Exists(fileName))
                Console.WriteLine("No tasks...");
            else
            {
                string[] jsons = File.ReadAllLines(fileName);
                for (int i = 0; i < jsons.Length; i++)
                {
                    string json = jsons[i];
                    try
                    {
                        ToDo task = JsonSerializer.Deserialize<ToDo>(json);
                        string str = $"{i + 1} ";
                        str += task.IsDone ? "[x]" : "[ ]";
                        str += $" {task.Title}";
                        Console.WriteLine($"{str}");
                    }
                    catch { }
                }
            }
            Console.WriteLine();
            Console.WriteLine("= = = = = = = = = = =");
            Console.WriteLine();
        }

        void Add() 
        {
            Console.WriteLine("Введите новую задачу: ");
            ToDo task = new ToDo(Console.ReadLine());
            string json = JsonSerializer.Serialize(task);
            File.AppendAllText(fileName, (File.Exists(fileName) ? Environment.NewLine : "") + json);
            Show();
        }
    }

    class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo()
        {

        }

        public ToDo(string title)
        {
            Title = title;
            IsDone = false;
        }
    }
}
