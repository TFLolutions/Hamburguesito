using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        public string Role { get; set; }
        public DateTime CreationDate { get; set; }

    }

}
}
