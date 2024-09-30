var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) =>
{
    var apiReqKey = context.Request.Query["apikey"].ToString();
    var apiServKey = builder.Configuration["apikey"];
    if (apiReqKey != apiServKey){
        context.Response.StatusCode = 401;
        return;
    }
    await next();
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    return summaries;
});

app.Run();
