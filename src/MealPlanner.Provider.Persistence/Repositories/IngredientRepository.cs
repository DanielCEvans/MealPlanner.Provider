using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Repositories;

public class IngredientWithCategoryDTO
{
    public int IngredientId { get; set; }
    public string IngredientName { get; set; }
    public string Unit { get; set; }
    public string CategoryName { get; set; }
}

public class IngredientRepository : IIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public IngredientRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<IngredientWithCategoryDTO> GetAllIngredients()
    {
        var ingredientsWithCategories = _dbContext.Ingredients
            .Include(i => i.Category)
            .Select(i => new IngredientWithCategoryDTO
            {
                IngredientId = i.IngredientId,
                IngredientName = i.IngredientName,
                Unit = i.Unit,
                CategoryName = i.Category.CategoryName
            })
            .ToList();
            
        return ingredientsWithCategories;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        _dbContext.Ingredients.Add(ingredient);
        _dbContext.SaveChanges();
    }

    public void AddIngredients(List<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            try
            {
                _dbContext.Ingredients.Add(ingredient);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Ingredient already exists, continuing to next ingredient");
                _dbContext.Entry(ingredient).State = EntityState.Detached;
            }
        }
    }
}