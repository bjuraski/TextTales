using System.ComponentModel.DataAnnotations;

namespace TextTales.Models;

public class Product
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Author { get; set; } = string.Empty;

    [MaxLength(1500)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(20)]
    public string InternationalStandardBookNumber { get; set; } = string.Empty;

    [Required]
    [Range(1, 500)]
    public decimal Price { get; set; }

    public string? Image { get; set; }
}
