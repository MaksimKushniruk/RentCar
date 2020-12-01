using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    public static class Rent    // RentConsoleController
    {
        public static void CreateRent()
        {
            //Dictionary<string, string> rentFields = new Dictionary<string, string>();
            //rentFields.Add("Клиент", null);
            //rentFields.Add("Автомобиль", null);
            //rentFields.Add("Промокод", null);
            //rentFields.Add("Дата начала", null);
            //rentFields.Add("Дата окончания", null);
            //Customer customer;
            //Car car;
            //DiscountCoupon discountCoupon;
            //while (true)
            //{
            //    Console.Clear();
            //    ConsoleMenu.Header("Новый заказ");
            //    ConsoleMenu.Menu(rentFields);
            //    Console.Write("\nДля продолжения сделайте свой выбор...");
            //    switch (Console.ReadKey().KeyChar)
            //    {
            //        case '1':
            //            Console.Clear();
            //            ConsoleMenu.Header("Клиент");
            //            ConsoleMenu.Menu(new List<string> { "Новый клиент", "Выбрать клиента" });
            //            switch (Console.ReadKey().KeyChar)
            //            {
            //                case '1':
            //                    customer = Client.CreateClient();
            //                    ConsoleMenu.Header("Хотите выбрать текущего клиента?");
            //                    ConsoleMenu.MainMenu(new List<string> { "Да", "Нет" });
            //                    switch (Console.ReadKey().KeyChar)
            //                    {
            //                        case '1':
            //                            rentFields["Клиент"] = $"{customer.FirstName} {customer.LastName}";
            //                            break;
            //                        case '2':
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                    break;
            //                case '2':
            //                    customer = Client.GetClient();
            //                    if (customer != null)
            //                    {
            //                        rentFields["Клиент"] = $"{customer.FirstName} {customer.LastName}";
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        case '2':
            //            Console.Clear();
            //            ConsoleMenu.Header("Автомобиль");
            //            ConsoleMenu.Menu(new List<string> { "Выбрать автомобиль" });
            //            switch (Console.ReadKey().KeyChar)
            //            {
            //                case '1':
            //                    car = Vehicle.GetVehicle();
            //                    if (car != null)
            //                    {
            //                        rentFields["Автомобиль"] = $"{car.BrandName} {car.ModelName}";
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        case '3':
            //            Console.Clear();
            //            ConsoleMenu.Header("Промокод");
            //            ConsoleMenu.Menu(new List<string> { "Введите промокод" });
            //            switch (Console.ReadKey().KeyChar)
            //            {
            //                case '1':
            //                    discountCoupon = Coupon.GetDiscountCoupon();
            //                    if (discountCoupon != null)
            //                    {
            //                        rentFields["Промокод"] = $"Скидка {discountCoupon.Discount}%";
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        case '4':
            //            Console.Clear();
            //            ConsoleMenu.Header("Дата начала");
            //            break;
            //        case '5':
            //            Console.Clear();
            //            ConsoleMenu.Header("Дата окончания");
            //            break;
            //        default:
            //            break;
            //    }
            //}

        }
    }
}
