using Application.DTOs;

namespace Application.Services;

public interface IProductService
{
    Task<Guid> CreateAsync(CreateProductRequest request);
    Task<List<ProductResponse>> GetAllAsync(int page, int pageSize, Guid? categoryId);
}
