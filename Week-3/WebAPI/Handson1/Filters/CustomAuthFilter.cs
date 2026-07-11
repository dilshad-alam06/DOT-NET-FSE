using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Handson1.Filters
{
    public class CustomAuthFilter : IAuthorizationFilter
    {
        private readonly ILogger<CustomAuthFilter> _logger;

        public CustomAuthFilter(ILogger<CustomAuthFilter> logger)
        {
            _logger = logger;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Skip authentication if endpoint allows anonymous access
            var allowAnonymous = context.ActionDescriptor?.EndpointMetadata?.Any(m => m is IAllowAnonymous) ?? false;
            if (allowAnonymous)
            {
                _logger.LogInformation("AllowAnonymous detected, skipping auth check.");
                return;
            }

            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(authHeader))
            {
                _logger.LogWarning("Authorization header missing");
                context.Result = new UnauthorizedObjectResult("Invalid request - No Auth token");
                return;
            }
            if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning("Invalid token format");
                context.Result = new UnauthorizedObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }
            // token present and starts with Bearer - allow request to proceed
        }
    }
}
