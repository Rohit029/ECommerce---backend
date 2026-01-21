using Application.Repositories;
using Domain.Entities;

namespace Application.Services;

public class CartService(ICartRepository cartRepo) : ICartService
{
    private readonly ICartRepository _cartRepo = cartRepo;

    public async Task AddItemAsync(Guid userId, Guid productId, int quantity)
    {
        var cart = await _cartRepo.GetByUserIdAsync(userId);

        if (cart == null)
        {
            cart = new Cart(userId);
            var item = cart.AddItem(productId, quantity);
            await _cartRepo.AddAsync(cart); // Cart + items inserted
            return;
        }

        var newItem = cart.AddItem(productId, quantity);

        // 🔥 THIS IS THE FIX
        _cartRepo.AddCartItemIfNew(newItem);

        await _cartRepo.SaveChangesAsync();
    }


    public async Task<Cart> GetCartAsync(Guid userId)
    {
        return await _cartRepo.GetByUserIdAsync(userId)
            ?? new Cart(userId);
    }

    public async Task ClearAsync(Guid userId)
    {
        var cart = await _cartRepo.GetByUserIdAsync(userId);
        if (cart != null)
            await _cartRepo.DeleteAsync(cart);
    }
}
