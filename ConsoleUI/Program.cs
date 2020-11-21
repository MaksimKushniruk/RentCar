using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {

            while (true)
            {
                Console.Clear();
                ConsoleMenu.Logo("Вас приветствует сервис аренды машин.");
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                ConsoleMenu.Logo("Выберите действие.");
                ConsoleMenu.MainMenu(new List<string> { "Аренда", "Администрирование" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ConsoleMenu.Logo("Аренда");
                        ConsoleMenu.Menu(new List<string> { "Новый заказ", "Редактировать заказ", "Отменить заказ ", "Найти заказ" });
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                Console.Clear();
                                ConsoleMenu.Logo("Новый заказ");
                                ConsoleMenu.Menu(new List<string> { "Новый клиент ", "Выбрать клиента", "Меню 3 ", "меню 4 " });
                                break;
                            case '2':
                                Console.Clear();
                                ConsoleMenu.Logo("Редактировать заказ");
                                ConsoleMenu.Menu(new List<string> { "Меню 1 ", "Меню 2 ", "Меню 3 ", "меню 4 " });
                                break;
                            case '3':
                                Console.Clear();
                                ConsoleMenu.Logo("Отменить заказ ");
                                ConsoleMenu.Menu(new List<string> { "Меню 1 ", "Меню 2 ", "Меню 3 ", "меню 4 " });
                                break;
                            case '4':
                                Console.Clear();
                                ConsoleMenu.Logo("Найти заказ");
                                ConsoleMenu.Menu(new List<string> { "Меню 1 ", "Меню 2 ", "Меню 3 ", "меню 4 " });
                                break;
                        }
                        break;
                    case '2':
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
    }
    class ConsoleMenu
    {
        // Сделать динамично
        public static void MainMenu(List<string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                string textMenu = $"{i + 1}. {menu[i]}";
                Console.Write(new string(' ', ((Console.WindowWidth / 2) - textMenu.Length) / 2));
                Console.Write(textMenu);
                Console.Write(new string(' ', ((Console.WindowWidth / 2) - textMenu.Length) / 2));
                Console.Write("|");
            }
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public static void Logo(string message)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.Write(new string(' ', (Console.WindowWidth - message.Length) / 2));
            Console.WriteLine(message);
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public static void Menu(List<string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.Write($"{i + 1}.");
                Console.Write(new string(' ', (((Console.WindowWidth / 2) - menu[i].Length) / 2) - 2));
                Console.Write(menu[i]);
                Console.Write(new string(' ', ((Console.WindowWidth / 2) - menu[i].Length) / 2));
                Console.WriteLine("|");
                Console.WriteLine(new string('-', Console.WindowWidth / 2));

            }
            Console.Write("\nДля продолжения сделайте свой выбор...");
        }
    }
}
