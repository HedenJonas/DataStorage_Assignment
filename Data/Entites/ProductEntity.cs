﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entites;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int Units { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Rate { get; set; }

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}