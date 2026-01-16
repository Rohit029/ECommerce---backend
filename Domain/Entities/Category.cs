namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; } = default!;
    public Guid? ParentCategoryId { get; private set; }

    private Category() { }

    public Category(string name, Guid? parentCategoryId = null)
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
    }
}
