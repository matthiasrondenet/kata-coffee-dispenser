using System.Text.Json.Serialization;
using DrinkDispenser.Api.Adapters;
using DrinkDispenser.Api.Domain;
using DrinkDispenser.Api.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddSwaggerGen(
    (config) =>
    {
        config.SwaggerDoc("v1", new OpenApiInfo { Title = "Kata Drink dispenser", Version = "v1" });

        // config.DescribeAllEnumsAsStrings();
    });

builder.Services.AddTransient<IIngredientRepository, InMemoryIngredientRepository>();
builder.Services.AddTransient<IDrinkRepository, InMemoryDrinkRepository>();
builder.Services.AddTransient<ISalesMarginConfiguration, DefaultSalesMarginConfiguration>();
builder.Services.AddTransient<DrinkDispenser.Api.Domain.DrinkDispenser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var drinksGroup = app.MapGroup("drinks").WithTags("drinks");
drinksGroup.MapGet(
                "/",
                (DrinkDispenser.Api.Domain.DrinkDispenser drinkDispenser) =>
                {
                    var results = drinkDispenser.GetAvailableDrinks();
                    return Results.Ok(new GetDrinksResponse(results));
                })
           .WithName("get available drinks")
           .WithOpenApi();

drinksGroup.MapGet(
                "/{drinkType}/price",
                (DrinkType drinkType, DrinkDispenser.Api.Domain.DrinkDispenser drinkDispenser) =>
                {
                    var price = drinkDispenser.GetPriceFor(drinkType);
                    return Results.Ok(new GetDrinkPriceResponse(price));
                })
           .WithName("get drink price")
           .WithOpenApi();

app.Run();

record GetDrinksResponse(IReadOnlyCollection<DrinkType> Drinks);

record GetDrinkPriceResponse(decimal Price);
