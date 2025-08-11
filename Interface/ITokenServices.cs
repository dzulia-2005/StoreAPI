using storeapi.Models;

namespace storeapi.Interface;

public interface ITokenService
{
    string CreateToken(User user);
    string GenerateRefreshToken();
    Task<string> GenerateAndSaveRefreshToken(User user);
}