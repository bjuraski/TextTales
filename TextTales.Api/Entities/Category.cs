using System.ComponentModel.DataAnnotations;

namespace TextTales.Api.Entities;

public class Category
{
    public long Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 50, ErrorMessage = "The Display Order value must be between 1 and 50.")]
    public int DisplayOrder { get; set; }
}
