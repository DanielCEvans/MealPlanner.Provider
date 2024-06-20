using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Mappers;

public class MealIngredientMapper : IMealIngredientMapper
{
    public List<MealIngredients> ToPersistance(AddMealRequest addMealRequest)
    {
        String mealName = addMealRequest.MealName;
        List<MealIngredients> mealIngredients = new List<MealIngredients>();
        
        foreach (var ingredient in addMealRequest.MealIngredients)
        {
            mealIngredients.Add(new MealIngredients()
            {
                MealName = mealName,
                IngredientName = ingredient.IngredientName,
                MeasurementUnit = ingredient.MeasurementUnit,
                MealIngredientAmount = ingredient.MealIngredientAmount
            });
        }

        return mealIngredients;
    }
}