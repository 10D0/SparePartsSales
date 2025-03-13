using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChiVauVa.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int LegacyUserId { get; set; }
    }

}
