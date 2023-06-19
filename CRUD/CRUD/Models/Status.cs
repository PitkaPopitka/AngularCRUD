using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Statusname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
