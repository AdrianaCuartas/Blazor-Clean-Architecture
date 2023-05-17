
using Membership.Entities.Interfaces;

namespace Membership.UserManager.AspNetIdentity;

public static class DependendencyContainer
{
    public static IServiceCollection AddAspNetIdentityServices(
        this IServiceCollection services)
    {
        services.AddDbContext<UserManagerContext>();

        //para inyectar el userManager de Aspnetcore.identity ofrece el helper
        //AddIdentityCore  y se especifica el tipo de usuario:<User>
        //y ademas el medio de persistencia es el medio de persistencia AddEntityFrameworkStores<UserManagerContext>()
        services.AddIdentityCore<User>()
               .AddEntityFrameworkStores<UserManagerContext>();

        services.AddScoped<IUserManagerService,
            UserManagerService>();
        return services;
    }
}