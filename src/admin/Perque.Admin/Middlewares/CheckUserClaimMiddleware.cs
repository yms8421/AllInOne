using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Perque.Admin.Middlewares
{
    public class CheckUserClaimMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckUserClaimMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }
}
