using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Factories;

public static class UserFactory
{
    public static UserEntity Create(ProjectRegistrationForm form) => new()
    {
        UserName = form.UserName,
    };
    public static User Create(UserEntity entity) => new()
    {
        Id = entity.Id,
        UserName = entity.UserName,
    };
}
