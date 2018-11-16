using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace L7.Domain
{
    public class Price : ValueObject
    {
        public decimal Value { get; private set; }

        public static Price Create(decimal price)
        {
            return new Price
            {
                Value = price
            };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}