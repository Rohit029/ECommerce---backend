namespace Application.DTOs;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal BasePrice { get; set; }
}
