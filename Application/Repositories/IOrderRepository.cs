using Domain.Entities;

namespace Application.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();

    Task<List<Order>> GetByUserIdAsync(Guid userId);
    Task<Order?> GetByIdAsync(Guid orderId);
    Task<List<Order>> GetAllAsync();
}

