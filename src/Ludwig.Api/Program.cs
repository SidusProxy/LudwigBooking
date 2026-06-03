
using Ludwig.Api.Extensions;

var MyAllowSpecificOrigins = "myOrigin";


var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSystemServices(MyAllowSpecificOrigins);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();


app.MapGet("/test", () =>
{
    return "Hello World!";
});

app.Run();

