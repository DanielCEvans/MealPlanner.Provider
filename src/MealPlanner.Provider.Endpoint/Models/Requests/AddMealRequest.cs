namespace MealPlanner.Provider.Endpoint.Models;

public class AddMealRequest
{
    public string MealName { get; set; }
    public List<MealIngredient> MealIngredients { get; set; }
}