using Domain.Entities;

namespace Application.Common.Identities;

public interface IRefreshTokenGeneratorService
{
    Task<string> GenerateAsync(User user,CancellationToken cancellationToken = default);
}