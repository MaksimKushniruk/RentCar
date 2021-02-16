using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _database;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }
        public IEnumerable<CarDto> GetAllCars()
        {
            IEnumerable<Car> cars = _database.Cars.GetAll();
            List<CarDto> carDtos = new List<CarDto>();
            foreach (Car car in cars)
            {
                carDtos.Add(new CarDto
                {
                    Id = car.Id,
                    LicensePlate = car.LicensePlate,
                    ModelName = car.ModelName,
                    Color = car.Color,
                    Year = car.Year,
                    PricePerHour = car.PricePerHour,
                    Status = (CarRentStatusDto)car.Status,
                    Brand = car.Brand.Title
                });
            }
            return carDtos;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            IEnumerable<Customer> customers = _database.Customers.GetAll();
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (Customer customer in customers)
            {
                customerDtos.Add(new CustomerDto
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    City = customer.City,
                    PhoneNumber = customer.PhoneNumber
                });
            }
            return customerDtos;
        }

        public CarDto GetCar(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Car car = _database.Cars.Get(id.Value);
            if (car == null)
            {
                throw new RentCarValidationException(String.Empty, "Car is don't found");
            }
            return new CarDto
            {
                Id = car.Id,
                LicensePlate = car.LicensePlate,
                ModelName = car.ModelName,
                Color = car.Color,
                Year = car.Year,
                PricePerHour = car.PricePerHour,
                Status = (CarRentStatusDto)car.Status,
                Brand = car.Brand.Title
            };
        }

        public CouponDto GetCoupon(string couponCode)
        {
            if (couponCode == null)
            {
                throw new RentCarValidationException(String.Empty, "Coupon Code is not set");
            }
            Coupon coupon = _database.Coupons.GetByCode(couponCode);
            if (coupon == null)
            {
                throw new RentCarValidationException(String.Empty, "Coupon is don't found");
            }
            return new CouponDto
            {
                Id = coupon.Id,
                CouponCode = coupon.CouponCode,
                Discount = coupon.Discount
            };
        }

        public CustomerDto GetCutomer(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Customer customer = _database.Customers.Get(id.Value);
            if (customer == null)
            {
                throw new RentCarValidationException(String.Empty, "Customer is don't found");
            }
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                City = customer.City,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public void MakeReservation(ReservationDto reservationDto)
        {
            Car car = _database.Cars.Get(reservationDto.CarId);
            if (car == null)
            {
                throw new RentCarValidationException(String.Empty, "Car is don't found");
            }

            // Math the price
            decimal? price = null;
            if (reservationDto.FinalDate != null)
            {
                price = (decimal)reservationDto.FinalDate.Subtract(reservationDto.StartDate).TotalHours * reservationDto.Car.PricePerHour;
            }

            Reservation reservation = new Reservation
            {
                CustomerId = reservationDto.Customer.Id,
                CarId = reservationDto.Car.Id,
                CouponId = reservationDto.Coupon.Id,
                StartDate = reservationDto.StartDate,
                FinalDate = reservationDto.FinalDate,
                Price = price
            };
            _database.Reservations.Create(reservation);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
