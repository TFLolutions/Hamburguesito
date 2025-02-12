using Domain.Models.Common;
public class Tenant : Audit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
}

