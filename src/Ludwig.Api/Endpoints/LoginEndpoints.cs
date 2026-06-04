using Ludwig.Api.Auth;
using Ludwig.Data.Interfaces;

namespace Ludwig.Api.Endpoints;

public static class LoginEndpoints
{
    public static void RegistraEndpointLogin(this WebApplication app)
    {


        app.MapPost("/login", (LoginRequest request, TokenService tokenService, IDatiUtenti datiUtenti) =>
        {
            var user = datiUtenti.EstraiUtente(request.Username, request.Password).Result;
            var userId = user.id;
            var email = user.Email;

            if (user == null)
            {
                return Results.Unauthorized();
            }
          
            var token = tokenService.GenerateToken(userId.ToString(), email,user.Ruolo);

            return Results.Ok(token);
        }).AllowAnonymous();

     
    }

}

