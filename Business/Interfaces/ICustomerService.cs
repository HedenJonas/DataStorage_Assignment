using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<CustomerEntity> CreateCustomerAsync(ProjectRegistrationForm form);
}
