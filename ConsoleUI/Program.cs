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
                ConsoleMenu.Header("Вас приветствует сервис аренды машин.");
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
                ConsoleMenu.Header("Выберите действие.");
                ConsoleMenu.MainMenu(new List<string> { "Аренда", "Администрирование" });
                Console.Write("\nДля продолжения сделайте свой выбор...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ConsoleMenu.Header("Аренда");
                        ConsoleMenu.Menu(new List<string> { "Новый заказ", "Редактировать заказ", "Отменить заказ", "Найти заказ" });
                        Console.Write("\nДля продолжения сделайте свой выбор...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                Rent.CreateRent();
                                break;
                            case '2':
                                Console.Clear();
                                ConsoleMenu.Header("Редактировать заказ");
                                ConsoleMenu.Menu(new List<string> { "Меню 1 ", "Меню 2 ", "Меню 3 ", "меню 4 " });
                                break;
                            case '3':
                                Console.Clear();
                                ConsoleMenu.Header("Отменить заказ ");
                                ConsoleMenu.Menu(new List<string> { "Меню 1 ", "Меню 2 ", "Меню 3 ", "меню 4 " });
                                break;
                            case '4':
                                Console.Clear();
                                ConsoleMenu.Header("Найти заказ");
                                ConsoleMenu.Menu(new List<string> { "Меню 1 ", "Меню 2 ", "Меню 3 ", "меню 4 " });
                                break;
                            default:
                                // сделать, чтобы не возвращало в главное меню
                                break;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        ConsoleMenu.Header("Администрирование");
                        ConsoleMenu.Menu(new List<string> { "Автомобили", "Клиенты", "Промокоды" });
                        Console.Write("\nДля продолжения сделайте свой выбор...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                // метод для автомобиля
                                break;
                            case '2':
                                Console.Clear();
                                ConsoleMenu.Header("Клиент");
                                ConsoleMenu.Menu(new List<string> { "Создать", "Редактировать", "Удалить" });
                                Console.Write("\nДля продолжения сделайте свой выбор...");
                                switch (Console.ReadKey().KeyChar)
                                {
                                    case '1':
                                        Client.CreateClient();
                                        return;
                                    case '2':
                                        // Редактировать
                                        break;
                                    case '3':
                                        // Удалить
                                        break;
                                    default:
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
    public class AdministrationConsoleController 
    {

    }

    public static class Operation
    {
        // Method for creating objects
        //
        // New customer
        // new List<string> { "First name", "Last name", "City", "Phone number" }
        //
        // New car
        // "License plate", "Model", "Brand", "Color", "Year", "Price"
        //
        // New promo code
        //  "Coupon", "Discount" 
        public static T Create<T>(ObjectCreationHandler<T> objectCreationHandler, string headerText, List<string> fieldKeys)
        {
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header(headerText);
                Dictionary<string, string> fields = ConsoleMenu.InputData(fieldKeys);  
                ConsoleMenu.MainMenu(new List<string> { "Create", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return objectCreationHandler.Invoke(fields);
                    case '2':
                        return default;
                    default:
                        break;
                }
            }
        }
        public delegate T ObjectCreationHandler<T>(Dictionary<string, string> fields);  
        private static Customer CreateCustomer(Dictionary<string, string> fields)
        {
            ICustomerService customerService = new CustomerService();
            Customer customer = customerService.CreateCustomer(fields);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"New customer Id: {customer.Id}");
            return customer;
        }

        // overloading
        public static Car Create(string licensePlate, string model, string brand, string color, string year, string price)
        {
            ICarService carService = new CarService();
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("New car");
                Dictionary<string, string> fields = ConsoleMenu.InputData(new List<string> { licensePlate, model, brand, color, year, price });
                ConsoleMenu.MainMenu(new List<string> { "Create", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Car car = carService.CreateCar(fields);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"New car Id: {car.Id}");
                        return car;
                    case '2':
                        return null;
                    default:
                        break;
                }
            }
        }
        // overloading
        public static DiscountCoupon Create(string coupon, string discount)
        {
            IDiscountCouponService discountCouponService = new DiscountCouponService();
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("New promo code");
                Dictionary<string, string> fields = ConsoleMenu.InputData(new List<string> { coupon, discount });
                ConsoleMenu.MainMenu(new List<string> { "Create", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        DiscountCoupon discountCoupon = discountCouponService.CreateDiscountCoupon(fields);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"New promo code Id: {discountCoupon.Id}");
                        return discountCoupon;
                    case '2':
                        return null;
                    default:
                        break;
                }
            }
        }
    }
}