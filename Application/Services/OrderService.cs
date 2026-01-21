using Application.Repositories;
using Domain.Entities;

namespace Application.Services;

public class OrderService(
    ICartRepository cartRepo,
    IOrderRepository orderRepo,
    IProductRepository productRepo) : IOrderService
{
    private readonly ICartRepository _cartRepo = cartRepo;
    private readonly IOrderRepository _orderRepo = orderRepo;
    private readonly IProductRepository _productRepo = productRepo;

    public async Task<Guid> CheckoutAsync(Guid userId)
    {
        var cart = await _cartRepo.GetByUserIdAsync(userId);

        if (cart == null || !cart.Items.Any())
            throw new Exception("Cart is empty");

        await _orderRepo.BeginTransactionAsync();

        var order = new Order(userId);

        foreach (var item in cart.Items)
        {
            var product = await _productRepo.GetByIdAsync(item.ProductId)
                ?? throw new Exception("Product not found");

            order.AddItem(product.Id, item.Quantity, product.BasePrice);
        }

        await _orderRepo.AddAsync(order);
        await _cartRepo.DeleteAsync(cart);

        await _orderRepo.CommitTransactionAsync();

        return order.Id;
    }
}

