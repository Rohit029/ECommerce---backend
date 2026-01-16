using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalAmount { get; private set; }

    private Order() { }

    public Order(Guid userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        TotalAmount = 0;
    }

    public void MarkAsPaid()
    {
        Status = OrderStatus.Paid;
    }

    public void SetTotalAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Total amount must be greater than zero");

        TotalAmount = amount;
    }
}
