using Application.DTOs;
using Application.Repositories;
using Domain.Entities;

namespace Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Guid> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category(request.Name);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}