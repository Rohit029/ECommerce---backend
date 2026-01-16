namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal BasePrice { get; private set; }
    public Guid CategoryId { get; private set; }

    private Product() { }

    public Product(string name, string description, decimal basePrice, Guid categoryId)
    {
        if (basePrice <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Name = name;
        Description = description;
        BasePrice = basePrice;
        CategoryId = categoryId;
    }
}
