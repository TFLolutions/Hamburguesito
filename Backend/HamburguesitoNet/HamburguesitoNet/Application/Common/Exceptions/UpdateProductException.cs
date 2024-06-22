using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class UpdateProductException : Exception
    {
        public UpdateProductException() : base() { }
        public UpdateProductException(string message) : base(message) { }

        public UpdateProductException(string message, Exception inner) : base(message, inner) { }
    }
}
