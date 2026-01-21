using Application.DTOs;
using Application.Repositories;

namespace Application.Services;

public class OrderQueryService(IOrderRepository orderRepository) : IOrderQueryService
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<List<OrderResponse>> GetMyOrdersAsync(Guid userId)
    {
        var orders = await _orderRepository.GetByUserIdAsync(userId);
        return orders.Select(Map).ToList();
    }

    public async Task<OrderResponse?> GetOrderByIdAsync(Guid orderId, Guid userId, bool isAdmin)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null) return null;

        if (!isAdmin && order.UserId != userId)
            throw new UnauthorizedAccessException("Access denied");

        return Map(order);
    }

    public async Task<List<OrderResponse>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Select(Map).ToList();
    }

    private static OrderResponse Map(Domain.Entities.Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Status = order.Status.ToString(),
            TotalAmount = order.TotalAmount,
            Items = order.Items.Select(i => new OrderItemResponse
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList()
        };
    }
}