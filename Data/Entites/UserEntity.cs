using System.ComponentModel.DataAnnotations;

namespace Data.Entites;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
