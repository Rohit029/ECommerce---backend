using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.API.Controllers;

[Authorize]
[ApiController]
[Route("api/orders")]
public class OrdersController(IOrderService orderService, IOrderQueryService orderQueryService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;
    private readonly IOrderQueryService _orderQueryService = orderQueryService;
    //private Guid GetUserId()
    //{
    //    return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    //}

    //[HttpPost("checkout")]
    //public async Task<IActionResult> Checkout()
    //{
    //    var orderId = await _orderService.CheckoutAsync(GetUserId());
    //    return Ok(new { orderId });
    //}

    private Guid UserId =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    private bool IsAdmin =>
        User.IsInRole("Admin");

    // ✅ EXISTING CHECKOUT (UNCHANGED)
    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout()
    {
        var orderId = await _orderService.CheckoutAsync(UserId);
        return Ok(new { orderId });
    }

    // ✅ NEW: CUSTOMER ORDER HISTORY
    [HttpGet("my")]
    public async Task<IActionResult> MyOrders()
    {
        var orders = await _orderQueryService.GetMyOrdersAsync(UserId);
        return Ok(orders);
    }

    // ✅ NEW: ORDER DETAILS (OWNER OR ADMIN)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderQueryService.GetOrderByIdAsync(id, UserId, IsAdmin);
        return order == null ? NotFound() : Ok(order);
    }

    // ✅ NEW: ADMIN – ALL ORDERS
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _orderQueryService.GetAllOrdersAsync());
    }
}
