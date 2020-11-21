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
                ConsoleLogo("Вас приветствует сервис аренды машин.");
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                ConsoleLogo("Выберите действие.");
                ConsoleMainMenu("1. Аренда", "2. Администрирование");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ConsoleLogo("Аренда");
                        RentMenu();
                        break;
                    case '2':
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }

        static void ConsoleLogo(string message)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.Write(new string(' ', (Console.WindowWidth - message.Length) / 2));
            Console.WriteLine(message);
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        static void ConsoleMainMenu(string rentActions, string adminActions)
        {
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - rentActions.Length) / 2));
            Console.Write(rentActions);
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - rentActions.Length) / 2));
            Console.Write("|");
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - adminActions.Length) / 2));
            Console.Write(adminActions);
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - adminActions.Length) / 2));
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        static void RentMenu()
        {
            string newRent = "Новый заказ";
            Console.Write("1.");
            Console.Write(new string(' ', (((Console.WindowWidth / 2) - newRent.Length) / 2) - 2));
            Console.Write(newRent);
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - newRent.Length) / 2));
            Console.WriteLine("|");
            Console.WriteLine(new string('-', Console.WindowWidth / 2));
            string editRent = "Редактировать заказ";
            Console.Write("2.");
            Console.Write(new string(' ', (((Console.WindowWidth / 2) - editRent.Length) / 2) - 2));
            Console.Write(editRent);
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - editRent.Length) / 2));
            Console.WriteLine("|");
            Console.WriteLine(new string('-', Console.WindowWidth / 2));
            string deleteRent = "Отменить заказ";
            Console.Write("3.");
            Console.Write(new string(' ', (((Console.WindowWidth / 2) - deleteRent.Length) / 2) - 3));
            Console.Write(deleteRent);
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - deleteRent.Length) / 2));
            Console.WriteLine("|");
            Console.WriteLine(new string('-', Console.WindowWidth / 2));
            string getRent = "Найти заказ";
            Console.Write("4.");
            Console.Write(new string(' ', (((Console.WindowWidth / 2) - getRent.Length) / 2) - 2));
            Console.Write(getRent);
            Console.Write(new string(' ', ((Console.WindowWidth / 2) - getRent.Length) / 2));
            Console.WriteLine("|");
            Console.WriteLine(new string('-', Console.WindowWidth / 2));
            Console.Write("\nДля продолжения сделайте свой выбор...");
        }
    }
}
