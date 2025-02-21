namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

    public string ProductName { get; set; } = null!;
    public decimal Rate { get; set; }

    public string StatusName { get; set; } = null!;

    public string UserName { get; set; } = null!;
}
