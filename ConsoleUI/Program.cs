using System;
using System.Collections.Generic;
using System.Linq;
using Rent.Models;
using Rent.Services;
using Rent;

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
                        RentConsoleController.Menu();
                        break;
                    case '2':
                        AdministrationConsoleController.Menu();
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
    }

    public static class RentConsoleController
    {
        public static void Menu()
        {
            Console.Clear();
            ConsoleMenu.Header("Rent");
            ConsoleMenu.Menu(new List<string> { "New rent", "Edit rent", "Cancel rent", "Find rent" });
            Console.Write("\nPlease make your choice to continue...");
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
        }
    }
    public static class AdministrationConsoleController 
    {
        public static void Menu()
        {

            Console.Clear();
            ConsoleMenu.Header("Administration");
            ConsoleMenu.Menu(new List<string> { "Customers", "Cars", "Promo codes" });
            Console.Write("\nPlease make your choice to continue...");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.Clear();
                    ConsoleMenu.Header("Customer");
                    ConsoleMenu.Menu(new List<string> { "Create", "Edit", "Delete" });
                    Console.Write("\nPlease make your choice to continue...");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Operation.Create<Customer>(Operation.CreateCustomer, "New customer", new List<string> { "First name", "Last name", "City", "Phone number" });
                            return;
                        case '2':
                            Customer customer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                            Operation.Edit<Customer>(Operation.EditCustomer, "Edit customer", customer);
                            break;
                        case '3':
                            // Удалить
                            break;
                        default:
                            break;
                    }
                    break;
                case '2':
                    Console.Clear();
                    ConsoleMenu.Header("Car");
                    ConsoleMenu.Menu(new List<string> { "Create", "Edit", "Delete" });
                    Console.Write("\nPlease make your choice to continue...");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Operation.Create<Car>(Operation.CreateCar, "New car", new List<string> { "License plate", "Model", "Brand", "Color", "Year", "Price" });
                            return;
                        case '2':
                            Car car = Operation.Get<Car>(Operation.GetCar, "Enter car details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                            Operation.Edit<Car>(Operation.EditCar, "Edit car", car);
                            break;
                        case '3':
                            // Удалить
                            break;
                        default:
                            break;
                    }
                    break;
                case '3':
                    Console.Clear();
                    ConsoleMenu.Header("Promo code");
                    ConsoleMenu.Menu(new List<string> { "Create", "Edit", "Delete" });
                    Console.Write("\nPlease make your choice to continue...");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Operation.Create<DiscountCoupon>(Operation.CreateDiscountCoupon, "New promo code", new List<string> { "Coupon", "Discount" });
                            return;
                        case '2':
                            DiscountCoupon discountCoupon = Operation.Get<DiscountCoupon>(Operation.GetDiscountCoupon, "Enter promo code details", new List<string> { "Id", "Coupon", "Minimal discount", "Maximal discount" });
                            Operation.Edit<DiscountCoupon>(Operation.EditDiscountCoupon, "Edit promo code", discountCoupon);
                            break;
                        case '3':
                            // Удалить
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
    }

    public static class Operation
    {
        // Delegate 
        public delegate T ObjectCreationHandler<T>(Dictionary<string, string> fields);
        public delegate T ObjectLookupHandler<T>(Dictionary<string, string> fields);
        public delegate T ObjectEditingHandler<T>(T value);

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
        public static Customer CreateCustomer(Dictionary<string, string> fields)
        {
            ICustomerService customerService = new CustomerService();
            Customer customer = customerService.CreateCustomer(fields);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"New customer Id: {customer.Id}");
            return customer;
        }
        public static Car CreateCar(Dictionary<string, string> fields)
        {
            ICarService carService = new CarService();
            Car car = carService.CreateCar(fields);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"New car Id: {car.Id}");
            return car;
        }
        public static DiscountCoupon CreateDiscountCoupon(Dictionary<string, string> fields)
        {
            IDiscountCouponService discountCouponService = new DiscountCouponService();
            DiscountCoupon discountCoupon = discountCouponService.CreateDiscountCoupon(fields);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"New promo code Id: {discountCoupon.Id}");
            return discountCoupon;
        }

        // Get Object
        // Enter the data
        // Enter customer details
        // new List<string> { "Id", "First name", "Last name", "City", "Phone number" }
        //
        // Enter car details
        // new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" }
        //
        // Enter promo code details
        // new List<string> { "Id", "Coupon", "Minimal discount", "Maximal discount" }
        public static T Get<T>(ObjectLookupHandler<T> objectLookupHandler, string headerText, List<string> fieldKeys)
        {
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header(headerText);
                Dictionary<string, string> fields = ConsoleMenu.InputData(fieldKeys);
                
                ConsoleMenu.MainMenu(new List<string> { "Find", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return objectLookupHandler.Invoke(fields);
                    case '2':
                        return default;
                    default:
                        continue;

                }
            }
        }
        public static Customer GetCustomer(Dictionary<string, string> fields)
        {
            while (true)
            {
                ICustomerService customerService = new CustomerService();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Clear();
                ConsoleMenu.Header("Enter the Id of the required client");
                List<Customer> customers = customerService.GetCustomer(fields);
                ConsoleMenu.Print<Customer>(customers);
                customers = customerService.GetCustomer(new Dictionary<string, string> { ["Id"] = Console.ReadLine(),
                                                                                         ["First name"] = null,
                                                                                         ["Last name"] = null,
                                                                                         ["City"] = null,
                                                                                         ["Phone number"] = null});
                Console.Clear();
                ConsoleMenu.Header("Want to select current client?");
                ConsoleMenu.Menu(customers.FirstOrDefault().ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Yes", "No", "Back" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return customers.FirstOrDefault();
                    case '2':
                        continue;
                    case '3':
                        return null;
                    default:
                        break;
                }
            }
        }
        public static Car GetCar(Dictionary<string, string> fields)
        {
            while (true)
            {
                ICarService carService = new CarService();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Clear();
                ConsoleMenu.Header("Enter the Id of the required car");
                List<Car> cars = carService.GetCar(fields);
                ConsoleMenu.Print<Car>(cars);
                cars = carService.GetCar(new Dictionary<string, string> { ["Id"] = Console.ReadLine(),
                                                                          ["License plate"] = null, 
                                                                          ["Model"] = null, 
                                                                          ["Brand"] = null, 
                                                                          ["Color"] = null, 
                                                                          ["Year"] = null, 
                                                                          ["Minimal price"] = null, 
                                                                          ["Maximal price"] = null, 
                                                                          ["Status"] = null});
                Console.Clear();
                ConsoleMenu.Header("Want to select current car?");
                ConsoleMenu.Menu(cars.FirstOrDefault().ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Yes", "No", "Back" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return cars.FirstOrDefault();
                    case '2':
                        continue;
                    case '3':
                        return null;
                    default:
                        break;
                }
            }
        }
        public static DiscountCoupon GetDiscountCoupon(Dictionary<string, string> fields)
        {
            while (true)
            {
                IDiscountCouponService discountCouponService = new DiscountCouponService();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Clear();
                ConsoleMenu.Header("Enter the Id of the required promo code");
                List<DiscountCoupon> discountCoupons = discountCouponService.GetDiscountCoupon(fields);
                ConsoleMenu.Print<DiscountCoupon>(discountCoupons);
                discountCoupons = discountCouponService.GetDiscountCoupon(new Dictionary<string, string> { ["Id"] = Console.ReadLine(),
                                                                                                           ["Coupon"] = null,
                                                                                                           ["Minimal discount"] = null,
                                                                                                           ["Maximal discount"] = null});
                Console.Clear();
                ConsoleMenu.Header("Want to select current promo code?");
                ConsoleMenu.Menu(discountCoupons.FirstOrDefault().ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Yes", "No", "Back" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return discountCoupons.FirstOrDefault();
                    case '2':
                        continue;
                    case '3':
                        return null;
                    default:
                        break;
                }
            }
        }

        // Edit Objects
        // Edit customer
        // Edit car
        // Edit promo code

        public static T Edit<T>(ObjectEditingHandler<T> objectEditingHandler, string headerText, T value)
        {
            Console.Clear();
            ConsoleMenu.Header(headerText);
            return objectEditingHandler.Invoke(value);
        }

        public static Customer EditCustomer(Customer customer)
        {
            while (true)
            {
                ICustomerService customerService = new CustomerService();
                Dictionary<string, string> fieldsForUpdate = ConsoleMenu.UpdateData(customer.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Apply", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Customer client = customerService.UpdateCustomer((int)customer.Id, fieldsForUpdate);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Customer with Id {client.Id} was updated.");
                        return client;
                    case '2':
                        return null;
                    default:
                        break;
                }
            }
        }
        public static Car EditCar(Car car)
        {
            while (true)
            {
                ICarService carService = new CarService();
                Dictionary<string, string> fieldsForUpdate = ConsoleMenu.UpdateData(car.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Apply", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Car vehicle =  carService.UpdateCar((int)car.Id, fieldsForUpdate);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Car with Id {vehicle.Id} was updated.");
                        return vehicle;
                    case '2':
                        return null;
                    default:
                        break;
                }
            }
        }
        public static DiscountCoupon EditDiscountCoupon(DiscountCoupon discountCoupon)
        {
            while (true)
            {
                IDiscountCouponService discountCouponService = new DiscountCouponService();
                Dictionary<string, string> fieldsForUpdate = ConsoleMenu.UpdateData(discountCoupon.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Apply", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        DiscountCoupon promoCode =  discountCouponService.UpdateDiscountCoupon((int)discountCoupon.Id, fieldsForUpdate);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Promo code with Id {promoCode.Id} was updated.");
                        return promoCode;
                    case '2':
                        return null;
                    default:
                        break;
                }
            }
        }
    }
}