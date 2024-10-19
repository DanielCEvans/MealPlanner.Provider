using System.Text.Json.Serialization;

namespace MealPlanner.Provider.Endpoint.Models;

public class RecipeIngredientRequest
{
    public int IngredientId { get; init; }
    public string DatabaseUnit { get; init; }
    public MeasurementUnit RecipeUnit { get; init; }
    public decimal Amount { get; set; }
    public int GramsPerCup { get; set; }
}

public class AddRecipeRequest
{
    public string Name { get; init; }
    public string Description { get; init; }
    public List<RecipeIngredientRequest> RecipeIngredients { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MeasurementUnit
{
    kg,
    gm,
    l,
    ml,
    cup,
    tbs,
    tsp
}

