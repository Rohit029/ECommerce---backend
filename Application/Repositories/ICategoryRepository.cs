using Domain.Entities;

namespace Application.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
}