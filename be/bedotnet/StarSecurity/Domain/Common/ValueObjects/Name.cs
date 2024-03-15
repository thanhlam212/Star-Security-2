using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common.ValueObjects
{
    public class Name
    {
        //create variable Value to storage Name
        public string Value { get; }

        //create constructor
        public Name(string value)
        {
            //check null or white space of value
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(value));
            }

            //if oke, assign value to Value of Name => Name.Value
            Value = value;
        }
    }
}
