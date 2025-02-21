using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Interfaces;

public interface IUserService
{
    Task<UserEntity> CreateUserAsync(ProjectRegistrationForm form);
}
