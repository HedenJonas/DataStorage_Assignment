﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entites;

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
