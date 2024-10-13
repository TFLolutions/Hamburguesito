using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions.Login
{
    public class LoginException : Exception
    {
        public LoginException() : base() { }
        public LoginException(string message) : base(message) { }
        public LoginException(string message, Exception inner) : base(message, inner) { }
    }
}
