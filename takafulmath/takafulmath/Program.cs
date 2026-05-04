using takafulmath.Classes;
using takafulmath.Interfaces;
using takafulmath.Model;
using takafulmath.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddScoped<MathInputValidator>();
builder.Services.AddScoped<InputServices>();
builder.Services.AddScoped<IMathInput, InputServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/formula", async (MathInputDTO dto, IMathInput service) =>
{
    try
    {
        var expression = await service.TakafulMathInput(dto);

        return Results.Ok(new
        {
            message = "Formula constructed successfully.",
            returnedExpression = expression
        });
    }
    catch (FluentValidation.ValidationException ex)
    {
        var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.First().ErrorMessage
            );

        return Results.BadRequest(new
        {
            status = "error",
            message = "Validation failed.",
            errors
        });
    }
});

app.Run();
