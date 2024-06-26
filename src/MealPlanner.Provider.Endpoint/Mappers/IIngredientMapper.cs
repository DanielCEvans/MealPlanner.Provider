using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public interface IIngredientMapper
{
    Ingredient ToPersistence(AddIngredientRequest ingredientRequest);
    List<Ingredient> ToPersistence(List<MealIngredient> ingredientRequest);
}