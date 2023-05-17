using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace StreamingAccounts.WEB.Auth
{
    public class AuthenticationProviderTest:AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var oapUser = new ClaimsIdentity(new List<Claim>
                                            {
            new Claim("FirstName", "Yeef"),
            new Claim("LastName", "G"),
            new Claim(ClaimTypes.Name, "Yef@yopmail.com"),
            new Claim(ClaimTypes.Role, "Admin")

                 },
                  authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }

    }
}
