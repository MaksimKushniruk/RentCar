﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class CarDto : BaseEntityDto
    {
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal PricePerHour { get; set; }
        public CarStatusDto Status { get; set; }
        public string ImagePath { get; set; }
        public BrandDto Brand { get; set; }
        public List<ReservationDto> Reservations { get; set; }
        public CarDto()
        {
            Reservations = new List<ReservationDto>();
        }
    }
}
