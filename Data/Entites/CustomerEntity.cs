﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entites;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
