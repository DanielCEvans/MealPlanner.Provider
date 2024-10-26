using Fido2NetLib;
using MealPlanner.Provider.Endpoint.Services;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// TODO: determine what this actually does
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(2);
    options.Cookie.HttpOnly = true;
    // Strict SameSite mode is required because the default mode used
    // by ASP.NET Core 3 isn't understood by the Conformance Tool
    // and breaks conformance testing
    options.Cookie.SameSite = SameSiteMode.Unspecified;
});
builder.Services.AddFido2(options =>
{
    options.ServerDomain = builder.Configuration["fido2:serverDomain"];
    options.ServerName = "FIDO Dan";
    options.Origins = builder.Configuration.GetSection("fido2:origins").Get<HashSet<string>>();
    options.TimestampDriftTolerance = builder.Configuration.GetValue<int>("fido2:timestampDriftTolerance");
    options.BackupEligibleCredentialPolicy =
        builder.Configuration.GetValue<Fido2Configuration.CredentialBackupPolicy>(
            "fido2:backupEligibleCredentialPolicy");
    options.BackedUpCredentialPolicy =
        builder.Configuration.GetValue<Fido2Configuration.CredentialBackupPolicy>("fido2:backedUpCredentialPolicy");
});
// TODO: end

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
    
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3001")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IMealPlannerService, MealPlannerService>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddScoped<IUserIngredientRepository, UserIngredientRepository>();
builder.Services.AddScoped<IShoppingLists, ShoppingLists>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStoredCredentialRepository, StoredCredentialRepository>();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MealPlannerContext>(options => 
    options.UseNpgsql(conn)
);

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();

