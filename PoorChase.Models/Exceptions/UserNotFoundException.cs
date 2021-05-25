using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Entities
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base() { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
