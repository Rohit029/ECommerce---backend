using Application.DTOs;

namespace Application.Services;

public interface ICategoryService
{
    Task<Guid> CreateAsync(CreateCategoryRequest request);
    Task<List<CategoryResponse>> GetAllAsync();
}