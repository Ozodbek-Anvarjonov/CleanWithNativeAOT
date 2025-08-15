namespace Domain.Common.Entities;

public interface ISoftDeletedEntity
{
    long? DeletedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}