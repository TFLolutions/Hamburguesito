using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Models
{
    public class UserTenant
    {
        //This model has a composal key


        public int IdUser { get; set; }
        public int IdTenant { get; set; }


      
    }
}
