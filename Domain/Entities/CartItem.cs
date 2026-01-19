namespace Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    private CartItem() { }

    public CartItem(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public void Increase(int quantity)
    {
        Quantity += quantity;
    }
}
