﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllAsync();
        Task<BrandDto> GetAsync(int? id);
        Task CreateAsync(BrandDto brandDto);
        Task EditAsync(BrandDto brandDto);
        Task DeleteAsync(int? id);
        void Dispose();
    }
}
