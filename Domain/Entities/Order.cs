using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalAmount { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();

    private Order() { }

    public Order(Guid userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
    }

    public void AddItem(Guid productId, int quantity, decimal price)
    {
        Items.Add(new OrderItem(Id, productId, quantity, price));
        RecalculateTotal();
    }

    public void MarkAsPaid()
    {
        Status = OrderStatus.Paid;
    }

    private void RecalculateTotal()
    {
        TotalAmount = Items.Sum(i => i.Price * i.Quantity);

        if (TotalAmount <= 0)
            throw new InvalidOperationException("Order total must be greater than zero");
    }
}
