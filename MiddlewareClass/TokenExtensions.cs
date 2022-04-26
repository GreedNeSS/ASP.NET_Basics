using System;
namespace MiddlewareClass
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder appBuilder, string pattern)
        {
            return appBuilder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
