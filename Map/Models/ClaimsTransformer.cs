using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Map.Models
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }
    }
}
