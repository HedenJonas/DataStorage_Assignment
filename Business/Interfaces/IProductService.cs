using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Interfaces;

public interface IProductService
{
    Task<ProductEntity> CreateProductAsync(ProjectRegistrationForm form);
}