using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ProductService.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header not found.");

            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter)).Split(":");

            var emailAddress = credentials[0];
            var password = credentials[1];

            if (emailAddress.Equals("sujith.kp@hotmail.com") && password.Equals("password"))
            {
                var claims = new[] { new Claim(ClaimTypes.Email, "sujith.kp@hotmail.com") };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Not Authenticated");
        }
    }
}
