using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using PresentationTier.Data;
using PresentationTier.Models;

namespace PresentationTier.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
    private readonly IJSRuntime jsRuntime;
    private readonly IUserService userService;

    private User cachedUser;

    public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService) {
        this.jsRuntime = jsRuntime;
        this.userService = userService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        var identity = new ClaimsIdentity();
        if (cachedUser == null) {
            var userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userAsJson)) {
                var tmp = JsonSerializer.Deserialize<User>(userAsJson);
                await ValidateLogin(tmp.Email, tmp.Password);
            }
        } else {
            identity = SetupClaimsForUser(cachedUser);
        }

        var cachedClaimsPrincipal = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
    }

    public async Task ValidateLogin(string email, string password) {
        if (string.IsNullOrEmpty(email)) throw new Exception("Enter username");
        if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

        var identity = new ClaimsIdentity();
        try {
            var user = await userService.ValidateUser(email, password);
            identity = SetupClaimsForUser(user);
            var serialisedData = JsonSerializer.Serialize(user);
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
            cachedUser = user;
        } catch (Exception e) {
            throw e;
        }

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }

    public async Task Logout() {
        cachedUser = null;
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    private ClaimsIdentity SetupClaimsForUser(User user) {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Email, user.Email),
            new ("Level", user.Role)
        };

        var identity = new ClaimsIdentity(claims, "apiauth_type");
        return identity;
    }
}