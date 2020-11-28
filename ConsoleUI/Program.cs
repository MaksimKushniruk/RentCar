using System;
using System.Collections.Generic;

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
                Console.Write("\nДля продолжения сделайте свой выбор...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ConsoleMenu.Logo("Аренда");
                        ConsoleMenu.Menu(new List<string> { "Новый заказ", "Редактировать заказ", "Отменить заказ", "Найти заказ" });
                        Console.Write("\nДля продолжения сделайте свой выбор...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                Rent.CreateRent();
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
                            default:
                                // сделать, чтобы не возвращало в главное меню
                                break;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        ConsoleMenu.Logo("Администрирование");
                        ConsoleMenu.Menu(new List<string> { "Автомобили", "Клиенты", "Промокоды" });
                        Console.Write("\nДля продолжения сделайте свой выбор...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                // метод для автомобиля
                                break;
                            case '2':
                                Console.Clear();
                                ConsoleMenu.Logo("Клиент");
                                ConsoleMenu.Menu(new List<string> { "Создать", "Редактировать", "Удалить" });
                                Console.Write("\nДля продолжения сделайте свой выбор...");
                                switch (Console.ReadKey().KeyChar)
                                {
                                    case '1':
                                        Client.CreateClient();
                                        break;
                                    case '2':
                                        // Редактировать
                                        break;
                                    case '3':
                                        // Удалить
                                        break;
                                }
                                break;
                            case '3':
                                // метод для промокода
                                break;
                        }
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
    }
    public class Administratin // придумать нормальное название
    {

    }
}