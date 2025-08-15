using Domain.Common.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class User : SoftDeletedEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? MiddleName { get; set; } = default!;

    public UserRole Role { get; set; }

    public bool IsActive { get; set; } = true;
}