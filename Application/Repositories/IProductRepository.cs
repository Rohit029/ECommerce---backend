using Domain.Entities;

namespace Application.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync(int page, int pageSize, Guid? categoryId);
    Task AddAsync(Product product);
    Task<bool> ExistsAsync(Guid id);
}
