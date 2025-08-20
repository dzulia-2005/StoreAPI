using System.Security.Claims;
using storeapi.Models;

namespace storeapi.Extension;

public static class ClaimExtension
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        return user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
    }

    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var id = user.Claims.SingleOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value;
        if (id==null)
        {
            throw new Exception("user id is not found");
        }

        return Guid.Parse(id);
    }
}