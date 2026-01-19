using Domain.Entities;

namespace Application.Services;

public interface ICartService
{
    Task AddItemAsync(Guid userId, Guid productId, int quantity);
    Task<Cart> GetCartAsync(Guid userId);
    Task ClearAsync(Guid userId);
}

