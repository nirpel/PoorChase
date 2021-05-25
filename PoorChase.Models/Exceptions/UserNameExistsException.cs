using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Entities
{
    public class UserNameExistsException : Exception
    {
        public UserNameExistsException() : base() { }
        public UserNameExistsException(string message) : base(message) { }
    }
}
