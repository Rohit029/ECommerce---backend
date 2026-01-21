using Application.DTOs;

namespace Application.Services;

public interface IOrderQueryService
{
    Task<List<OrderResponse>> GetMyOrdersAsync(Guid userId);
    Task<OrderResponse?> GetOrderByIdAsync(Guid orderId, Guid userId, bool isAdmin);
    Task<List<OrderResponse>> GetAllOrdersAsync();
}
