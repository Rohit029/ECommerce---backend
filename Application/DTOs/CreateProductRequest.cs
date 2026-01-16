namespace Application.DTOs;

public class CreateProductRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal BasePrice { get; set; }
    public Guid CategoryId { get; set; }
}
