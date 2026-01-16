using Domain.Entities;

namespace Application.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task<bool> ExistsAsync(Guid id);
}
