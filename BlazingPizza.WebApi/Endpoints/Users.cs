using Membership.Entities.Interfaces.Login;
using Membership.Entities.Interfaces.Login.RefreshToken;
using Membership.Entities.Interfaces.Logout;
using Membership.Entities.Interfaces.Register;
using Membership.Shared.Entities;

namespace BlazingPizza.WebApi.Endpoints;
internal static class Users
{
    public static WebApplication UseUsersEndpoints(
        this WebApplication app)
    {
        app.MapPost("/user/register",
            async (IRegisterController controller,
                LocalUserForRegistrationDto userData) =>
            {
                await controller.RegisterAsync(userData);
                return Results.Ok();
            });

        app.MapPost("/user/externalregister",
           async (IExternalRegisterController controller,
               ExternalUserForRegistrationDto userData) =>
           {
               await controller.RegisterAsync(userData);
               return Results.Ok();
           });

        app.MapPost("/user/login",
                 async (
                 ILoginController controller, LocalUserCredentialsDto userCredentials,
                 HttpContext context) =>
                 {
                     context.Response.Headers.Add("Cache-Control", "no-store");
                     return Results.Ok(await controller.LoginAsync(userCredentials));
                 });

        app.MapPost("/user/refreshtoken",
               async (
               IRefreshTokenController controller, UserTokensDto userTokens,
               HttpContext context) =>
               {
                   context.Response.Headers.Add("Cache-Control", "no-store");
                   return Results.Ok(await controller.RefreshTokenAsync(userTokens));
               });

        app.MapPost("/user/logout",
           async (ILogoutController controller,
               string refreshToken) =>
           {
               await controller.LogoutAsync(refreshToken);
               return Results.NoContent();
           });
        return app;
    }


}
