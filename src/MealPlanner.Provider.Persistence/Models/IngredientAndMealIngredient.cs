namespace MealPlanner.Provider.Persistence.Models;

public class IngredientAndMealIngredient
{
    public string IngredientName { get; set; }
    public int MealIngredientAmount { get; set; }
    public int KitchenIngredientAmount { get; set; }
    public string MeasurementUnit { get; set; }
    public string IngredientCategory { get; set; }
}