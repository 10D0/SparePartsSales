using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ChiVauVa.Models;

public partial class User : IdentityUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
