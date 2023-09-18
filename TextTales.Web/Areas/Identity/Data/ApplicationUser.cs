using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TextTales.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Country { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? StreetAddress { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }
}

