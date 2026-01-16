
using Application.DTOs;
using Application.Repositories;
using Domain.Entities;

namespace Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Guid> CreateAsync(CreateProductRequest request)
    {
        var product = new Product(
            request.Name,
            request.Description,
            request.BasePrice,
            request.CategoryId
        );

        await _productRepository.AddAsync(product);
        return product.Id;
    }
}
