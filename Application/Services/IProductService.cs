using Application.DTOs;

namespace Application.Services;

public interface IProductService
{
    Task<Guid> CreateAsync(CreateProductRequest request);
}
