using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllAsync();
        Task<CarDto> GetAsync(int? id);
        Task CreateAsync(CarDto carDto);
        void Edit(CarDto carDto);
        void Delete(int? id);
        void Dispoce();
    }
}
