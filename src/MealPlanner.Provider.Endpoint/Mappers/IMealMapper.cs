using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public interface IMealMapper
{
    Meal AddMealRequestToMealPersistence(AddMealRequest addMealRequest);
}