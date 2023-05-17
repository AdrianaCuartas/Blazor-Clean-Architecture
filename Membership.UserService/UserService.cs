using Membership.Entities.Interfaces;

namespace Membership.UserService;

//Vide 3 und 4. 0:39 se esta utilizando la primera instancia del htpcontext obtenida cuando se
//instancia el servicio IserviceService
internal class UserService : IUserService
{

    //se almacena el contexto de la primera  que se creo o se obtuvo al insanciar el servicio
    //y despues como es singleto se sigue trabajando con la instacia //1:20
    readonly IHttpContextAccessor Context;


    //IHttpContextAccessor proporciona el contexto actual de httpcontext.
    //Obtiene o establece el httpcontext actual de la peticin actual o devuelve nulo si no hay un contexto actual
    //1:37,HttpContext encapsula toda  por cada peticion se contruye un IHttpContextAccessor

    public UserService(IHttpContextAccessor httpContextAccesor)
    {
        Context = httpContextAccesor;
    }

    public bool IsAuthenticated =>
        Context.HttpContext.User.Identity?.IsAuthenticated ?? false;

    public string UserId => Context.HttpContext.User.Identity?.Name;

    public string FullName => Context.HttpContext.User
            .Claims.Where(c => c.Type == "FullName")
            .Select(c => c.Value).FirstOrDefault();


}