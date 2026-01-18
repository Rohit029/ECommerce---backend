using Domain.Entities;

namespace Application.Services;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}
