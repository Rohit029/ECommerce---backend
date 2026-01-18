using Application.DTOs;
using Application.Repositories;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenGenerator _jwt;

    public AuthService(
        IUserRepository userRepo,
        IPasswordHasher hasher,
        IJwtTokenGenerator jwt)
    {
        _userRepo = userRepo;
        _hasher = hasher;
        _jwt = jwt;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var hash = _hasher.Hash(request.Password);
        var user = new User(request.Email, hash, UserRole.Customer);

        await _userRepo.AddAsync(user);
        return new AuthResponse { Token = _jwt.Generate(user) };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepo.GetByEmailAsync(request.Email)
            ?? throw new Exception("Invalid credentials");

        if (!_hasher.Verify(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        return new AuthResponse { Token = _jwt.Generate(user) };
    }
}
