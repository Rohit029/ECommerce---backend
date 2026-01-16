namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; protected set; }

    protected BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }

}
