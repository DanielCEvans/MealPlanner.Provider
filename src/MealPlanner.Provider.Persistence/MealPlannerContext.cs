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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User configuration
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Username).IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Email).IsUnique();

        // IngredientCategory configuration
        modelBuilder.Entity<IngredientCategory>()
            .HasIndex(e => e.CategoryName).IsUnique();

        // UserIngredient configuration
        modelBuilder.Entity<UserIngredient>()
            .HasIndex(ui => new { ui.UserId, ui.IngredientId })
            .IsUnique();
    }
        
}

