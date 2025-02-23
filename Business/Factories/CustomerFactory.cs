using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create(ProjectRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        Address = form.Address,
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        Address = entity.Address,
    };

    public static CustomerEntity Create(ProjectUpdateForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        Address = form.Address,
    };
}
