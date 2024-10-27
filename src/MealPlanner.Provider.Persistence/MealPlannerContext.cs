using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence;

public class MealPlannerContext : DbContext
{
    public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<IngredientCategory> IngredientCategories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<UserIngredient> UserIngredients { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    public DbSet<StoredCredential> StoredCredentials { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Username).IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Email).IsUnique();

        modelBuilder.Entity<IngredientCategory>()
            .HasIndex(e => e.Name).IsUnique();

        modelBuilder.Entity<UserIngredient>()
            .HasIndex(ui => new { ui.UserId, ui.IngredientId })
            .IsUnique();

        modelBuilder.Entity<Ingredient>()
            .Property(i => i.Unit)
            .HasConversion<string>();
        
        modelBuilder.Entity<StoredCredential>(builder =>
        {
            // Ignore the Descriptor property
            builder.Ignore(c => c.Descriptor);
        });
        

    }
        
}

