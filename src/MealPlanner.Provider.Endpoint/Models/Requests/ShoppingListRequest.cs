namespace MealPlanner.Provider.Endpoint.Models;

public class ShoppingListRequest
{
    public int UserId { get; set; }
    public List<int> RecipeIds { get; set; }
}