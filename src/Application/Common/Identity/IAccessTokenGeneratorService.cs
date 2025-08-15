using Domain.Entities;

namespace ProjectApplication.Common.Identities;

public interface IAccessTokenGeneratorService
{
    Task<string> GenerateAsync(User user, CancellationToken cancellationToken);
}