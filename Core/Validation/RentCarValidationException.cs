using System;

namespace Core.Validation
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
