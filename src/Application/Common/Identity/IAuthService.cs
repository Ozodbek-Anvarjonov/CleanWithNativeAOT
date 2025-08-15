using Application.Features.Auth.Dtos;
using Domain.Entities;

namespace Project.Application.Common.Identities;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default);

    Task<bool> RegisterAsync(User user, CancellationToken cancellationToken = default);

    Task<LoginResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);

    Task<bool> LogoutAsync(string refreshToken, CancellationToken cancellationToken = default);
}