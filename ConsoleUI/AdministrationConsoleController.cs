using System;
using System.Collections.Generic;
using System.Linq;
using Rent.Models;
using Rent.Services;
using Rent;

namespace ConsoleUI
{
    public static class AdministrationConsoleController
    {
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("Administration");
                ConsoleMenu.Menu(new List<string> { "Customers", "Cars", "Promo codes", "Back" });
                Console.Write("\nPlease make your choice to continue...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ConsoleMenu.Header("Customer");
                        ConsoleMenu.Menu(new List<string> { "Create", "Edit", "Delete", "Back" });
                        Console.Write("\nPlease make your choice to continue...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                Operation.Create<Customer>(Operation.CreateCustomer, "New customer", new List<string> { "First name", "Last name", "City", "Phone number" });
                                break;
                            case '2':
                                Customer editCustomer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                                if (editCustomer != null)
                                {
                                    Operation.Edit<Customer>(Operation.EditCustomer, "Edit customer", editCustomer);
                                }
                                break;
                            case '3':
                                Customer deleteCustomer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                                Operation.Delete<Customer>(Operation.DeleteCustomer, "Delete customer", deleteCustomer);
                                break;
                            case '4':
                                break;
                            default:
                                continue;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        ConsoleMenu.Header("Car");
                        ConsoleMenu.Menu(new List<string> { "Create", "Edit", "Delete", "Back" });
                        Console.Write("\nPlease make your choice to continue...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                Operation.Create<Car>(Operation.CreateCar, "New car", new List<string> { "License plate", "Model", "Brand", "Color", "Year", "Price" });
                                break;
                            case '2':
                                Car editCar = Operation.Get<Car>(Operation.GetCar, "Enter car details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                                Operation.Edit<Car>(Operation.EditCar, "Edit car", editCar);
                                break;
                            case '3':
                                Car deleteCar = Operation.Get<Car>(Operation.GetCar, "Enter car details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                                Operation.Delete<Car>(Operation.DeleteCar, "Delete car", deleteCar);
                                break;
                            case '4':
                                break;
                            default:
                                continue;
                        }
                        break;
                    case '3':
                        Console.Clear();
                        ConsoleMenu.Header("Promo code");
                        ConsoleMenu.Menu(new List<string> { "Create", "Edit", "Delete", "Back" });
                        Console.Write("\nPlease make your choice to continue...");
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                Operation.Create<DiscountCoupon>(Operation.CreateDiscountCoupon, "New promo code", new List<string> { "Coupon", "Discount" });
                                break;
                            case '2':
                                DiscountCoupon editDiscountCoupon = Operation.Get<DiscountCoupon>(Operation.GetDiscountCoupon, "Enter promo code details", new List<string> { "Id", "Coupon", "Minimal discount", "Maximal discount" });
                                Operation.Edit<DiscountCoupon>(Operation.EditDiscountCoupon, "Edit promo code", editDiscountCoupon);
                                break;
                            case '3':
                                DiscountCoupon deleteDiscountCoupon = Operation.Get<DiscountCoupon>(Operation.GetDiscountCoupon, "Enter promo code details", new List<string> { "Id", "Coupon", "Minimal discount", "Maximal discount" });
                                Operation.Delete<DiscountCoupon>(Operation.DeleteDiscountCoupon, "Delete promo code", deleteDiscountCoupon);
                                break;
                            case '4':
                                break;
                            default:
                                continue;
                        }
                        break;
                    case '4':
                        return;
                    default:
                        continue;
                }
            }
        }
    }
}
