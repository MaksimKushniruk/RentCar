using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarDto> GetAll();
        CarDto Get(int? id);
        void Create(CarDto carDto);
        void Edit(CarDto carDto);
        void Delete(int? id);
        void Dispoce();
    }
}
