using Common.DataStructure;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Frontend.Src.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage sessionStorage;
        private readonly ClaimsPrincipal anonymus = new (new ClaimsIdentity());

        public CustomAuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                ProtectedBrowserStorageResult<User> userSessionStorageResult = await sessionStorage.GetAsync<User>("UserSession");
                User userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(anonymus));
                }


                ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name,userSession.Username),
                new Claim(ClaimTypes.Email, userSession.Email)

            }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(anonymus));
            }
        }

        public async Task UpdateAuthenticationState(User user)
        {
            ClaimsPrincipal claimsPrincipal;
            if (user != null)
            {
                await sessionStorage.SetAsync("UserSession", user);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }));
            }
            else{
                await sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = anonymus;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
