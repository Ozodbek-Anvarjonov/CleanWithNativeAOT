
namespace Domain.Common.Entities;

public class AuditableEntity : Entity, IAuditableEntity
{
    public long CreatedById { get; set; }
    public DateTimeOffset CreateAt { get; set; }

    public long? ModifiedById { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}