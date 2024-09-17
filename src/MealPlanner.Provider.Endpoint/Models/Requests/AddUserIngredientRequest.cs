namespace MealPlanner.Provider.Endpoint.Models;

public class AddUserIngredientRequest
{
    public int UserId { get; set; }
    public int IngredientId { get; set; }
    // What about ingredient quantities in strings?
    public int Quantity { get; set; }
}