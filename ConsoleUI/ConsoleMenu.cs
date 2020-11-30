using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    public class ConsoleMenu
    {
        public static void Header(string message)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.Write(new string(' ', (Console.WindowWidth - message.Length) / 2));
            Console.WriteLine(message);
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public static void MainMenu(List<string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                string textMenu = $"{i + 1}. {menu[i]}";
                if (textMenu.Length % 2 == 0)
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / menu.Count) - textMenu.Length) / 2) - 1));
                }
                else
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / menu.Count) - textMenu.Length) / 2)));
                }
                Console.Write(textMenu);
                if (menu.Count - 1 != i)
                {
                    Console.Write(new string(' ', ((Console.WindowWidth / menu.Count) - textMenu.Length) / 2));
                }
                if (i != menu.Count - 1)
                    Console.Write("|");
            }
            Console.WriteLine("\n" + new string('-', Console.WindowWidth));
        }

        public static void Menu(List<string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.Write($"{i + 1}.");
                if (menu[i].Length % 2 == 0)
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - menu[i].Length) / 2) - 3));
                }
                else
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - menu[i].Length) / 2) - 2));
                }
                Console.Write(menu[i]);
                Console.Write(new string(' ', ((Console.WindowWidth / 2) - menu[i].Length) / 2));
                Console.WriteLine("|");
                Console.WriteLine(new string('-', Console.WindowWidth / 2));
            }
        }

        public static void Menu(Dictionary<string, string> menu)
        {
            int i = 1;
            foreach (KeyValuePair<string, string> pair in menu)
            {
                Console.Write(i + ".");
                if (pair.Key.Length % 2 == 0)
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - pair.Key.Length) / 2) - 3));
                }
                else
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - pair.Key.Length) / 2) - 2));
                }
                Console.Write(pair.Key);
                Console.Write(new string(' ', ((Console.WindowWidth / 2) - pair.Key.Length) / 2));
                Console.Write("|");
                if (pair.Value != null)
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - pair.Value.Length) / 2) - 2));
                    Console.Write(pair.Value);
                    Console.WriteLine(new string(' ', ((Console.WindowWidth / 2) - pair.Value.Length) / 2));
                    Console.WriteLine(new string('-', Console.WindowWidth));
                }
                else
                {
                    Console.Write("\n");
                    Console.WriteLine(new string('-', Console.WindowWidth / 2));
                }
                i++;
            }
        }

        public static Dictionary<string, string> InputData(List<string> menu)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            for (int i = 0; i < menu.Count; i++)
            {
                Console.Write($"{i + 1}.");
                if (menu[i].Length % 2 == 0)
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - menu[i].Length) / 2) - 3));
                }
                else
                {
                    Console.Write(new string(' ', (((Console.WindowWidth / 2) - menu[i].Length) / 2) - 2));
                }
                Console.Write(menu[i]);
                Console.Write(new string(' ', ((Console.WindowWidth / 2) - menu[i].Length) / 2));
                Console.WriteLine("|");
                Console.WriteLine(new string('-', Console.WindowWidth));
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, i * 2 + 3);
                // Валидировать
                // TODO: to validate
                string input = Console.ReadLine();
                // проверить почему default а не null
                fields[menu[i]] = string.IsNullOrEmpty(input) ? default : input;
                Console.SetCursorPosition(0, i * 2 + 5);
            }
            return fields;
        }

        public static void Print<T>(List<T> listT)
        {
            foreach (T t in listT)
            {
                int i = 0;
                foreach (var v in t.GetType().GetProperties())
                {
                    ++i;
                    if (v.Name.Length % 2 == 0)
                    {
                        Console.Write(new string(' ', (((Console.WindowWidth / t.GetType().GetProperties().Length) - v.Name.Length) / 2) - 1));
                    }
                    else
                    {
                        Console.Write(new string(' ', (((Console.WindowWidth / t.GetType().GetProperties().Length) - v.Name.Length) / 2)));
                    }
                    Console.Write(v.GetValue(t));
                    Console.Write(new string(' ', ((Console.WindowWidth / t.GetType().GetProperties().Length) - v.Name.Length) / 2));
                    if (i < t.GetType().GetProperties().Length)
                        Console.Write("|");
                }
                Console.WriteLine("\n" + new string('-', Console.WindowWidth));
            }
        }
    }
}
