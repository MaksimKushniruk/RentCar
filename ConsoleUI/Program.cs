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
                ConsoleMenu.Header("You are welcomed by the car rental service.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ConsoleMenu.Header("Select an action.");
                ConsoleMenu.MainMenu(new List<string> { "Rent", "Administration" });
                Console.Write("\nPlease make your choice to continue...");
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
            ConsoleMenu.Menu(new List<string> { "New rent", "Edit rent", "Close rent" });
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
                default:
                    break;
            }
        }

        public static void CreateRent()
        {
            Dictionary<string, string> rentFields = new Dictionary<string, string>();
            rentFields.Add("Customer", null);
            rentFields.Add("Car", null);
            rentFields.Add("Promo code", null);
            Reservation reservation = null;
            Customer customer = null;
            Car car = null;
            DiscountCoupon discountCoupon = null;
            DateTime startDate;
            while (true)
            {
                if(customer != null && car != null && discountCoupon != null)
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
                                return;
                        }
                }
                Console.Clear();
                ConsoleMenu.Header("New Rent");
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
                                car = Operation.Get<Car>(Operation.GetCar, "Enter Car Details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                                if (car.Status == CarRentStatus.InRent)
                                {
                                    Console.WriteLine("Car in rent! Try another car.");
                                    car = null;
                                }
                                if (car != null)
                                {
                                    rentFields["Car"] = $"{car.BrandName} {car.ModelName}";
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
                    default:
                        break;
                }
            }

        }
        public static void EditRent()
        {
            Dictionary<string, string> rentFields = new Dictionary<string, string>();
            Reservation reservation = Operation.Get<Reservation>(Operation.GetReservation, "Find Reservation", new List<string> { "Id", "Car Id", "Customer Id", "Discount Coupon Id", "MinDate", "MaxDate" });
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
                    default:
                        break;
                }
            }
        }
        public static void CloseRent()
        {
            Dictionary<string, string> rentFields = new Dictionary<string, string>();
            Reservation reservation = Operation.Get<Reservation>(Operation.GetReservation, "Find Reservation", new List<string> { "Id", "Car Id", "Customer Id", "Discount Coupon Id", "MinDate", "MaxDate" });
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
                ConsoleMenu.MainMenu(new List<string> { "Close", "Back"});
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
                            break;
                        case '2':
                            Customer editCustomer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                            Operation.Edit<Customer>(Operation.EditCustomer, "Edit customer", editCustomer);
                            break;
                        case '3':
                            Customer deleteCustomer = Operation.Get<Customer>(Operation.GetCustomer, "Enter customer details", new List<string> { "Id", "First name", "Last name", "City", "Phone number" });
                            Operation.Delete<Customer>(Operation.DeleteCustomer, "Delete customer", deleteCustomer);
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
                            break;
                        case '2':
                            Car editCar = Operation.Get<Car>(Operation.GetCar, "Enter car details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                            Operation.Edit<Car>(Operation.EditCar, "Edit car", editCar);
                            break;
                        case '3':
                            Car deleteCar = Operation.Get<Car>(Operation.GetCar, "Enter car details", new List<string> { "Id", "License plate", "Model", "Brand", "Color", "Year", "Minimal price", "Maximal price", "Status" });
                            Operation.Delete<Car>(Operation.DeleteCar, "Delete car", deleteCar);
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
                            break;
                        case '2':
                            DiscountCoupon editDiscountCoupon = Operation.Get<DiscountCoupon>(Operation.GetDiscountCoupon, "Enter promo code details", new List<string> { "Id", "Coupon", "Minimal discount", "Maximal discount" });
                            Operation.Edit<DiscountCoupon>(Operation.EditDiscountCoupon, "Edit promo code", editDiscountCoupon);
                            break;
                        case '3':
                            DiscountCoupon deleteDiscountCoupon = Operation.Get<DiscountCoupon>(Operation.GetDiscountCoupon, "Enter promo code details", new List<string> { "Id", "Coupon", "Minimal discount", "Maximal discount" });
                            Operation.Delete<DiscountCoupon>(Operation.DeleteDiscountCoupon, "Delete promo code", deleteDiscountCoupon);
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
        public delegate void ObjectDeletingHandler<T>(T item);

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
        //
        // Enter reservation details
        // new List<string> { }
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
        public static DiscountCoupon GetPromoCode(Dictionary<string, string> fields)
        {
            while (true)
            {
                IDiscountCouponService discountCouponService = new DiscountCouponService();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Clear();
                ConsoleMenu.Header("Enter the Id of the required promo code");
                fields["Id"] = null;
                fields["Minimal discount"] = null;
                fields["Maximal discount"] = null;
                List<DiscountCoupon> discountCoupons = discountCouponService.GetDiscountCoupon(fields);
                ConsoleMenu.Print<DiscountCoupon>(discountCoupons);
                discountCoupons = discountCouponService.GetDiscountCoupon(new Dictionary<string, string>
                {
                    ["Id"] = Console.ReadLine(),
                    ["Coupon"] = null,
                    ["Minimal discount"] = null,
                    ["Maximal discount"] = null
                });
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
        public static Reservation GetReservation(Dictionary<string, string> fields)
        {

            while (true)
            {
                IReservationService reservationService = new ReservationService();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Clear();
                ConsoleMenu.Header("Enter the Id of the required reservation");
                List<Reservation> reservations = reservationService.GetReservation(fields);
                ConsoleMenu.PrintReservation(reservations);
                reservations = reservationService.GetReservation(new Dictionary<string, string>
                {
                    ["Id"] = Console.ReadLine(),
                    ["Car Id"] = null,
                    ["Customer Id"] = null,
                    ["Discount Coupon Id"] = null,
                    ["MinDate"] = null,
                    ["MaxDate"] = null
                });
                Console.Clear();
                ConsoleMenu.Header("Want to select current reservation?");
                ConsoleMenu.Menu(reservations.FirstOrDefault().ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Yes", "No", "Back" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        return reservations.FirstOrDefault();
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
        public static void Delete<T>(ObjectDeletingHandler<T> objectDeletingHandler, string headerText, T item)
        {
            Console.Clear();
            ConsoleMenu.Header(headerText);
            objectDeletingHandler.Invoke(item);
        }
        public static void DeleteCustomer(Customer customer)
        {
            while (true)
            {
                ICustomerService customerService = new CustomerService();
                ConsoleMenu.Menu(customer.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Delete", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        customerService.DeleteCustomer((int)customer.Id);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Customer with Id {customer.Id} was deleted.");
                        return;
                    case '2':
                        return;
                    default:
                        break;
                }
            }
        }
        public static void DeleteCar(Car car)
        {
            while (true)
            {
                ICarService carService = new CarService();
                ConsoleMenu.Menu(car.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Delete", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        carService.DeleteCar((int)car.Id);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Car with Id {car.Id} was deleted.");
                        return;
                    case '2':
                        return;
                    default:
                        break;
                }
            }
        }
        public static void DeleteDiscountCoupon(DiscountCoupon discountCoupon)
        {
            while (true)
            {
                IDiscountCouponService discountCouponService = new DiscountCouponService();
                ConsoleMenu.Menu(discountCoupon.ToDictionary());
                ConsoleMenu.MainMenu(new List<string> { "Delete", "Cancel" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        discountCouponService.DeleteDiscountCoupon((int)discountCoupon.Id);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine($"Promo code with Id {discountCoupon.Id} was deleted.");
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