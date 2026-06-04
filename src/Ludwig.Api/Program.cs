
using Ludwig.Api.Endpoints;
using Ludwig.Api.Extensions;

var MyAllowSpecificOrigins = "myOrigin";


var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSystemServices(MyAllowSpecificOrigins);

var app = builder.Build();


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();


app.MapGet("/test", () =>
{
    return "Hello World!";
});
app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(o => { });
app.RegistraEndpointPrenotazioni();
app.Run();

