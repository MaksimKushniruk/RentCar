using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    public static class Client
    {
        public static Customer CreateClient()
        {
            ICustomerService customerService = new CustomerService();
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("Новый клиент");
                Dictionary<string, string> fields = ConsoleMenu.InputData(new List<string> { "Имя", "Фамилия", "Город", "Телефон" });
                ConsoleMenu.MainMenu(new List<string> { "Создать клиента", "Отменить" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Customer customer = customerService.CreateCustomer(fields);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Id нового клиента: {customer.Id}");
                        return customer;
                    case '2':
                        return null;
                    default:
                        break;
                }
            }
        }

        //public static Customer GetClient()
        //{
        //    ICustomerService customerService = new CustomerService();
        //    while (true)
        //    {
        //        Console.Clear();
        //        ConsoleMenu.Header("Введите данные");
        //        List<string> keys = new List<string> { "Id", "Имя", "Фамилия", "Город", "Телефон" };
        //        Dictionary<string, string> fields = ConsoleMenu.InputData(keys);
        //        int? id = string.IsNullOrEmpty(fields["Id"]) ? (int?)null : Int32.Parse(fields["Id"]);
        //        CustomerRequest request = new CustomerRequest(id, fields["Имя"], fields["Фамилия"], fields["Город"], fields["Телефон"]);
        //        List<Customer> customers = customerService.GetCustomer(request);
        //        Dictionary<string, string> client = new Dictionary<string, string>();
        //        ConsoleMenu.MainMenu(new List<string> { "Найти", "Отменить" });
        //        switch (Console.ReadKey().KeyChar)
        //        {
        //            case '1':
        //                Console.SetCursorPosition(0, Console.CursorTop);
        //                Console.Clear();
        //                ConsoleMenu.Header("Введите Id нужного клиента");
        //                ConsoleMenu.Print<Customer>(customers);
        //                customers = customerService.GetCustomer(new CustomerRequest { Id = Int32.Parse(Console.ReadLine()) });
        //                client.Add(keys[0], customers[0].Id.ToString());
        //                client.Add(keys[1], customers[0].FirstName);
        //                client.Add(keys[2], customers[0].LastName);
        //                client.Add(keys[3], customers[0].City);
        //                client.Add(keys[4], customers[0].PhoneNumber);
        //                Console.Clear();
        //                ConsoleMenu.Header("Хотите выбрать текущего клиента?");
        //                ConsoleMenu.Menu(client);
        //                ConsoleMenu.MainMenu(new List<string> { "Да", "Нет", "Назад" });
        //                switch (Console.ReadKey().KeyChar)
        //                {
        //                    case '1':
        //                        return customers[0];
        //                    case '2':
        //                        continue;
        //                    case '3':
        //                        return null;
        //                    default:
        //                        continue;
        //                }
        //            case '2':
        //                return null;
        //            default:
        //                continue;
        //        }
        //    }
        //}
    }
}
