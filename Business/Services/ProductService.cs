using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entites;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ProductEntity> CreateProductAsync(ProjectRegistrationForm form)
    {
        var entity = await _productRepository.GetAsync(x => x.ProductName == form.ProductName);

        return entity ??= await _productRepository.CreateAsync(ProductFactory.Create(form));

    }
}
