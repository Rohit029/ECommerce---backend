using Domain.Entities;

namespace Application.Repositories;

public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(Guid userId);
    Task AddAsync(Cart cart);
    //Task UpdateAsync(Cart cart);
    public void AddCartItemIfNew(CartItem item);
    Task SaveChangesAsync();
    Task DeleteAsync(Cart cart);
}