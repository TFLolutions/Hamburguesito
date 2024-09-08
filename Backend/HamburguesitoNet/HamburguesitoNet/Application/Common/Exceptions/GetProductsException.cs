using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class GetProductsException : Exception
    {
        public GetProductsException() : base() { }
        public GetProductsException(string message) : base(message) { }
        public GetProductsException(string message, Exception inner) : base(message, inner) { }
    }
}
