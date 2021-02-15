using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Core.Validation
{
    public class RentCarValidationException : Exception
    {
        public string Property { get; protected set; }
        public RentCarValidationException(string property, string message)
            : base(message)
        {
            Property = property;
        }
    }
}
