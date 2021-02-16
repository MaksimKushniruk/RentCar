﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car Get(int id);
        IEnumerable<Car> Find(Func<Car, bool> predicate);
        void Create(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}