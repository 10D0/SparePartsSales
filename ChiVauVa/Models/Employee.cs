using System;
using System.Collections.Generic;

namespace ChiVauVa.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Position { get; set; }

    public string? Department { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Users User { get; set; } = null!;
}
