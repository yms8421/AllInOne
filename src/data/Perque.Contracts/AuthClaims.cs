using System.Security.Claims;
using System.Linq;

namespace Perque.Contracts
{
    public class AuthClaims : IClaims
    {
        public AuthClaims(ClaimsPrincipal principal)
        {
            var mailClaim = principal.Claims.FirstOrDefault(i => i.Type == "uniqueName");
            if (mailClaim != null)
            {
                Mail = mailClaim.Value;
            }

            var idClaim = principal.Claims.FirstOrDefault(i => i.Type == "userId");
            if (idClaim != null)
            {
                UserId = int.Parse(idClaim.Value);
            }
        }
        public int UserId { get; }
        public string Mail { get; }
    }
}
