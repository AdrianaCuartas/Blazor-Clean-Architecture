
namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerContext : IdentityDbContext<User>
{
    readonly ASPNETIdentityOptions Options;

    public UserManagerContext(IOptions<ASPNETIdentityOptions> options)
    {
        Options = options.Value;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Options.ConnectionString);
        base.OnConfiguring(optionsBuilder); //se deja para que siga la ejecucion de la clase base, por si lo necesita
    }
}
