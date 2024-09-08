using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class CreateProductException : Exception
    {
        public CreateProductException() : base() { }
        public CreateProductException(string message) : base(message) { }
        public CreateProductException(string message, Exception inner) : base(message, inner) { }
    }
}
