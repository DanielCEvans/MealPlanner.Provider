using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public class MealMapper : IMealMapper
{
    public Meal AddMealRequestToMealPersistence(AddMealRequest addMealRequest)
    {
        return new Meal()
        {
            MealName = addMealRequest.MealName,
            MealType = addMealRequest.MealType
        };
    }
}