using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegisterUserResponse
    {
        public bool Success { get; set; }
        public string Errors { get; set; }
    }
}
