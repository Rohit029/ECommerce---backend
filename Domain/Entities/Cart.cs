namespace Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; private set; }
    public List<CartItem> Items { get; private set; } = new();

    private Cart() { }

    public Cart(Guid userId)
    {
        UserId = userId;
    }

    public void AddItem(Guid productId, int quantity)
    {
        var existing = Items.FirstOrDefault(x => x.ProductId == productId);

        if (existing != null)
            existing.Increase(quantity);
        else
            Items.Add(new CartItem(productId, quantity));
    }

    public void RemoveItem(Guid productId)
    {
        Items.RemoveAll(x => x.ProductId == productId);
    }
}
