using MealPlanner.Provider.Endpoint.Models.Enums;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Models;

public class RecipeIngredientRequest
{
    public int IngredientId { get; init; }
    public DatabaseMeasurementUnit DatabaseUnit { get; init; }
    public RecipeMeasurementUnit RecipeUnit { get; init; }
    public decimal Amount { get; set; }
    public int GramsPerCup { get; set; }
}

public class AddRecipeRequest
{
    public string Name { get; init; }
    public string Description { get; init; }
    public List<RecipeIngredientRequest> RecipeIngredients { get; init; }
}



