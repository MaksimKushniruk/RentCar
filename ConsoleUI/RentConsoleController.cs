using System;
using System.Collections.Generic;
using System.Linq;
using Rent.Models;
using Rent.Services;
using Rent;

namespace ConsoleUI
{
    /// <summary>
    /// Rent Controller. All actions with reservations are here.
    /// </summary>
    public static class RentConsoleController
    {
        /// <summary>
        /// Main menu of rent controller.
        /// </summary>
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("Rent");
                ConsoleMenu.Menu(new List<string> { "New rent", "Edit rent", "Close rent", "Back" });
                Console.Write("\nPlease make your choice to continue...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        RentConsoleController.CreateRent();
                        break;
                    case '2':
                        RentConsoleController.EditRent();
                        break;
                    case '3':
                        RentConsoleController.CloseRent();
                        break;
                    case '4':
                        return;
                    default:
                        continue;
                }
            }
        }
        /// <summary>
        /// Creating reservation.
        /// </summary>
        public static void CreateRent()
        {
            Dictionary<string, string> rentFields = new Dictionary<string, string>();
            rentFields.Add("Customer", null);
            rentFields.Add("Car", null);
            rentFields.Add("Promo code", null);
            rentFields.Add("Back", null);
            Reservation reservation = null;
            Customer customer = null;
            Car car = null;
            DiscountCoupon discountCoupon = null;
            DateTime startDate;
            while (true)
            {
                if (customer != null && car != null && discountCoupon != null)
                {
                    Console.Clear();
                    ConsoleMenu.Header("Do you want to create new rent?");
                    ConsoleMenu.Menu(rentFields);
                    ConsoleMenu.MainMenu(new List<string> { "Yes", "No", "Back" });
                    Console.Write("\nPlease make your choice to continue...");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            IReservationService reservationService = new ReservationService();
                            ICarService carService = new CarService();
                            startDate = DateTime.Now;
                            reservation = new Reservation(car, customer, discountCoupon, startDate);
                            int id = reservationService.CreateReservation(reservation);
                            if (id > 0)
                            {
                                car.Status = CarRentStatus.InRent;
                                carService.UpdateCar(car.Id, car.ToDictionary());
                            }
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine($"New reservation successfully created with Id {id}");
                            return;
                        case '2':
                            break;
                        case '3':
                            return;
                        default:
                            continue;
                    }
                }
                while (true)
                {
                    Console.Clear();
                    ConsoleMenu.Header("New Rent");
                    ConsoleMenu.Menu(rentFields);
                    Console.Write("\nPlease make your choice to continue...");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            ConsoleMenu.Header("Customer");
                            ConsoleMenu.Menu(new List<string> { "New customer", "Choose customer", "Back" });
                            switch (Console.ReadKey().KeyChar)
                            {
                                case '1':
                                    customer = Operation.Create<Customer>(Operation.CreateCustomer, "New Customer", new List<string> { "First name", "Last name", "City", "Phone number" });
                                    ConsoleMenu.Header("Want to select current client?");
                                    ConsoleMenu.MainMenu(new List<string> { "Yes", "No" });
                                    switch (Console.ReadKey().KeyChar)
                                    {
                                        case '1':
                                            if (customer != null)
                                            {
                                                rentFields["Customer"] = $"{customer.FirstName} {customer.LastName}";
                                            }
                                            break;
                                        case '2':
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case '2':
                                    customer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                                    if (customer != null)
                                    {
                                        rentFields["Customer"] = $"{customer.FirstName} {customer.LastName}";
                                    }
                                    break;
                                case '3':
                                    break;
                                default:
                                    continue;
                            }
                            break;
                        case '2':
                            Console.Clear();
                            ConsoleMenu.Header("Car");
                            ConsoleMenu.Menu(new List<string> { "Choose Car", "Back" });
                            switch (Console.ReadKey().KeyChar)
                            {
                                case '1':
                                    car = Operation.Get<Car>(Operation.GetCar, "Enter Car Details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                                    if (car != null && car.Status != CarRentStatus.InRent)
                                    {
                                        rentFields["Car"] = $"{car.BrandName} {car.ModelName}";
                                    }
                                    else if (car != null && car.Status == CarRentStatus.InRent)
                                    {
                                        Console.WriteLine("Car in rent! Try another car.");
                                        car = null;
                                    }
                                    break;
                                case '2':
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case '3':
                            Console.Clear();
                            ConsoleMenu.Header("Promo code");
                            ConsoleMenu.Menu(new List<string> { "Enter promo code", "Back" });
                            switch (Console.ReadKey().KeyChar)
                            {
                                case '1':
                                    discountCoupon = Operation.Get<DiscountCoupon>(Operation.GetPromoCode, "Enter promo code", new List<string> { "Coupon" });
                                    if (discountCoupon != null)
                                    {
                                        rentFields["Promo code"] = $"Discount {discountCoupon.Discount}%";
                                    }
                                    break;
                                case '2':
                                    break;
                                default:
                                    break;
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
        /// <summary>
        /// Editing reservation.
        /// </summary>
        public static void EditRent()
        {
            Dictionary<string, string> rentFields = new Dictionary<string, string>();
            Reservation reservation = Operation.Get<Reservation>(Operation.GetReservation, "Find Reservation", new List<string> { "Id", "Car Id", "Customer Id", "Discount Coupon Id", "MinDate", "MaxDate" });
            if (reservation == null)
                return;
            Customer customer = reservation.Customer;
            Car car = reservation.Car;
            Car tryCar = null;
            DiscountCoupon discountCoupon = reservation.DiscountCoupon;
            DateTime? startDate = reservation.StartDate;
            DateTime? finalDate = reservation.FinalDate;
            rentFields.Add("Customer", $"{customer.FirstName} {customer.LastName}");
            rentFields.Add("Car", $"{car.BrandName} {car.ModelName}");
            rentFields.Add("Promo code", $"Discount {discountCoupon.Discount}%");
            rentFields.Add("Start Date", $"Starting date is {startDate}");
            rentFields.Add("Final Date", $"Final date is {finalDate}");
            rentFields.Add("Finish Editing", null);
            rentFields.Add("Back", null);
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("Edit Rent");
                ConsoleMenu.Menu(rentFields);
                Console.Write("\nPlease make your choice to continue...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ConsoleMenu.Header("Customer");
                        ConsoleMenu.Menu(new List<string> { "New customer", "Choose customer" });
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                customer = Operation.Create<Customer>(Operation.CreateCustomer, "New Customer", new List<string> { "First name", "Last name", "City", "Phone number" });
                                ConsoleMenu.Header("Want to select current client?");
                                ConsoleMenu.MainMenu(new List<string> { "Yes", "No" });
                                switch (Console.ReadKey().KeyChar)
                                {
                                    case '1':
                                        rentFields["Customer"] = $"{customer.FirstName} {customer.LastName}";
                                        break;
                                    case '2':
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case '2':
                                customer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                                if (customer != null)
                                {
                                    rentFields["Customer"] = $"{customer.FirstName} {customer.LastName}";
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        ConsoleMenu.Header("Car");
                        ConsoleMenu.Menu(new List<string> { "Choose Car" });
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                tryCar = Operation.Get<Car>(Operation.GetCar, "Enter Car Details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                                if (tryCar.Status == CarRentStatus.InRent)
                                {
                                    Console.WriteLine("Car in rent! Try another car.");
                                    tryCar = null;
                                }
                                if (tryCar != null)
                                {
                                    rentFields["Car"] = $"{tryCar.BrandName} {tryCar.ModelName}";
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case '3':
                        Console.Clear();
                        ConsoleMenu.Header("Promo code");
                        ConsoleMenu.Menu(new List<string> { "Enter promo code" });
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                discountCoupon = Operation.Get<DiscountCoupon>(Operation.GetPromoCode, "Enter promo code", new List<string> { "Coupon" });
                                if (discountCoupon != null)
                                {
                                    rentFields["Promo code"] = $"Discount {discountCoupon.Discount}%";
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case '6':
                        IReservationService reservationService = new ReservationService();
                        if (tryCar != null)
                        {
                            ICarService carService = new CarService();
                            car.Status = CarRentStatus.Free;
                            tryCar.Status = CarRentStatus.InRent;
                            reservation = new Reservation(reservation.Id, tryCar, customer, discountCoupon, (DateTime)startDate);
                            carService.UpdateCar(car.Id, car.ToDictionary());
                            carService.UpdateCar(tryCar.Id, tryCar.ToDictionary());
                        }
                        else
                        {
                            reservation = new Reservation(reservation.Id, car, customer, discountCoupon, (DateTime)startDate);
                        }
                        reservationService.UpdateReservation(reservation.Id.Value, reservation.ToDictionary());
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Reservation successfully updated...         ");
                        return;
                    case '7':
                        return;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Close reservation.
        /// </summary>
        public static void CloseRent()
        {
            Dictionary<string, string> rentFields = new Dictionary<string, string>();
            Reservation reservation = Operation.Get<Reservation>(Operation.GetReservation, "Find Reservation", new List<string> { "Id", "Car Id", "Customer Id", "Discount Coupon Id", "MinDate", "MaxDate" });
            if (reservation == null)
                return;
            Customer customer = reservation.Customer;
            Car car = reservation.Car;
            DiscountCoupon discountCoupon = reservation.DiscountCoupon;
            reservation.FinalDate = DateTime.Now;
            DateTime? startDate = reservation.StartDate;
            DateTime? finalDate = reservation.FinalDate;
            reservation.Price = (((car.PricePerHour * (decimal)Math.Round(finalDate.Value.Subtract(startDate.Value).TotalHours, MidpointRounding.ToPositiveInfinity))) / 100) * (100 - discountCoupon.Discount);
            rentFields.Add("Customer", $"{customer.FirstName} {customer.LastName}");
            rentFields.Add("Car", $"{car.BrandName} {car.ModelName}");
            rentFields.Add("Promo code", $"Discount {discountCoupon.Discount}%");
            rentFields.Add("Start date", $"Start date is {startDate}");
            rentFields.Add("Final date", $"Final date is {finalDate}");
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("Close Reservation");
                ConsoleMenu.Menu(reservation.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Close", "Back" });
                Console.Write("\nPlease make your choice to continue...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        IReservationService reservationService = new ReservationService();
                        ICarService carService = new CarService();
                        bool result = reservationService.DeleteReservation(reservation.Id.Value);
                        if (result)
                        {
                            car.Status = CarRentStatus.Free;
                            carService.UpdateCar(car.Id, car.ToDictionary());
                            Console.Clear();
                            ConsoleMenu.Header("Close Reservation");
                            Console.WriteLine("Reservation successfully closed...");
                        }
                        return;
                    case '2':
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
