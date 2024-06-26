using MealPlanner.Provider.Endpoint.Mappers;
using MealPlanner.Provider.Endpoint.Services;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence;
using MealPlanner.Provider.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IMealPlannerService, MealPlannerService>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IMealIngredientRepository, MealIngredientRepository>();
builder.Services.AddScoped<IIngredientMapper, IngredientMapper>();
builder.Services.AddScoped<IMealMapper, MealMapper>();
builder.Services.AddScoped<IMealIngredientMapper, MealIngredientMapper>();

builder.Services.AddDbContext<MealPlannerContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ErrorDetailsConnection"))
);

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

