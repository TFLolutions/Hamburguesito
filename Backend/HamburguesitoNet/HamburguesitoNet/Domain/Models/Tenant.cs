using Domain.Models;
using Domain.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Tenant : Audit
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
}

