using Business.Dtos;
using Business.Models;
using Data.Entites;

namespace Business.Factories;

public static class ProductFactory
{
    public static ProductEntity Create(ProjectRegistrationForm form) => new()
    {
        ProductName = form.ProductName,
        Rate = form.Rate,
    };

    public static Product Create(ProductEntity entity) => new()
    {
        Id = entity.Id,
        ProductName = entity.ProductName,
        Price = entity.Rate * entity.Units,
        Units = entity.Units,
        Rate = entity.Rate,
    };
    public static ProductEntity Create(ProjectUpdateForm form) => new()
    {
        ProductName = form.ProductName,
        Rate = form.Rate,
    };
}
