using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;
public class RecipeIngredientDTO
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public string IngredientName { get; set; }
    public decimal RecipeIngredientQuantity { get; set; }
    public string IngredientCategory { get; set; }
    public DatabaseMeasurementUnit Unit { get; set; }
}

public class RecipeIngredientRepository : IRecipeIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public RecipeIngredientRepository(MealPlannerContext context)
    {
        _dbContext = context;
    }

    public List<RecipeIngredientDTO> GetRecipeIngredients(List<int> recipeIds)
    {
        var recipeIngredients = (from ri in _dbContext.RecipeIngredients
            where recipeIds.Contains(ri.RecipeId)
            select new RecipeIngredientDTO
            {
                RecipeId = ri.RecipeId,
                IngredientId = ri.IngredientId,
                IngredientName = ri.Ingredient.Name,
                RecipeIngredientQuantity = ri.Quantity,
                IngredientCategory = ri.Ingredient.Category.Name,
                Unit = ri.Ingredient.Unit
            }).ToList();
        return recipeIngredients;
    }
}