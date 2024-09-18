namespace MealPlanner.Provider.Endpoint.Models;

public class Ingredient
{
    public int IngredientID { get; set; }
    public int Quantity { get; set; }
}

public class AddUserIngredientsRequest
{
    public int UserId { get; set; }
    public List<Ingredient> Ingredients { get; set; }
}