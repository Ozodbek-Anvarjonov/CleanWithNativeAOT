namespace Application.Features.Auth.Dtos;

public class LoginRequest
{
    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}