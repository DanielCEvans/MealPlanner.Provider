using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Models;

public class AddIngredientRequest
{
    public string Name { get; init; }
    public DatabaseMeasurementUnit Unit { get; init; }
    
    public int CategoryId { get; init; }
    public int? GramsPerCup { get; init; } 
}

