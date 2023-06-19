using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int Departmentid { get; set; }

    public int Statusid { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Dateofbirth { get; set; }

    public DateOnly Employmentdate { get; set; }

    public decimal Salary { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
