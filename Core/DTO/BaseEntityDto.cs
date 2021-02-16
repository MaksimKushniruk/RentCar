using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public abstract class BaseEntityDto
    {
        public virtual int Id { get; protected set; }
    }
}
