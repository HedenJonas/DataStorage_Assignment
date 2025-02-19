using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Dtos;

public class ProjectRegistrationForm
{
    [Required]
    public string ProjectNumber { get; set; } = null!;
    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string ProductName { get; set; } = null!;
    [Required]
    public decimal Rate { get; set; }
    [Required]
    public string StatusName { get; set; } = null!;
    [Required]
    public string UserName { get; set; } = null!;
}
