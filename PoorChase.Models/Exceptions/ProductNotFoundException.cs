using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Entities
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base() { }
        public ProductNotFoundException(string message) : base(message) { }
    }
}
