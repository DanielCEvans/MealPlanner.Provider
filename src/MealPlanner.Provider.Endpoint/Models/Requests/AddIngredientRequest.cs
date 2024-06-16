namespace MealPlanner.Provider.Endpoint.Models;

public class AddIngredientRequest
{
    public string IngredientName { get; set; }
    public string MeasurementUnit { get; set; }
    public int IngredientAmount { get; set; }
    public string IngredientCategory { get; set; }
}