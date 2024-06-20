using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public interface IMealIngredientMapper
{
    List<MealIngredients> ToPersistance(AddMealRequest addMealRequest);
}