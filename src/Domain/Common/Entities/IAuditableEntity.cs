namespace Domain.Common.Entities;

public interface IAuditableEntity : IEntity
{
    long CreatedById { get; set; }
    DateTimeOffset CreateAt { get; set; }

    long? ModifiedById { get; set; }
    DateTimeOffset? ModifiedAt { get; set; }
}