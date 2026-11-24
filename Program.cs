
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using User_Management.Data;
using User_Management.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(
        builder.Configuration.GetConnectionString(
            "DefaultConnection")!
            ));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();


    // Scalar Interactive API Referenceapp.MapScalarApiReference(options =>
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("User Management API")

               .WithClassicLayout();
    });

}
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
