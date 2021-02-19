using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAll();
        BrandDto Get(int? id);
        void Create(BrandDto brandDto);
        void Edit(BrandDto brandDto);
        void Delete(int? id);
        void Dispose();
    }
}
