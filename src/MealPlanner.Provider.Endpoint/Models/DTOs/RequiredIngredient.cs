namespace MealPlanner.Provider.Endpoint.Models.DTOs;

public class RequiredIngredient
{
    public string IngredientName { get; set; }
    public int RequiredIngredientAmount { get; set; }
    public string MeasurementUnit { get; set; }
    
    public string IngredientCategory { get; set; }
}